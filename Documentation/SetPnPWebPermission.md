# Set-PnPWebPermission
Sets web permissions
## Syntax
```powershell
Set-PnPWebPermission -Group <GroupPipeBind>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


```powershell
Set-PnPWebPermission -User <String>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


```powershell
Set-PnPWebPermission -Identity <WebPipeBind>
                     -Group <GroupPipeBind>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


```powershell
Set-PnPWebPermission -Identity <WebPipeBind>
                     -User <String>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


```powershell
Set-PnPWebPermission -Url <String>
                     -Group <GroupPipeBind>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


```powershell
Set-PnPWebPermission -Url <String>
                     -User <String>
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Group|GroupPipeBind|True||
|Identity|WebPipeBind|True|Identity/Id/Web object|
|Url|String|True|The site relative url of the web, e.g. 'Subweb1'|
|User|String|True||
|AddRole|String[]|False|The role that must be assigned to the group or user|
|RemoveRole|String[]|False|The role that must be removed from the group or user|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Set-PnPWebPermission -Url projectA -User 'user@contoso.com' -AddRole 'Contribute'
```
Adds the 'Contribute' permission to the user 'user@contoso.com' for a web, specified by its site relative url

### Example 2
```powershell
PS:> Set-PnPWebPermission -Identity 5fecaf67-6b9e-4691-a0ff-518fc9839aa0 -User 'user@contoso.com' -RemoveRole 'Contribute'
```
Removes the 'Contribute' permission to the user 'user@contoso.com' for a web, specified by its ID
