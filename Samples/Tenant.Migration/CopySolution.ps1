<#

.SYNOPSIS
This is a generic version of a script that takes all templates form one sit ecollection and copies it to anothr site collection

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

	$path = Split-Path -parent $MyInvocation.MyCommand.Definition
    if ($env:PSModulePath -notlike "*$path\Modules\TriadModules\Modules*")
	{
	    "Adding ;$path\Modules\TriadModules\Modules to PSModulePath" | Write-Debug
		$env:PSModulePath += ";$path\Modules\TriadModules\Modules"
	}

	$config = [xml](Get-Content $path/config.xml -ErrorAction Stop)

    $defaultSourceEnvironment = "Dev" # only run exports from the Environment named Dev in the config.xml
	$defaultDestinationEnvironment = "Uat" # apply to the environment names Dev Test in the config.xml, this can be chnaged if needed


    if ($SourceEnvironment -eq $null)
    {
        $SourceEnvironment = $defaultSourceEnvironment
    } 

    if ($DestinationEnvironment -eq $null)
    {
        $DestinationEnvironment = $defaultDestinationEnvironment
    }

}

process
{		
	Get-TMPnPTemplatesForSiteCollection -Configuration $config.OuterXml -Environment $SourceEnvironment	
	Add-TMPnPTemplatesForSiteCollection -Configuration $config.OuterXml -SourceEnvironment $SourceEnvironment	-DestinationEnvironment $DestinationEnvironment	
}

end
{
    "Completed import!" | Write-Debug
}


