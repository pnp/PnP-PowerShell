# Get-PnPSiteClosure
Get the site closure status of the site which has a site policy applied
## Syntax
```powershell
Get-PnPSiteClosure [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Get-PnPSiteClosure
```
Get the site closure status of the site.
