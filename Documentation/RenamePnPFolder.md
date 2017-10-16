# Rename-PnPFolder
Renames a folder
## Syntax
```powershell
Rename-PnPFolder -Folder <String>
                 -TargetFolderName <String>
                 [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Folder|String|True|The folder to rename|
|TargetFolderName|String|True|The new folder name|
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Rename-PnPFolder -Folder Documents/Reports -TargetFolderName 'Archived Reports'
```
This will rename the folder Reports in the Documents library to 'Archived Reports'
