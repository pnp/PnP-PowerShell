#Remove-SPOGroup
*Topic automatically generated on: 2015-09-17*

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

<!-- Ref: 57137694056FA802D6C4B1DFD8AB9BD1 -->