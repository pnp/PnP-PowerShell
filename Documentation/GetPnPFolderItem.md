#Get-PnPFolderItem
List content in folder
##Syntax
```powershell
Get-PnPFolderItem [-FolderSiteRelativeUrl <String>]
                  [-ItemType <String>]
                  [-ItemName <String>]
                  [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|FolderSiteRelativeUrl|String|False||
|ItemName|String|False||
|ItemType|String|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
