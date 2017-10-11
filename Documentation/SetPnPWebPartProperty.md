# Set-PnPWebPartProperty
Sets a web part property
## Syntax
```powershell
Set-PnPWebPartProperty -ServerRelativePageUrl <String>
                       -Identity <GuidPipeBind>
                       -Key <String>
                       -Value <PSObject>
                       [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GuidPipeBind|True||
|Key|String|True||
|ServerRelativePageUrl|String|True||
|Value|PSObject|True||
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
