# Get-PnPDefaultColumnValues
Gets the default column values for all folders in document library
## Syntax
```powershell
Get-PnPDefaultColumnValues -List <ListPipeBind>
                           [-Web <WebPipeBind>]
```


## Detailed Description
Gets the default column values for a document library, per folder. Supports both text, people and taxonomy fields.

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|List|ListPipeBind|True|The ID, Name or Url of the list.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
