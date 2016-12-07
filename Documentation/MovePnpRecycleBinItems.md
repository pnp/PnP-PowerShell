#Move-PnpRecycleBinItems
Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin
##Syntax
```powershell
Move-PnpRecycleBinItems [-Force [<SwitchParameter>]]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|If provided, no confirmation will be asked to move the first stage recycle bin items to the second stage|
##Examples

###Example 1
```powershell
PS:> Move-PnpRecycleBinItems
```
Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin

###Example 2
```powershell
PS:> Move-PnpRecycleBinItems -Force
```
Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin without asking for confirmation first
