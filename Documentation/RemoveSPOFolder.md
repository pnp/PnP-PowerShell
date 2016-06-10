#Remove-SPOFolder
Deletes a folder within a parent folder
##Syntax
```powershell
Remove-SPOFolder -Name <String> -Folder <String> [-Force [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Folder|String|True|The parent folder in the site|
|Force|SwitchParameter|False||
|Name|String|True|The folder name|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOFolder -Name NewFolder -Folder _catalogs/masterpage/newfolder
```

