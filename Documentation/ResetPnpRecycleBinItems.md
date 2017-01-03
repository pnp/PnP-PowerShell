#Reset-PnpRecycleBinItems
Restores all the items from the first and second stage recycle bin of the current context to their original locations
##Syntax
```powershell
Reset-PnpRecycleBinItems [-Force [<SwitchParameter>]]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|If provided, no confirmation will be asked to restore all the files from the first and second stage recycle bins to their original locations|
##Examples

###Example 1
```powershell
PS:> Reset-PnpRecycleBinItems
```
Restores all the items from the first and second stage recycle bin of the current context to their original locations

###Example 2
```powershell
PS:> Reset-PnpRecycleBinItems -Force
```
Restores all the items from the first and second stage recycle bin of the current context to their original locations without asking for confirmation first
