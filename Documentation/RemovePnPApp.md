# Remove-PnPApp
Removes an app from the app catalog
>*Only available for SharePoint Online*
## Syntax
```powershell
Remove-PnPApp -Identity <AppMetadataPipeBind>
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|AppMetadataPipeBind|True|Specifies the Id of the Addin Instance|
## Examples

### Example 1
```powershell
PS:> Remove-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```
This will remove the specified app from the app catalog
