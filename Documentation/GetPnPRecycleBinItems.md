#Get-PnPRecycleBinItems
Returns the items in the recycle bin from the context
##Syntax
##Returns
>[Microsoft.SharePoint.Client.RecycleBinItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.recyclebinitem.aspx)

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
##Examples

###Example 1
```powershell
PS:> Get-PnPRecycleBinItems
```
Returns all items in both the first and the second stage recycle bins in the current site collection

###Example 2
```powershell
PS:> Get-PnPRecycleBinItems | ? ItemState -eq "FirstStageRecycleBin"
```
Returns all items in only the first stage recycle bin in the current site collection

###Example 3
```powershell
PS:> Get-PnPRecycleBinItems | ? ItemState -eq "SecondStageRecycleBin"
```
Returns all items in only the second stage recycle bin in the current site collection
