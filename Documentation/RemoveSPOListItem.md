#Remove-SPOListItem
Deletes an item from a list
##Syntax
```powershell
Remove-SPOListItem [-Id <Int32>] [-UniqueId <GuidPipeBind>] [-Force [<SwitchParameter>]] [-Web <WebPipeBind>] -Identity <ListPipeBind>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False||
|Id|Int32|False|The ID of the item to retrieve|
|Identity|ListPipeBind|True|The ID or Title of the list.|
|UniqueId|GuidPipeBind|False|The unique id (GUID) of the item to retrieve|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOListItem -Identity "Demo List" -Id "1" -Force
```
Removes the listitem with Id "1" from the "Demo List" list.
