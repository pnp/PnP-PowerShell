param(
    [switch]$siteClosure,
    [switch]$irm,
    [switch]$sitePolicy,
    [switch]$accessRequestEmail,
    [switch]$verifyBusinessOwner,
    [switch]$memberSharing,
    [switch]$syncPermissions,
    [switch]$passedTraining,
    [switch]$ensureAboutPage
)

. ./shared.ps1

function CheckSiteClosure{
    Param(
        [string]$url
    )
    Connect -Url $url
    $web = Get-PnPWeb
    $lastDate = Get-PnPProperty -ClientObject $web -Property "LastItemModifiedDate"
    if($lastDate -lt [DateTime]::Now.AddYears(-1)) {
        $state = Get-PnPSiteClosure
        if($state -eq 'Open') {
            Write-Output "`tClosing site"
            Set-PnPSiteClosure -State Close     

            $metadata = Get-PnPPropertyBag -Key ProjectMetadata | ConvertFrom-Json
            $businessOwner = ($metadata |? Key -eq '-SiteDirectory_BusinessOwner-').Value.Data
            $businessOwnerEmail = $businessOwner.Split('|')[2]

            $group = Get-PnPGroup |? Title -like '*Owners'
            $ownerEmailAddresses = @($businessOwnerEmail) +  @($group.Users |? {-not [String]::IsNullOrEmpty($_.Email)} | select -ExpandProperty Email)

            #TODO e-mail to businessowner + site owners
        }
    }
}

function CheckIrm{
    Param(
        [string]$url
    )
    Connect -Url $url
    $metadata = Get-PnPPropertyBag -Key ProjectMetadata | ConvertFrom-Json
    $classification = ($metadata |? Key -eq '-SiteDirectory_InformationClassification-').Value.Data
    $businessOwner = ($metadata |? Key -eq '-SiteDirectory_BusinessOwner-').Value.Data
    $businessOwnerEmail = $businessOwner.Split('|')[2]

    EnableIRM -ownerEmail $businessOwnerEmail -classification $classification -siteUrl $url
}

function CheckAccessRequestEmail{
    Param(
        [string]$url
    )
    Connect -Url $url

    $group = Get-PnPGroup |? Title -like '*Owners'
    $ownerEmailAddresses = @($group.Users |? {-not [String]::IsNullOrEmpty($_.Email)} | select -ExpandProperty Email)
    $ownerEmailAddresses = $ownerEmailAddresses | select -uniq | sort
    SetRequestAccessEmail -url $url -ownersEmail ($ownerEmailAddresses -join ',')
}

function CheckBusinessOwner{
    Param(
        [string]$url
    )
    Connect -Url $url
    $metadata = Get-PnPPropertyBag -Key ProjectMetadata | ConvertFrom-Json

    $itemId = [Regex]::Match( ($metadata |? Key -eq '-SiteDirectory_ShowProjectInformation-').Value.Data, 'ID=(?<ID>\d+)').Groups["ID"].Value
    CheckDirectReportsOfOwner -id $itemId
}

function EnsureAboutPage{
    Param(
        [string]$url
    )
    Connect -Url $url

    $site = Get-PnPSite
    $pageUrl = "$(([Uri]$site.Url).AbsolutePath)/SitePages/About.aspx"

    
    $foo = Get-PnPFile -Url $pageUrl -ErrorAction SilentlyContinue
    if($? -eq $false) {
        #re-upload file
        $foo = Add-PnPFile -Path "./resources/About.aspx" -Folder "SitePages"
    }

    EnsureAboutPageNav -url $url -pageUrl $pageUrl
}

function EnsureAboutPageNav{
    Param(
        [string]$url,
        [string]$pageUrl        
    )
    Connect -Url $url
    Write-Output "Checking nav for $url"

    $web = Get-PnPWeb -Includes Navigation.QuickLaunch,Webs
    $ql = $web.Navigation.QuickLaunch

    $hasNode = $ql |? Url -like $pageUrl
    if(-not $hasNode) {
        Write-Output "`tAdding About Page navigation to $url"
        Add-PnPNavigationNode -Location QuickLaunch -Title "About Site" -Url $pageUrl
    }

    $web.Webs |% { EnsureAboutPageNav -url $_.Url -pageUrl $pageUrl }
}

Write-Output @"
  ___  ___       _____                                                
  |  \/  |      |  __ \                                               
  | .  . |_ __  | |  \/ _____   _____ _ __ _ __   __ _ _ __   ___ ___ 
  | |\/| | '__| | | __ / _ \ \ / / _ \ '__| '_ \ / _`` | '_ \ / __/ _ \
  | |  | | |_   | |_\ \ (_) \ V /  __/ |  | | | | (_| | | | | (_|  __/
  \_|  |_/_(_)   \____/\___/ \_/ \___|_|  |_| |_|\__,_|_| |_|\___\___|
                                                         by Puzzlepart
  Code by: @mikaelsvenson

"@

Connect -Url "$tenantURL$siteDirectorySiteUrl"

$teamSiteFilter = "$tenantUrl/$managedPath/"
$sites = Get-PnPSiteSearchQueryResults -All -Query "path:$teamSiteFilter"

foreach ($site in $sites) {
    $url = $site.Url
    Write-Output "Processing $url"
    if($sitePolicy) {
        CheckSitePolicy -url $url
    }

    if($siteClosure) {
        CheckSiteClosure -url $url
    }

    if($irm) {
        CheckIrm -url $url
    }

    if($accessRequestEmail) {
        CheckAccessRequestEmail -url $url
    }

    if($verifyBusinessOwner) {
        CheckBusinessOwner -url $url
    }

    if($memberSharing) {
        DisableMemberSharing -url $url
    }

    if($passedTraining) {
        CheckedPassedTraining -url $url
    }  

    if($syncPermissions) {
        SyncPermissions -url $url
    }

    if($ensureAboutPage) {
        EnsureAboutPage -url $url
    }    
}

Disconnect-PnPOnline