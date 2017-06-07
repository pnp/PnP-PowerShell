<#

.SYNOPSIS
This is a generic version of a script that applies all Artefacts from a SharePoint site or site collections to a new site.

.DESCRIPTION
This script can be used to apply all artefacts from a full solution package that has been created by Collect Solution

.EXAMPLE
./CollectSolution.ps1

.PARAMETER SourceEnvironment
Select the environment to export the solution from as specified in the config.xml

.PARAMETER DestinationEnvironment
Select the environment to export the solution from as specified in the config.xml

#>

Param(
  [string]$SourceEnvironment,
  [string]$DestinationEnvironment
)



begin
{
	Clear-Host

	
}

process
{		
    $path = Split-Path -parent $MyInvocation.MyCommand.Definition
    if ($env:PSModulePath -notlike "*$path\Modules\TriadModules\Modules*")
	{
	    "Adding ;$path\Modules\TriadModules\Modules to PSModulePath" | Write-Debug
		$env:PSModulePath += ";$path\Modules\TriadModules\Modules"
	}

	$config = [xml](Get-Content $path/config.xml -ErrorAction Stop)

    $defaultSourceEnvironment = "Dev" # only run exports from the Environment named Dev in the config.xml
	$defaultDestinationEnvironment = "Uat" # apply to the environment names Dev Test in the config.xml, this can be chnaged if needed

    if ($SourceEnvironment -eq $null -or $SourceEnvironment -eq "")
    {
        $SourceEnvironment = $defaultSourceEnvironment
    } 

    if ($DestinationEnvironment -eq $null -or $DestinationEnvironment -eq "")
    {
        $DestinationEnvironment = $defaultDestinationEnvironment
    }

	Add-TMPnPTemplatesForSiteCollections -TemplatePath $path -Configuration $config.OuterXml -SourceEnvironment $SourceEnvironment	-DestinationEnvironment $DestinationEnvironment	
}

end
{
    "Completed import!" | Write-Debug
}


