# Add-PnPApp
Add/uploads an available app to the app catalog
>*Only available for SharePoint Online*
## Syntax
```powershell
Add-PnPApp -Path <String>
```


## Returns
>OfficeDevPnP.Core.ALM.AppMetadata

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Path|String|True|Specifies the Id or an actual app metadata instance|
## Examples

### Example 1
```powershell
PS:> Add-PnPApp -Path ./myapp.sppkg
```
This will upload the specified app package to the app catalog
