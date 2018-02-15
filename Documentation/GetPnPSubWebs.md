# Get-PnPSubWebs
Returns the subwebs of the current web
## Syntax
```powershell
Get-PnPSubWebs [-Recurse [<SwitchParameter>]]
               [-Web <WebPipeBind>]
               [-Includes <String[]>]
               [-Identity <WebPipeBind>]
```


## Returns
>[Microsoft.SharePoint.Client.WebCollection](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.web.aspx)

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|WebPipeBind|False||
|Includes|String[]|False|Specify properties to include when retrieving objects from the server.|
|Recurse|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
