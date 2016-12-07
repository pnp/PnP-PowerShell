#Clear-PnpRecycleBinItems
Permanently deletes all the items in the recycle bins from the context
##Syntax
```powershell
Clear-PnpRecycleBinItems [-SecondStageOnly [<SwitchParameter>]]
                         [-Force [<SwitchParameter>]]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|If provided, no confirmation will be asked to clear the recycle bin|
|SecondStageOnly|SwitchParameter|False|If provided, only all the items in the second stage recycle bin will be cleared|
##Examples

###Example 1
```powershell
PS:> Clear-PnpRecycleBinItems
```
Permanently deletes all the items in the first and second stage recycle bins from the context

###Example 2
```powershell
PS:> Clear-PnpRecycleBinItems -SecondStageOnly
```
Permanently deletes all the items only in the second stage recycle bin from the context

###Example 3
```powershell
PS:> Clear-PnpRecycleBinItems -Force
```
Permanently deletes all the items in the first and second stage recycle bins from the context without asking for confirmation from the end user first
