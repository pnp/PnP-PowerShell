#Set-PnPDefaultPageLayout
Sets a specific page layout to be the default page layout for a publishing site. Assumes the current site in context.

##Syntax
```powershell
Set-PnPDefaultPageLayout [-Title <String>]
```


```powershell
Set-PnPDefaultPageLayout [-InheritFromParentSite]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Title|String|False|The file name of the page layout to set as a default page layout|
|InheritFromParentSite|SwitchParameter|False|Set the default page layout to be inherited from the parent site.|
##Examples

###Example 1
```powershell
PS:> Set-PnPDefaultPageLayout -Title projectpage.aspx
```
Sets projectpage.aspx to be the default page layout for the current web

###Example 2
```powershell
PS:> Set-PnPDefaultPageLayout -Title test/testpage.aspx
```
Sets a page layout in a folder in the Master Page & Page Layout gallery, such as _catalog/masterpage/test/testpage.aspx, to be the default page layout for the current web

###Example 3
```powershell
PS:> Set-PnPDefaultPageLayout -InheritFromParentSite
```
Sets the default page layout to be inherited from the parent site