# OfficeDevPnP.PowerShell Commands #

### Summary ###
This solution shows how you can build a library of PowerShell commands that act towards SharePoint Online. The commands use CSOM and can work against both SharePoint Online as SharePoint On-Premises.

### Applies to ###
-  Office 365 Multi Tenant (MT)
-  Office 365 Dedicated (D)
-  SharePoint 2013 on-premises

### Prerequisites ###
In order to build the setup project the WiX toolset needs to be installed. You can obtain this from http://wix.codeplex.com. If you use Visual Studio 2015 you will need at least WiX 3.10, which can be downloaded from here: http://wixtoolset.org/releases/

In order to generate the generate the Cmdlet help you need Windows Management Framework v4.0 which you can download from http://www.microsoft.com/en-us/download/details.aspx?id=40855

### Solution ###
Solution | Author(s)
---------|----------
OfficeDevPnP.PowerShell | Erwin van Hunen

### Disclaimer ###
**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**


----------

# HOW TO USE AGAINST OFFICE 365 #
A build script will copy the required files to a folder in your users folder, called:
*C:\Users\<YourUserName>\Documents\WindowsPowerShell\Modules\OfficeDevPnP.PowerShell.Commands*

Alternatively for installation on machines that have at least PowerShell v3 installed (you can find this out by opening PowerShell and running $host.version and Major should be above 3) you can run the below command which will install PowerShell Package Management and then install the PowerShell Modules from the PowerShell Gallery
```powershell
Invoke-Expression (New-Object Net.WebClient).DownloadString('http://bit.ly/InstallO365PnPPowerShell')
```

If you wish to see the commands that the above will run please see the files as stored in the below locations
http://bit.ly/PSPackManInstall
http://bit.ly/ODevPnPPowerShellHelper1

If you however already have PackageManagement installed you can just run the below

```powershell
Install-Module OfficeDevPnP.PowerShell.V16.Commands
```

For the SharePoint Online Module

or

```powershell
Install-Module OfficeDevPnP.PowerShell.V15.Commands
```

For the SharePoint On-Premises Modules

Once the above has been completed you can then start to use the PowerShell Modules

Once new releases of the module are made available on the PowerShell Gallery you will be able to use the the following command to install the latest updated version
```powershell
Update-Module
``` 

This will automatically load the module after starting PowerShell 3.0.
To use the library you first need to connect to your tenant:

```powershell
Connect-SPOnline –Url https://yoursite.sharepoint.com –Credentials (Get-Credential)
```

In case of an unattended script you might want to add a new entry in your credential manager of windows. 

![](http://i.imgur.com/6NiMaFL.png)
 
Select Windows Credentials and add a new *generic* credential:

![](http://i.imgur.com/rhtgL1U.png)
 
Now you can use this entry to connect to your tenant as follows:

```powershell
Connect-SPOnline –Url https://yoursite.sharepoint.com –Credentials yourlabel
```

## Commands ##
[Navigate here for an overview of all cmdlets and their parameters:](Documentation/readme.md)
