#Set-SPOList
Updates list settings
##Syntax
```powershell
Set-SPOList
        -Identity <ListPipeBind>
        [-EnableContentTypes <Boolean>]
        [-BreakRoleInheritance [<SwitchParameter>]]
        [-CopyRoleAssignments [<SwitchParameter>]]
        [-ClearSubscopes [<SwitchParameter>]]
        [-Title <String>]
        [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|BreakRoleInheritance|SwitchParameter|False|If used the security inheritance is broken for this list|
|ClearSubscopes|SwitchParameter|False|If used the unique permissions are cleared from child objects and they can inherit role assignments from this object|
|CopyRoleAssignments|SwitchParameter|False|If used the roles are copied from the parent web|
|EnableContentTypes|Boolean|False|Set to $true to enable content types, set to $false to disable content types|
|Identity|ListPipeBind|True|The ID, Title or Url of the list.|
|Title|String|False|The title of the list|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
Set-SPOList -Identity "Demo List" -EnableContentTypes $true
```
Switches the Enable Content Type switch on the list
