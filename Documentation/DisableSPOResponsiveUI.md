#Disable-SPOResponsiveUI
Disables the PnP Responsive UI implementation on a classic SharePoint Web
##Syntax
```powershell
Disable-SPOResponsiveUI [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Disable-SPOResponsiveUI
```
If previous enabled, will remove the PnP Responsive UI from a site.
