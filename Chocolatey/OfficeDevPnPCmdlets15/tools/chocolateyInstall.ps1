$name = "officedevpnppowershellcommands15"
$url = "https://github.com/OfficeDev/PnP-PowerShell/releases/download/v1.3.1/PnPPowerShellCommands15.msi"
Install-ChocolateyPackage $name 'msi' '/quiet' $url