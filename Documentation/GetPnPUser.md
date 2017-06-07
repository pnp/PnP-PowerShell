# Get-PnPUser
Returns site users of current web
## Syntax
```powershell
Get-PnPUser [-Web <WebPipeBind>]
            [-Identity <UserPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|UserPipeBind|False|User ID or login name|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
