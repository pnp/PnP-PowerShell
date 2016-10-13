#Remove-SPOTermGroup
Removes a taxonomy term group and all its containing termsets
##Syntax
```powershell
Remove-SPOTermGroup
        [-TermStoreName <String>]
        [-Force [<SwitchParameter>]]
        -GroupName <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False||
|GroupName|String|True|Name of the taxonomy term group to delete.|
|TermStoreName|String|False|Term store to use; if not specified the default term store is used.|
