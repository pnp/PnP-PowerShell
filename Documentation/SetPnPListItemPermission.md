# Set-PnPListItemPermission
Sets list item permissions
## Syntax
```powershell
Set-PnPListItemPermission -Identity <ListItemPipeBind>
                          -List <ListPipeBind>
                          [-InheritPermissions [<SwitchParameter>]]
                          [-Web <WebPipeBind>]
```


```powershell
Set-PnPListItemPermission -Group <GroupPipeBind>
                          -Identity <ListItemPipeBind>
                          -List <ListPipeBind>
                          [-AddRole <String>]
                          [-RemoveRole <String>]
                          [-ClearExisting [<SwitchParameter>]]
                          [-Web <WebPipeBind>]
```


```powershell
Set-PnPListItemPermission -User <String>
                          -Identity <ListItemPipeBind>
                          -List <ListPipeBind>
                          [-AddRole <String>]
                          [-RemoveRole <String>]
                          [-ClearExisting [<SwitchParameter>]]
                          [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Group|GroupPipeBind|True||
|Identity|ListItemPipeBind|True|The ID of the listitem, or actual ListItem object|
|List|ListPipeBind|True|The ID, Title or Url of the list.|
|User|String|True||
|AddRole|String|False|The role that must be assigned to the group or user|
|ClearExisting|SwitchParameter|False|Clear all existing permissions|
|InheritPermissions|SwitchParameter|False|Inherit permissions from the list, removing unique permissions|
|RemoveRole|String|False|The role that must be removed from the group or user|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Set-PnPListPermission -List 'Documents' -Identity 1 -User 'user@contoso.com' -AddRole 'Contribute'
```
Adds the 'Contribute' permission to the user 'user@contoso.com' for item with id 1 in the list 'Documents'

### Example 2
```powershell
PS:> Set-PnPListPermission -List 'Documents' -Identity 1 -User 'user@contoso.com' -RemoveRole 'Contribute'
```
Removes the 'Contribute' permission to the user 'user@contoso.com' for item with id 1 in the list 'Documents'

### Example 3
```powershell
PS:> Set-PnPListPermission -List 'Documents' -Identity 1 -User 'user@contoso.com' -AddRole 'Contribute' -ClearExisting
```
Adds the 'Contribute' permission to the user 'user@contoso.com' for item with id 1 in the list 'Documents' and removes all other permissions

### Example 4
```powershell
PS:> Set-PnPListPermission -List 'Documents' -Identity 1 -InheritPermissions
```
Resets permissions for item with id 1 to inherit permissions from the list 'Documents'
