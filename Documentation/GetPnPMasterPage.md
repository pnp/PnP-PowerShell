# Get-PnPMasterPage
Returns the URLs of the default Master Page and the custom Master Page.
## Syntax
```powershell
Get-PnPMasterPage [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
