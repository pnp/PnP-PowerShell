param($ProjectDir, $ConfigurationName, $TargetDir, $TargetFileName, $SolutionDir)

if($ConfigurationName -like "Debug*")
{
	$documentsFolder = [environment]::getfolderpath("mydocuments");
	if($ConfigurationName -like "Debug15")
	{
		
		$DestinationFolder = "$documentsFolder\WindowsPowerShell\Modules\SharePointPnPPowerShellSP2013"
	} elseif($ConfigurationName -like "Debug16")
	{
		$DestinationFolder = "$documentsFolder\WindowsPowerShell\Modules\SharePointPnPPowerShellSP2016"
	} else {
		$DestinationFolder = "$documentsFolder\WindowsPowerShell\Modules\SharePointPnPPowerShellOnline"
	}
	
	# Module folder there?
	if(Test-Path $DestinationFolder)
	{
		# Yes, empty it
		Remove-Item $DestinationFolder\*
	} else {
		# No, create it
		Write-Host "Creating target folder: $PSModuleHome"
		New-Item -Path $PSModuleHome -ItemType Directory -Force >$null # Suppress output
	}

	Write-Host "Copying files from $TargetDir to $DestinationFolder"
	Copy-Item "$TargetDir\*.dll" -Destination "$DestinationFolder"
	Copy-Item "$TargetDir\*help.xml" -Destination "$DestinationFolder"
	if($ConfigurationName -like "Debug15")
	{
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPPowerShellSP2013.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.SP2013.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	} elseif($ConfigurationName -like "Debug16")
	{
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPSPowerShellP2016.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.SP2016.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	} else {
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPPowerShellOnline.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.Online.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	}
} elseif ($ConfigurationName -like "Release*")
{
    $documentsFolder = [environment]::getfolderpath("mydocuments");

	if($ConfigurationName -like "Release15")
	{
		$DestinationFolder = "$documentsFolder\WindowsPowerShell\Modules\SharePointPnP.PowerShell.V15.Commands"
	} else {
		$DestinationFolder = "$documentsFolder\WindowsPowerShell\Modules\SharePointPnP.PowerShell.V16.Commands"
	}
	# Module folder there?
	if(Test-Path $DestinationFolder)
	{
		# Yes, empty it
		Remove-Item $DestinationFolder\*
	} else {
		# No, create it
		New-Item -Path $DestinationFolder -ItemType Directory -Force >$null # Suppress output
	}

	Write-Host "Copying files from $TargetDir to $DestinationFolder"
	Copy-Item "$TargetDir\*.dll" -Destination "$DestinationFolder"
	Copy-Item "$TargetDir\*help.xml" -Destination "$DestinationFolder"
	if($ConfigurationName -like "Release15")
	{
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPPowerShellSP2013.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.SP2013.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	} elseif($ConfigurationName -like "Release16")
	{
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPPowerShellSP2016.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.SP2016.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	} else {
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnPPowerShellOnline.psd1" -Destination  "$DestinationFolder"
		Copy-Item "$TargetDir\ModuleFiles\SharePointPnP.PowerShell.Online.Commands.Format.ps1xml" -Destination "$DestinationFolder"
	}
}

	