param(
    [switch]$Force
)

. ./shared.ps1

$templateConfigurationsList = '/Lists/Templates'
$baseModulesLibrary = 'BaseModules'
$subModulesLibrary = 'AppsModules'
$timerIntervalMinutes = 30;

function GetUniqueUrlFromName($title) {
    Connect -Url $tenantAdminUrl
    $cleanName = $title -replace '[^a-z0-9]'
    if ([String]::IsNullOrWhiteSpace($cleanName)) {
        $cleanName = "team"
    }
    $url = "$tenantUrl/$managedPath/$cleanName"
    $doCheck = $true
    while ($doCheck) {
        Get-PnPTenantSite -Url $url -ErrorAction SilentlyContinue >$null 2>&1
        if ($? -eq $true) {
            $url += '1'
        }
        else {
            $doCheck = $false
        }
    }
    return $url
}

function EnsureSite {
    Param(
        [string]$siteEntryId,
        [string]$title,
        [string]$url,
        [string]$description = "",
        [string]$siteCollectionAdmin,
        [Microsoft.SharePoint.Client.User]$owner,
        [String[]]$ownerAddresses,
        [String[]]$members,
        [String[]]$visitors,
        [Microsoft.SharePoint.Client.FieldUserValue]$requestor
    )

    #Connect admin url
    Connect -Url $tenantAdminUrl

    $site = Get-PnPTenantSite -Url $url -ErrorAction SilentlyContinue
    if ( $? -eq $false) {
        Write-Output "Site at $url does not exist - let's create it"
        $site = New-PnPTenantSite -Title $title -Url $url -Owner $siteCollectionAdmin -TimeZone 3 -Description $description -Lcid 1033 -Template "STS#0"  -RemoveDeletedSite:$true -Wait
        if ($? -eq $false) {
            # send e-mail
            $mailHeadBody = GetMailContent -email $owner.Email -mailFile "fail"
            Write-Output "Sending fail mail to $ownerAddresses"
            Send-PnPMail -To $ownerAddresses -Subject $mailHeadBody[0] -Body ($mailHeadBody[1] -f $url)
            Write-Error "Something happened"
            UpdateStatus -id $siteEntryId -status 'Failed'
            return;
        }
    }
    elseif ($site.Status -ne "Active") {
        Write-Output "Site at $url already exist"
        while ($true) {
            # Wait for site to be ready
            $site = Get-PnPTenantSite -Url $url
            if ( $site.Status -eq "Active" ) {
                break;
            }
            Write-Output "Site not ready"
            Start-Sleep -s 20
        }
    }
}

function EnsureSecurityGroups([string]$url, [string]$title, [string[]]$owners, [string[]]$members, [string[]]$visitors, [string]$siteCollectionAdmin) {
    Connect -Url $url

    $visitorsGroup = Get-PnPGroup -AssociatedVisitorGroup -ErrorAction SilentlyContinue
    if ( $? -eq $false) {
        Write-Output "Creating visitors group"
        $visitorsGroup = New-PnPGroup -Title "$title Visitors" -Owner $siteCollectionAdmin
        Set-PnPGroup -Identity $visitorsGroup -SetAssociatedGroup Visitors
    }

    $membersGroup = Get-PnPGroup -AssociatedMemberGroup -ErrorAction SilentlyContinue
    if ( $? -eq $false) {
        Write-Output "Creating members group"
        $membersGroup = New-PnPGroup -Title "$title Members" -Owner $siteCollectionAdmin
        Set-PnPGroup -Identity $membersGroup -SetAssociatedGroup Members
    }

    $ownersGroup = Get-PnPGroup -AssociatedOwnerGroup -ErrorAction SilentlyContinue
    if ( $? -eq $false) {
        Write-Output "Creating owners group"
        $ownersGroup = New-PnPGroup -Title "$title Owners" -Owner $siteCollectionAdmin
        Set-PnPGroup -Identity $ownersGroup -SetAssociatedGroup Owners
    }

    if ($owners -ne $null) {
        Write-Output "`tAdding owners: $owners"
        foreach ($login in $owners) {
            Add-PnPUserToGroup -Identity $ownersGroup -LoginName $login
        }
    }

    if ($members -ne $null) {
        Write-Output "`tAdding members: $members"
        foreach ($login in $members) {
            Add-PnPUserToGroup -Identity $membersGroup -LoginName $login
        }
    }

    if ($visitors -ne $null) {
        Write-Output "`tAdding visitors: $visitors"
        foreach ($login in $visitors) {
            Add-PnPUserToGroup -Identity $visitorsGroup -LoginName $login
        }
    }
}

function ApplyTemplate([string]$url, [string]$templateUrl, [string]$templateName) {
    Connect -Url $url

    $appliedTemplates = Get-PnPPropertyBag -Key $propBagTemplateInfoStampKey
    if ((-not $appliedTemplates.Contains("|$templateName|") -or $Force)) {
        Write-Output "`tApplying template $templateName to $url"
        Apply-PnPProvisioningTemplate -Path $templateUrl
        if ($? -eq $true) {
            $appliedTemplates = "$appliedTemplates|$templateName|"
            Set-PnPPropertyBagValue -Key $propBagTemplateInfoStampKey -Value $appliedTemplates
        }
    }
    else {
        Write-Output "`tTemplate $templateName already applied to $url"
    }
}

function SetSiteUrl($siteItem, $siteUrl, $title) {
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    Write-Output "`tSetting site URL to $siteUrl"
    Set-PnPListItem -List $siteDirectoryList -Identity $siteItem["ID"] -Values @{"$($columnPrefix)SiteURL" = "$siteUrl, $title"} -ErrorAction SilentlyContinue >$null 2>&1
}

function UpdateStatus($id, $status) {
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    Set-PnPListItem -List $siteDirectoryList -Identity $id -Values @{"$($columnPrefix)SiteStatus" = $status} -ErrorAction SilentlyContinue >$null 2>&1
}

function SendReadyEmail() {
    Param(
        [string]$url,
        [string]$toEmail,
        [String[]]$ccEmails,
        [string]$title
    )
    Connect -Url $url
    if ( -not [string]::IsNullOrWhiteSpace($toEmail) ) {
        $mailHeadBody = GetMailContent -email $toEmail -mailFile "welcome"

        Write-Output "Sending ready mail to $toEmail and $ccEmails"
        Send-PnPMail -To $toEmail -Cc $ccEmails -Subject ($mailHeadBody[0] -f $title) -Body ($mailHeadBody[1] -f $title, $url)
    }
}


function Apply-TemplateConfigurations($url, $siteItem, $templateConfigurationItems, $baseModuleItems, $subModuleItems) {
    Connect -Url $url
    $templateConfig = $siteItem["$($columnPrefix)TemplateConfig"]
    $subModules = $siteItem["$($columnPrefix)SubModules"]
    if ($templateConfig -ne $null) {
        $chosenTemplateConfig = $templateConfigurationItems |? Id -eq $templateConfig.LookupId
        if ($chosenTemplateConfig -ne $null) {
            $chosenBaseTemplate = $chosenTemplateConfig["$($columnPrefix)BaseModule"]
            $chosenSubModules = $chosenTemplateConfig["$($columnPrefix)SubModules"]
            if ($chosenBaseTemplate -ne $null) {
                $pnpTemplate = $baseModuleItems |? Id -eq $chosenBaseTemplate.LookupId
                $pnpUrl = $tenantUrl + $pnpTemplate["FileRef"]
                ApplyTemplate -url $url -templateUrl $pnpUrl -templateName $pnpTemplate["FileLeafRef"]
            }
            if ($chosenSubModules -ne $null) {                
                foreach ($module in $chosenSubModules) {
                    $pnpTemplate = $subModuleItems |? Id -eq $module.LookupId
                    $pnpUrl = $tenantUrl + $pnpTemplate["FileRef"]
                    ApplyTemplate -url $url -templateUrl $pnpUrl -templateName $pnpTemplate["FileLeafRef"]
                }
            }
        }
    }
    foreach ($module in $subModules) {
        $pnpTemplate = $subModuleItems |? Id -eq $module.LookupId
        $pnpUrl = $tenantUrl + $pnpTemplate["FileRef"]
        ApplyTemplate -url $url -templateUrl $pnpUrl -templateName $pnpTemplate["FileLeafRef"]
    }
}

function GetRecentlyUpdatedItems($IntervalMinutes) {
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $date = [DateTime]::UtcNow.AddMinutes( - $IntervalMinutes).ToString("yyyy\-MM\-ddTHH\:mm\:ssZ")
    $recentlyUpdatedCaml = @"
<View>
    <Query>
        <Where>
            <Gt>
                <FieldRef Name="Modified" />
                <Value IncludeTimeValue="True" Type="DateTime" StorageTZ="TRUE">$date</Value>
            </Gt>
        </Where>
        <OrderBy>
            <FieldRef Name="Modified" Ascending="False" />
        </OrderBy>
    </Query>
    <ViewFields>
        <FieldRef Name="ID" />
    </ViewFields>
</View>
"@
    if ($Force) {
        return @(Get-PnPListItem -List $siteDirectoryList)    
    }
    else {
        return @(Get-PnPListItem -List $siteDirectoryList -Query $recentlyUpdatedCaml)
    }    
}

Write-Output @"
  ___  ___      ______               _     _
  |  \/  |      | ___ \             (_)   (_)
  | .  . |_ __  | |_/ / __ _____   ___ ___ _  ___  _ __
  | |\/| | '__| |  __/ '__/ _ \ \ / / / __| |/ _ \| '_ \
  | |  | | |_   | |  | | | (_) \ V /| \__ \ | (_) | | | |
  \_|  |_/_(_)  \_|  |_|  \___/ \_/ |_|___/_|\___/|_| |_|
                                            by Puzzlepart
  Code by: @mikaelsvenson / @tarjeieo

"@

Connect -Url "$tenantURL$siteDirectorySiteUrl"
$templateConfigurationItems = @(Get-PnPListItem -List $templateConfigurationsList)
$baseModuleItems = @(Get-PnPListItem -List $baseModulesLibrary)
$subModuleItems = @(Get-PnPListItem -List $subModulesLibrary)
$siteDirectoryItems = GetRecentlyUpdatedItems -Interval $timerIntervalMinutes

if (!$siteDirectoryItems -or ($siteDirectoryItems -ne $null -and (0 -eq $siteDirectoryItems.Count))) {
    Write-Output "No site requests detected last $timerIntervalMinutes minutes"
}

foreach ($siteItem in $siteDirectoryItems) {
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $siteItem = Get-PnPListItem -List $siteDirectoryList -Id $siteItem.ID #load all fields

    $editor = $siteItem["Editor"][0].LookUpValue 
    $orderedByUser = $siteItem["Author"][0]

    $title = $siteItem["Title"]
    $description = $siteItem["$($columnPrefix)ProjectDescription"]
    $ownerEmailAddresses = @(@($siteItem["$($columnPrefix)SiteOwners"]) |? {-not [String]::IsNullOrEmpty($_.Email)} | select -ExpandProperty Email)
    $siteStatus = $siteItem["$($columnPrefix)SiteStatus"]

    $ownerEmailAddresses = $ownerEmailAddresses | select -uniq | sort

    $businessOwnerEmailAddress = @($siteItem["$($columnPrefix)BusinessOwner"] |? {-not [String]::IsNullOrEmpty($_.Email)} | select -ExpandProperty Email)

    $owners = @($siteItem["$($columnPrefix)SiteOwners"]) | select -ExpandProperty LookupId
    $owners = @($owners | % { GetLoginName -lookupId $_ })
    $members = @($siteItem["$($columnPrefix)SiteMembers"]) | select -ExpandProperty LookupId
    $members = @($members | % { GetLoginName -lookupId $_ })
    $visitors = @($siteItem["$($columnPrefix)SiteVisitors"]) | select -ExpandProperty LookupId
    $visitors = @($visitors | % { GetLoginName -lookupId $_ })

    $ownerAccount = GetLoginName -lookupId $siteItem["$($columnPrefix)BusinessOwner"].LookupId
    $ownerAccount = New-PnPUser -LoginName $ownerAccount 
    
    if ( $siteItem["$($columnPrefix)SiteURL"] -eq $null) {
        $siteUrl = GetUniqueUrlFromName -title $title
    }
    else {
        $siteUrl = $siteItem["$($columnPrefix)SiteURL"].Url
    }
    
    Write-Output "`nProcessing $siteUrl"
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $urlToSiteDirectory = "$tenantURL$siteDirectorySiteUrl$siteDirectoryList"

    EnsureSite -siteEntryId $siteItem["ID"] -title $title -url $siteUrl -description $description `
        -siteCollectionAdmin $primarySiteCollectionAdmin `
        -owner $ownerAccount `
        -ownerAddresses $businessOwnerEmailAddress `
        -members $members `
        -visitors $visitors `
        -requestor $orderedByUser

    if ($? -eq $true -and ($editor -ne "SharePoint App" -or $Force)) {        
        SetSiteUrl -siteItem $siteItem -siteUrl $siteUrl -title $title
        EnsureSecurityGroups -url $siteUrl -title $title -owners $owners -members $members -visitors $visitors        
        
        Apply-TemplateConfigurations -url $siteUrl -siteItem $siteItem -templateConfigurationItems $templateConfigurationItems -baseModuleItems $baseModuleItems -subModuleItems $subModuleItems

        SetRequestAccessEmail -url $siteUrl -ownersEmail ($ownerEmailAddresses -join ',')
        if ($siteStatus -ne 'Provisioned') {
            SendReadyEmail -url $siteUrl -toEmail $orderedByUser.Email -ccEmails $businessOwnerEmailAddress -title $title
        }

        UpdateStatus -id $siteItem["ID"] -status 'Provisioned'
    }
}
Disconnect-PnPOnline