$name = "officedevpnppowershellcommands16"
$url = "https://github.com/OfficeDev/PnP-PowerShell/releases/download/v1.3.2/PnPPowerShellCommands16.msi"
Install-ChocolateyPackage $name 'msi' '/quiet' $url