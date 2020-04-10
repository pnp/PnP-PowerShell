Function Install-SharePointPnPPowerShellModule {
<#
.Synopsis
   This Function will Check and see if the Office365DevPNP PowerShellModules are installed on your system and if not will use PowerShell Package Management to install them
.DESCRIPTION
   This verifies if the NuGet package provider is available on your environment and if not, will install it
.EXAMPLE
    Install-SharePointPnPPowerShellModule -ModuleToInstall Online
.EXAMPLE
    Install-SharePointPnPPowerShellModule -ModuleToInstall SP2019
.EXAMPLE
    Install-SharePointPnPPowerShellModule -ModuleToInstall SP2016
.EXAMPLE
    Install-SharePointPnPPowerShellModule -ModuleToInstall SP2013
   #>
#Requires -Version 3.0
#Requires -Modules PowerShellGet
param (
        [Parameter(Mandatory=$true,HelpMessage='Online is for SharePoint Online, SP2013 for SharePoint 2013, SP2016 for SharePoint 2016 and SP2019 for SharePoint 2019')]
        [ValidateSet('Online','SP2013','SP2016','SP2019')]
        [string] $ModuleToInstall   
       )
       

       switch ($ModuleToInstall)
       {
            'Online' { 
                $moduleVersion = 'SharePoint Online'
                $moduleName = 'SharePointPnPPowerShellOnline'
                }
            'SP2013' {
                $moduleVersion = 'SharePoint 2013'
                $moduleName = 'SharePointPnPPowerShell2013'
            }
            'SP2016' {
                $moduleVersion = 'SharePoint 2016'
                $moduleName = 'SharePointPnPPowerShell2016'
            }
	    'SP2019' {
                $moduleVersion = 'SharePoint 2019'
                $moduleName = 'SharePointPnPPowerShell2019'
            }
       }

       if (!(Get-command -Module $moduleName).count -gt 0)
       {
           Install-Module -Name $moduleName -Force -SkipPublisherCheck
       }

       Write-Output -InputObject "The modules for $moduleVersion have been installed and can now be used"
       Write-Output -InputObject 'On the next release you can just run Update-Module SharePointPnPPowerShell* -Force to update these modules'
}

function Request-SPOOrOnPremises
{
    [string]$title="Confirm"
    [string]$message="Which version of the PnP PowerShell Module do you want to install?"
    
	$SPO = New-Object -TypeName System.Management.Automation.Host.ChoiceDescription -ArgumentList "SharePoint &Online", "SharePoint Online"
	$SP2019 = New-Object -TypeName System.Management.Automation.Host.ChoiceDescription -ArgumentList "SharePoint 201&9", "SharePoint 2019"
    	$SP2016 = New-Object -TypeName System.Management.Automation.Host.ChoiceDescription -ArgumentList "SharePoint 201&6", "SharePoint 2016"
	$SP2013 = New-Object -TypeName System.Management.Automation.Host.ChoiceDescription -ArgumentList "SharePoint 201&3", "SharePoint 2013"
	$options = [System.Management.Automation.Host.ChoiceDescription[]]($SPO, $SP2019, $SP2016, $SP2013)

	$result = $host.ui.PromptForChoice($title, $message, $options, 0)

	switch ($result)
	{
        3 { Return 'SP2013'}
		2 { Return 'SP2016' } 
		1 { Return 'SP2019' } 
		0 { Return 'Online' }
	}
}

if ((Get-command -Module PowerShellGet).count -eq 0) 
{ 
	Write-Output -InputObject "NuGet package provider is not available on this machine, trying to install it now"
	Install-PackageProvider -Name NuGet -Force
}
else
{
    Write-Output -InputObject 'NuGet package provider is available, we will now run the next command in 10 seconds'
    Start-Sleep -Seconds 10 
    Install-SharePointPnPPowerShellModule -ModuleToInstall (Request-SPOOrOnPremises)
}