# Uninstall-PnPApp
Uninstalls an available add-in from the site
## Syntax
```powershell
Uninstall-PnPApp -Identity <AppMetadataPipeBind>
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|AppMetadataPipeBind|True|Specifies the Id of the Addin Instance|
## Examples

### Example 1
```powershell
PS:> Uninstall-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```
This will uninstall the specified app from the current site.
