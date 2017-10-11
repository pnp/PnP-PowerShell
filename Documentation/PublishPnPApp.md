# Publish-PnPApp
Publishes/Deploys/Trusts an available app in the app catalog
>*Only available for SharePoint Online*
## Syntax
```powershell
Publish-PnPApp -Identity <AppMetadataPipeBind>
               [-SkipFeatureDeployment [<SwitchParameter>]]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|AppMetadataPipeBind|True|Specifies the Id of the app|
|SkipFeatureDeployment|SwitchParameter|False||
## Examples

### Example 1
```powershell
PS:> Publish-PnPApp
```
This will deploy/trust an app into the app catalog. Notice that the app needs to be available in the app catalog
