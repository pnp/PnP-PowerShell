# Get-PnPAppAuthAccessToken
Returns the access token from the current client context (In App authentication mode only)
## Syntax
```powershell
Get-PnPAppAuthAccessToken [-Web <WebPipeBind>]
```


## Returns
>[System.String](https://msdn.microsoft.com/en-us/library/system.string.aspx)

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> $accessToken = Get-PnPAppAuthAccessToken
```
This will put the access token from current context in the $accessToken variable. Will only work in App authentication flow (App+user or App-Only)
