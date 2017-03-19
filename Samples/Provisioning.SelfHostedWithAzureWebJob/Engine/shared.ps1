$ProgressPreference = "SilentlyContinue"
$WarningPreference = "SilentlyContinue"
Add-Type -Path $PSScriptRoot\bundle\Microsoft.SharePoint.Client.Taxonomy.dll -ErrorAction SilentlyContinue
Add-Type -Path $PSScriptRoot\bundle\Microsoft.SharePoint.Client.DocumentManagement.dll -ErrorAction SilentlyContinue
Add-Type -Path $PSScriptRoot\bundle\Microsoft.SharePoint.Client.WorkflowServices.dll -ErrorAction SilentlyContinue
Add-Type -Path $PSScriptRoot\bundle\Microsoft.SharePoint.Client.Search.dll -ErrorAction SilentlyContinue

Add-Type -Path $PSScriptRoot\bundle\Newtonsoft.Json.dll -ErrorAction SilentlyContinue
Add-Type -Path $PSScriptRoot\bundle\Microsoft.IdentityModel.Extensions.dll -ErrorAction SilentlyContinue
Import-Module $PSScriptRoot\bundle\SharePointPnPPowerShellOnline.psd1 -ErrorAction SilentlyContinue

Set-PnPTraceLog -Off
#Set-PnPTraceLog -On -Level Debug -LogFile .\pnp.log

$tenantURL = ([environment]::GetEnvironmentVariable("APPSETTING_TenantURL"))
if(!$tenantURL){
    $tenant = ([environment]::GetEnvironmentVariable("APPSETTING_Tenant"))
    $tenantURL = [string]::format("https://{0}.sharepoint.com",$tenant)
}


$fallbackSiteCollectionAdmin = ([environment]::GetEnvironmentVariable("APPSETTING_PrimarySiteCollectionOwnerEmail"))
$siteDirectorySiteUrl = ([environment]::GetEnvironmentVariable("APPSETTING_SiteDirectoryUrl"))
$siteDirectoryList = '/Lists/Sites'
$siteTrainingList = '/Lists/SiteOwnerTrainingList'
$managedPath = 'teams' # sites/teams
$columnPrefix = 'YARA_'
$propBagTemplateInfoStampKey = "_PnP_AppliedTemplateInfo"
$propBagMetadataStampKey = "ProjectMetadata"

$Global:lastContextUrl = ''

$siteMetadataToPersist = @([pscustomobject]@{DisplayName = "-SiteDirectory_BusinessOwner-"; InternalName = "$($columnPrefix)BusinessOwner"},
    [pscustomobject]@{DisplayName = "-SiteDirectory_BusinessUnit-"; InternalName = "$($columnPrefix)BusinessUnit"},
    [pscustomobject]@{DisplayName = "-SiteDirectory_InformationClassification-"; InternalName = "$($columnPrefix)InformationClassification"},   
    [pscustomobject]@{DisplayName = "-SiteDirectory_SiteOwners-"; InternalName = "$($columnPrefix)SiteOwners"}
    [pscustomobject]@{DisplayName = "-SiteDirectory_SiteMembers-"; InternalName = "$($columnPrefix)SiteMembers"}
    [pscustomobject]@{DisplayName = "-SiteDirectory_SiteVisitors-"; InternalName = "$($columnPrefix)SiteVisitors"}
)

#Azure appsettings variables - remove prefix when adding in azure
$appId = ([environment]::GetEnvironmentVariable("APPSETTING_AppId"))
if(!$appId){
    $appId = ([environment]::GetEnvironmentVariable("APPSETTING_ClientId"))
}

$appSecret = ([environment]::GetEnvironmentVariable("APPSETTING_AppSecret"))
if(!$appSecret){
    $appSecret = ([environment]::GetEnvironmentVariable("APPSETTING_ClientSecret"))
}

$uri = [Uri]$tenantURL
$tenantUrl = $uri.Scheme + "://" + $uri.Host
$tenantAdminUrl = $tenantUrl.Replace(".sharepoint", "-admin.sharepoint")


function Connect([string]$Url){    
    if($Url -eq $Global:lastContextUrl){
        return
    }
    if ($appId -ne $null -and $appSecret -ne $null) {
        #Write-Output "Connecting to $Url using AppId $appId" 
        Connect-PnPOnline -Url $Url -AppId $appId -AppSecret $appSecret
    } else {
        #Write-Output "AppId or AppSecret not defined, try connecting using stored credentials" -ForegroundColor Yellow
        Connect-PnPOnline -Url $Url
    }
    $Global:lastContextUrl = $Url
}

function GetMailContent{
    Param(
        [string]$email,
        [string]$mailFile
    )
    $ext = "en";
    if($mail) {
        $ext = $email.Substring($email.LastIndexOf(".")+1)
    }
    $filename = "$PSScriptRoot/resources/$mailFile-mail-$ext.txt"
    if(-not (Test-Path $filename)) {
        $ext = "en"
        $filename = "$PSScriptRoot/resources/$mailFile-mail-$ext.txt"
    }
    return ([IO.File]::ReadAllText($filename)).Split("|")
}

function GetLoginName{
    Param(
        [int]$lookupId
    )
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $web = Get-PnPWeb
    $user = Get-PnPListItem -List $web.SiteUserInfoList -Id $lookupId
    return $user["Name"]    
}

function EnableIRM {
    Param(
        [string]$ownerEmail,
        $classification,
        $siteUrl
    )
        
    $mailHeadBody = GetMailContent -email $ownerEmail -mailFile "irm"

    Connect -Url $siteUrl
    $list = Get-PnPList -Identity '/Shared Documents'    
    $irmEnabled = Get-PnPProperty -ClientObject $list -Property IrmEnabled

    if($classification.Contains("Confidential") -and -not $irmEnabled) {
        #https://blogs.technet.microsoft.com/fromthefield/2015/09/07/office-365-automating-the-configuration-of-information-rights-management-irm-using-csom/
        $list.IrmEnabled = $true
        #Give the Policy a Name and Description
        $list.InformationRightsManagementSettings.PolicyTitle = 'Yara Confidential'
        $list.InformationRightsManagementSettings.PolicyDescription = 'This document is classified as confidential and protected according to Yara International ASA information handling policy.'
        #Configure the Policy Settings
        $list.InformationRightsManagementSettings.AllowPrint = $false
        $list.InformationRightsManagementSettings.AllowScript = $false
        $list.InformationRightsManagementSettings.AllowWriteCopy = $false
        $list.InformationRightsManagementSettings.DisableDocumentBrowserView = $true
        #$list.InformationRightsManagementSettings.DocumentLibraryProtectionExpireDate = #Date
        $list.InformationRightsManagementSettings.DocumentAccessExpireDays = 90
        $list.InformationRightsManagementSettings.EnableDocumentAccessExpire = $false
        #$list.InformationRightsManagementSettings.EnableDocumentBrowserPublishingView = #$true or $false
        $list.InformationRightsManagementSettings.EnableGroupProtection = $false
        $list.InformationRightsManagementSettings.EnableLicenseCacheExpire = $true
        $list.InformationRightsManagementSettings.LicenseCacheExpireDays = 30
        #$list.InformationRightsManagementSettings.GroupName = #Name of group
        $list.Update()
        $list.Context.ExecuteQuery()
        Write-Output "`tEnabling IRM"
        if($ownerEmail) {
            Write-Output "`tSending IRM change to $ownerEmail"        
            Send-PnPMail -To $ownerEmail -Subject ($mailHeadBody[0] -f $siteUrl) -Body ($mailHeadBody[1] -f $siteUrl,"enabled")
        }
    }
    if(-not $classification.Contains("Confidential") -and $irmEnabled) {
        $list.IrmEnabled = $false
        $list.Update()
        $list.Context.ExecuteQuery()
        Write-Output "`tDisabling IRM"
        if($ownerEmail) {
            Write-Output "`tSending IRM change to $ownerEmail"
            Send-PnPMail -To $ownerEmail -Subject ($mailHeadBody[0] -f $siteUrl) -Body ($mailHeadBody[1] -f $siteUrl,"disabled")
        }
    }
}

function SetRequestAccessEmail([string]$url, [string]$ownersEmail) {
    Connect -Url $url
    $emails = Get-PnPRequestAccessEmails
    if($emails -ne $ownersEmail) {
        Write-Output "`tSetting site request e-mail to $ownersEmail"    
        Set-PnPRequestAccessEmails -Emails $ownersEmail
    }
}

function DisableMemberSharing([string]$url){
    Connect -Url $url
    $web = Get-PnPWeb
    $canShare = Get-PnPProperty -ClientObject $web -Property MembersCanShare
    if($canShare) {
        Write-Output "`tDisabling members from sharing"
        $web.MembersCanShare = $false
        $web.Update()
        $web.Context.ExecuteQuery()
        #TODO:
        #https://blogs.msdn.microsoft.com/chandru/2015/12/31/sharepoint-onlinecsom-change-access-requests-settings/ 
        #web.AssociatedMemberGroup.AllowMembersEditMembership = false; 
        #web.AssociatedMemberGroup.Update(); 
    }
}

function CheckDirectReportsOfOwner{
    Param(
        [int]$id
    )
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $siteItem = Get-PnpListItem -List $siteDirectoryList -Id $id -Fields "$($columnPrefix)Compliant","$($columnPrefix)BusinessOwner","$($columnPrefix)NeedForSupport"
    $compliant = $siteItem["$($columnPrefix)Compliant"]
    $businessOwnerAccount = GetLoginName -lookupId ($siteItem["$($columnPrefix)BusinessOwner"] | select -ExpandProperty LookupId)

    $needForSupport = $siteItem["$($columnPrefix)NeedForSupport"]
    Connect -Url $tenantAdminUrl
    $acc = Get-PnPUserProfileProperty -Account $businessOwnerAccount
    $hasDirectReports = $acc.DirectReports.Count -gt 0
    
    if($hasDirectReports -and -not $compliant) {
        Connect -Url "$tenantURL$siteDirectorySiteUrl"
        Write-Output "`tSite is compliant"
        Set-PnPListItem -List $siteDirectoryList -Identity $id -Values @{"$($columnPrefix)Compliant" = $true; "$($columnPrefix)Comment" = ''} -ErrorAction SilentlyContinue >$null 2>&1
    } elseif(-not $hasDirectReports -and -not $needForSupport) {
        Connect -Url "$tenantURL$siteDirectorySiteUrl"
        Write-Output "`tSite is not compliant $businessOwnerAccount has no direct reports"
        Set-PnPListItem -List $siteDirectoryList -Identity $id -Values @{"$($columnPrefix)Compliant" = $false; "$($columnPrefix)Comment" = 'Business owner is not a Yara manager'; "$($columnPrefix)NeedForSupport" = $true } -ErrorAction SilentlyContinue >$null 2>&1
    }
}

function CheckSitePolicy{
    Param(
        [string]$url
    )
    Connect -Url $url
    $policyName = "Delete unconfirmed after 3 months"
    $policy = Get-PnPSitePolicy
    if($policy -eq $null -or $policy.Name -ne $policyName) {
        Write-Output "`tApplying site policy: $policyName"
        Set-PnPSitePolicy -Name $policyName
    }
}

function CreateKeyValueMetadataObject($key, $fieldType, $fieldValue, $fieldInternalName) {
    $value = @{
        'Type' = $fieldType
        'Data' = $fieldValue
        'FieldName' = $fieldInternalName
    }
    $properties = @{
        'Key' = $key
        'Value' = New-Object -TypeName PSObject -Prop $value
    }

    return New-Object -TypeName PSObject -Prop $properties
}

function CreateMetadataPropertyValue($siteItem, $editFormUrl, $siteMetadataToPersist) {
    $metadata = @();
    $siteMetadataToPersist | % {
        $fieldName = $_.InternalName
        $fieldDisplayName = $_.DisplayName
        $fieldValue = $siteItem[$fieldName]
        if($fieldValue -ne $null) {
            $valueType = $fieldValue.GetType().Name
            $valueData = $fieldValue.ToString()
            if ($valueType -eq "FieldUserValue") {
                $valueData = "$($fieldValue.LookupId)|$($fieldValue.LookupValue)|$($fieldValue.Email)"
            } elseif ($valueType -eq "FieldUserValue[]") {
                $valueData = @($fieldValue |% {"$($_.LookupId)|$($_.LookupValue)|$($_.Email)"}) -join "#"
            } elseif ($valueType -eq "FieldUrlValue") {
                $valueData = $fieldValue.Url + "," + $fieldValue.Description
            } elseif ($fieldValue.Label -ne $null) {
                $valueData = $fieldValue.Label
                $valueType = "TaxonomyFieldValue"
            }
            $metadata += (CreateKeyValueMetadataObject -key $fieldDisplayName -fieldType $valueType -fieldValue $valueData -fieldInternalName $fieldName)
        }
    }
    $metadata += (CreateKeyValueMetadataObject -key "-SiteDirectory_ShowProjectInformation-" -fieldType "FieldUrlValue" -fieldValue $editFormUrl -fieldInternalName "NA")

    return ConvertTo-Json $metadata -Compress
}

function SyncMetadata($siteItem, $siteUrl, $urlToDirectory, $title, $description) {
    $itemId =  $siteItem.Id
    $editFormUrl = "$urlToDirectory/EditForm.aspx?ID=$itemId" + "&Source=$siteUrl/SitePages/About.aspx"

    $metadataJson = CreateMetadataPropertyValue -siteItem $siteItem -editFormUrl $editFormUrl -siteMetadataToPersist $siteMetadataToPersist

    Connect -Url $siteUrl
    Write-Output "`tPersisting project metadata to $siteUrl - $metadataJson"
    Set-PnPPropertyBagValue -Key $propBagMetadataStampKey -Value $metadataJson
    if($title -ne $null -and $description -ne $null) {
        Set-PnPWeb -Title $title -Description $description
    }
}

function SyncPermissions{
    Param(
        [string]$url
    )

    Write-Output "`tSyncing owners/members/visitors from site to directory list"
    Connect -Url $url
    $visitorsGroup = Get-PnPGroup -AssociatedVisitorGroup -ErrorAction SilentlyContinue
    $membersGroup = Get-PnPGroup -AssociatedMemberGroup -ErrorAction SilentlyContinue
    $ownersGroup = Get-PnPGroup -AssociatedOwnerGroup -ErrorAction SilentlyContinue

    $visitors = @($visitorsGroup.Users | select -ExpandProperty LoginName)
    $members = @($membersGroup.Users | select -ExpandProperty LoginName)
    $owners = @($ownersGroup.Users | select -ExpandProperty LoginName)

    $metadata = Get-PnPPropertyBag -Key ProjectMetadata | ConvertFrom-Json
    $itemId = [Regex]::Match( ($metadata |? Key -eq '-SiteDirectory_ShowProjectInformation-').Value.Data, 'ID=(?<ID>\d+)').Groups["ID"].Value
    
    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $owners = @($owners -notlike 'SHAREPOINT\system' |% {New-PnPUser -LoginName $_ | select -ExpandProperty ID} | sort) 
    $members = @($members -notlike 'SHAREPOINT\system' |% {New-PnPUser -LoginName $_ | select -ExpandProperty ID} | sort) 
    $visitors = @($visitors -notlike 'SHAREPOINT\system' |% {New-PnPUser -LoginName $_ | select -ExpandProperty ID} | sort) 

    $existingSiteItem = Get-PnPListItem -List $siteDirectoryList -Id $itemId
    $existingOwners = @($existingSiteItem["$($columnPrefix)SiteOwners"] | select -ExpandProperty LookupId | sort)
    $existingMembers = @($existingSiteItem["$($columnPrefix)SiteMembers"] | select -ExpandProperty LookupId | sort)
    $existingVisitors = @($existingSiteItem["$($columnPrefix)SiteVisitors"] | select -ExpandProperty LookupId | sort)

    $diffOwner = Compare-Object -ReferenceObject $owners -DifferenceObject $existingOwners -PassThru
    $diffMember = Compare-Object -ReferenceObject $members -DifferenceObject $existingMembers -PassThru
    $diffVisitor = Compare-Object -ReferenceObject $visitors -DifferenceObject $existingVisitors -PassThru

    if($diffOwner -or $diffMember -or $diffVisitor) {
        $siteItem = Set-PnPListItem -List $siteDirectoryList -Identity $itemId -Values @{"$($columnPrefix)SiteOwners" = $owners; "$($columnPrefix)SiteMembers" = $members; "$($columnPrefix)SiteVisitors" = $visitors}

        $urlToSiteDirectory = "$tenantURL$siteDirectorySiteUrl$siteDirectoryList"
        SyncMetadata -siteItem $siteItem -siteUrl $url -urlToDirectory $urlToSiteDirectory
    }
}

function CheckedPassedTraining() {
    Param(
        [string]$url
    )
    Write-Output "`tChecking that site owners has passed training for $url"
    Connect -Url $url
    $ownersGroup = Get-PnPGroup -AssociatedOwnerGroup -ErrorAction SilentlyContinue
    $owners = @($ownersGroup.Users | select -ExpandProperty LoginName)
    $metadata = Get-PnPPropertyBag -Key ProjectMetadata | ConvertFrom-Json
    $itemId = [Regex]::Match( ($metadata |? Key -eq '-SiteDirectory_ShowProjectInformation-').Value.Data, 'ID=(?<ID>\d+)').Groups["ID"].Value

    Connect -Url "$tenantURL$siteDirectorySiteUrl"
    $ownerIds = @($owners -notlike 'SHAREPOINT\system' |% {New-PnPUser -LoginName $_ | select -ExpandProperty ID})

    $passedTrainingCaml = @"
    <View>
        <Query>
            <Where>
                <And>
                    <Eq>
                        <FieldRef Name="Name" LookupId="True" />
                        <Value Type="Integer">{0}</Value>
                    </Eq>
                    <Eq>
                        <FieldRef Name="Tested" />
                        <Value Type="Text">Passed</Value>
                    </Eq>
                </And>
            </Where>
        </Query>
        <ViewFields>
            <FieldRef Name="ID" />
            <FieldRef Name="Name" />
        </ViewFields>
        <RowLimit>1</RowLimit>
    </View>
"@

    $removeOwners = @()
    foreach($id in $ownerIds) {
        $item = Get-PnPListItem -List $siteTrainingList -Query ($passedTrainingCaml -f $id)
        if($item -eq $null) {
            #not passed
            $i = 0..($ownerIds.length - 1) | ? {$ownerIds[$_] -eq $id}
            $removeOwners += $owners[$i]
        }
    }

    if($removeOwners.Length -gt 0) {
        $ownersString = $removeOwners -join ' '
        Set-PnPListItem -List $siteDirectoryList -Identity $itemId -Values @{"$($columnPrefix)Comment" = "$ownersString did not pass training and have been removed"} -ErrorAction SilentlyContinue >$null 2>&1
    }

    Connect -Url $url
    $ownersGroup = Get-PnPGroup -AssociatedOwnerGroup -ErrorAction SilentlyContinue
    foreach($owner in $removeOwners){
        Write-Output "`tRemoving $owner because he/she has not passed training"
        Remove-PnpUserFromGroup -LoginName $owner -Identity $ownersGroup -ErrorAction SilentlyContinue
    }    
}