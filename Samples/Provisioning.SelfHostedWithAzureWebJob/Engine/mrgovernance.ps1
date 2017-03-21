param(
    [switch]$syncPermissions
)

. ./shared.ps1

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

#TODO get siteitem id
$res = Submit-PnPSearchQuery -Query 'spcontenttype="team site"' -All -SelectProperties "PZLSiteURLOWSURLH"
$sites = @($res.ResultRows |% { $_["PZLSiteURLOWSURLH"] } |? {$_})

foreach($site in $sites){
    $url = $site.split(',')[0]
    Write-Output "Processing $url"

    if($syncPermissions) {
        SyncPermissions -url $url
    }
}

Disconnect-PnPOnline