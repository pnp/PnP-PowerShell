#Reset-PnpRecycleBinItem
Restores the provided recycle bin item to its original location
##Syntax
```powershell
Reset-PnpRecycleBinItem [-Force [<SwitchParameter>]]
                        -Identity <RecycleBinItemPipeBind>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|If provided, no confirmation will be asked to restore the recycle bin item|
|Identity|RecycleBinItemPipeBind|True|Id of the recycle bin item or the recycle bin item itself to restore|
##Examples

###Example 1
```powershell
PS:> Get-PnPRecycleBinItems | ? FileLeafName -like "*.docx" | Reset-PnpRecycleBinItem
```
Restores all the items in the first and second stage recycle bins to their original location of which the filename ends with the .docx extension

###Example 2
```powershell
PS:> Reset-PnpRecycleBinItem -Identity 72e4d749-d750-4989-b727-523d6726e442
```
Restores the recycle bin item with Id 72e4d749-d750-4989-b727-523d6726e442 to its original location
