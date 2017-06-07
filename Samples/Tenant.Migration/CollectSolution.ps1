<#

.SYNOPSIS
This is a generic version of a script that collects all artefacts from a SharePoint site collection or site collections.

.DESCRIPTION
This script can be used to collect all artefacts from a site resulting in a full solution package that can be applied
to a different site or set of sites.

.EXAMPLE
./CollectSolution.ps1 "Dev"


.EXAMPLE
./CollectSolution.ps1 

.NOTES
There are no parameters for this script. All configuration elements are stored in the config.xml.

.PARAMETER Environment
Select the environment to export the solution from as specified in the config.xml

#>

Param(
  [string]$Environment
)

begin
{
	Clear-Host

	$path = Split-Path -parent $MyInvocation.MyCommand.Definition

	if ($env:PSModulePath -notlike "*$path\Modules\TriadModules\Modules*")
	{
		"Adding ;$path\Modules\TriadModules\Modules to PSModulePath" | Write-Debug
		$env:PSModulePath += ";$path\Modules\TriadModules\Modules"
	}

	$config = [xml](Get-Content $path/config.xml -ErrorAction Stop)

	$defaultSourceEnvironment = "Dev" # only run exports from the Environment named Dev in the config.xml

    if ($Environment -eq $null -or $Environment -eq "")
    {
        $SourceEnvironment = $defaultSourceEnvironment
    } else
    {
        $SourceEnvironment = $Environment
    }

}

process
{
    Get-TMPnPTemplatesForSiteCollections -TemplatePath $path -Configuration $config.OuterXml -Environment $SourceEnvironment	
}

end
{
    "Completed export!" | Write-Debug
}