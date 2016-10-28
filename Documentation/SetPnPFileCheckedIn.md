#Set-PnPFileCheckedIn
Checks in a file
##Syntax
```powershell
Set-PnPFileCheckedIn [-CheckinType <CheckinType>]
                     [-Comment <String>]
                     [-Web <WebPipeBind>]
                     -Url <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|CheckinType|CheckinType|False||
|Comment|String|False||
|Url|String|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
