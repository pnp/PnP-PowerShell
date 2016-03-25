#Remove-SPOGroup
Removes a group.
##Syntax
```powershell
Remove-SPOGroup [-Force [<SwitchParameter>]] [-Web <WebPipeBind>] [-Identity <GroupPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False||
|Identity|GroupPipeBind|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOGroup -Identity "My Users"
```

