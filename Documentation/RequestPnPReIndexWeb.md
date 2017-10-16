# Request-PnPReIndexWeb
Marks the web for full indexing during the next incremental crawl
## Syntax
```powershell
Request-PnPReIndexWeb [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
