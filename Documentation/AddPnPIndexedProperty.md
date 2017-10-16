# Add-PnPIndexedProperty
Marks the value of the propertybag key specified to be indexed by search.
## Syntax
```powershell
Add-PnPIndexedProperty -Key <String>
                       [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Key|String|True|Key of the property bag value to be indexed|
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
