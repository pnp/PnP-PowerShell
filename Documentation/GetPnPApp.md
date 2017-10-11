# Get-PnPApp
Returns the available apps from the app catalog
>*Only available for SharePoint Online*
## Syntax
```powershell
Get-PnPApp [-Identity <GuidPipeBind>]
```


## Returns
>List<OfficeDevPnP.Core.ALM.AppMetadata>

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GuidPipeBind|False|Specifies the Id of an app which is available in the app catalog|
## Examples

### Example 1
```powershell
PS:> Get-PnPAvailableApp
```
This will return all available app metadata from the tenant app catalog. It will list the installed version in the current site.

### Example 2
```powershell
PS:> Get-PnPAvailableApp -Identity 2646ccc3-6a2b-46ef-9273-81411cbbb60f
```
This will the specific app metadata from the app catalog.
