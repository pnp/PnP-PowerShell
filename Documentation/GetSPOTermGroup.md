#Get-SPOTermGroup
Returns a taxonomy term group
##Syntax
```powershell
Get-SPOTermGroup [-TermStoreName <String>]
                 -GroupName <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|GroupName|String|True|Name of the taxonomy term group to retrieve.|
|TermStoreName|String|False|Term store to check; if not specified the default term store is used.|
