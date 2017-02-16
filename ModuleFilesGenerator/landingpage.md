# PnP PowerShell overview

SharePoint Patterns and Practices (PnP) contains a library of PowerShell commands (PnP PowerShell) that allows you to perform complex provisioning and artifact management actions towards SharePoint. The commands use CSOM and can work against both SharePoint Online as SharePoint On-Premises.

![SharePoint Patterns and Practices](https://devofficecdn.azureedge.net/media/Default/PnP/sppnp.png)

_**Applies to:** SharePoint Online | SharePoint 2016 | SharePoint 2013_


## INSTALLATION #

### Setup files ##
You can download setup files from https://github.com/officedev/pnp-powershell/releases. These files will up be updated on a monthly basis.

### Using the Windows Management Framework ##

If you main OS is Windows 10, you can run the following commands to install the PowerShell cmdlets:

_SharePoint Online_
```powershell
Install-Module SharePointPnPPowerShellOnline -AllowClobber
```

_SharePoint 2016_
```powershell
Install-Module SharePointPnPPowerShell2016 -AllowClobber
```

_SharePoint 2013_
```powershell
Install-Module SharePointPnPPowerShell2013 -AllowClobber
```

*Notice*: if you installed the latest PowerShellGet from Github, you might receive an error message stating 
>PackageManagement\Install-Package : The version '2.8.x.x' of the module 'SharePointPnPPowerShellOnline' being installed is not catalog signed.

In order to install the cmdlets when you get this error specify the -SkipPublisherCheck switch with the Install-Module cmdlet, e.g. ```Install-Module SharePointPnPPowerShellOnline -SkipPublisherCheck -AllowClobber

Alternatively for installation on machines that have at least PowerShell v3 installed (you can find this out by opening PowerShell and running ```$PSVersionTable.PSVersion```. The value for ```Major``` should be above 3) you can run the below command which will install PowerShell Package Management and then install the PowerShell Modules from the PowerShell Gallery

```powershell
Invoke-Expression (New-Object Net.WebClient).DownloadString('https://raw.githubusercontent.com/OfficeDev/PnP-PowerShell/master/Samples/Modules.Install/Install-SharePointPnPPowerShell.ps1')
```

If you wish to see the commands that the above will run please see the files as stored in the below locations:
* https://raw.githubusercontent.com/OfficeDev/PnP-PowerShell/master/Samples/Modules.Install/Install-PowerShellPackageMangement.ps1
* https://raw.githubusercontent.com/OfficeDev/PnP-PowerShell/master/Samples/Modules.Install/Install-SharePointPnPPowerShellHelperModule.ps1

Once the above has been completed you can then start to use the PowerShell Modules

Once new releases of the module are made available on the PowerShell Gallery you will be able to use the the following command to install the latest updated version

```powershell
Update-Module SharePointPnPPowerShell*
``` 

This will automatically load the module after starting PowerShell 3.0.

You can check the installed PnP-PowerShell versions with the following command:

```powershell
Get-Module SharePointPnPPowerShell* -ListAvailable | Select-Object Name,Version | Sort-Object Version -Descending
```

### HOW TO USE DURING DEVELOPMENT ##

A build script will copy the required files to a folder in your users folder, called:
*C:\Users\\\<YourUserName\>\Documents\WindowsPowerShell\Modules\SharePointPnPPowerShell\<Platform\>*

## GETTING STARTED #

To use the library you first need to connect to your tenant:

```powershell
Connect-PnPOnline –Url https://yoursite.sharepoint.com –Credentials (Get-Credential)
```

To view all cmdlets, enter

```powershell
Get-Command -Module *PnP*
```

At the following links you will find a few videos on how to get started with the cmdlets:

* https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Web-Cast-Introduction-to-Office-365-PnP-PowerShell
* https://channel9.msdn.com/blogs/OfficeDevPnP/Introduction-to-PnP-PowerShell-Cmdlets
* https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Webcast-PnP-PowerShell-Getting-started-with-latest-updates

### SETTINGS UP CREDENTIALS ##
See this [wiki page](https://github.com/OfficeDev/PnP-PowerShell/wiki/How-to-use-the-Windows-Credential-Manager-to-ease-authentication-with-PnP-PowerShell) for more information on how to use the Windows Credential Manager to setup credentials that you can use in unattended scripts

## Cmdlet overview
---cmdletdata---

## Additional resources
<a name="bk_addresources"> </a>

-  [SharePoint PnP PowerShell on GitHub](https://github.com/SharePoint/PnP-PowerShell)
