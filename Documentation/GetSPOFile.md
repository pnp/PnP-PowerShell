#Get-SPOFile
Downloads a file.
##Syntax
```powershell
Get-SPOFile [-Path <String>]
            [-Filename <String>]
            [-AsString [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            -ServerRelativeUrl <String>
```


```powershell
Get-SPOFile [-Path <String>]
            [-Filename <String>]
            [-AsString [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            -SiteRelativeUrl <String>
```


##Returns
```[Microsoft.SharePoint.Client.File](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.file.aspx)```

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|AsString|SwitchParameter|False||
|Filename|String|False||
|Path|String|False||
|ServerRelativeUrl|String|True||
|SiteRelativeUrl|String|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor
```
Downloads the file and saves it to the current folder

###Example 2
```powershell
PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor
```
Downloads the file and saves it to c:\temp\company.spcolor

###Example 3
```powershell
PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor -AsString
```
Downloads the file and outputs its contents to the console

###Example 4
```powershell
PS:> Get-SPOFile -SiteRelativeUrl _catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor
```
Refers to the file by site relative URL, downloads the file and saves it to c:\temp\company.spcolor
