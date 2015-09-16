#Remove-SPOUserFromGroup
*Topic automatically generated on: 2015-09-17*

Removes a user from a group
##Syntax
```powershell
Remove-SPOUserFromGroup -LoginName <String> -Identity <GroupPipeBind> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GroupPipeBind|True|A group object, an ID or a name of a group|
|LoginName|String|True|A valid login name of a user|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOUserFromGroup -LoginName user@company.com -GroupName 'Marketing Site Members'
```

<!-- Ref: 2A7AE38C1FF2B8E342B719C932F1B7BB -->