#Add-PnPWebPartToPage
Adds a webpart to a site page in a specified table row and column
##Syntax
```powershell
Add-PnPWebPartToPage -Page <ClientSidePagePipeBind>
                     -CanvasControl <CanvasControl>
                     [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|CanvasControl|CanvasControl|True|Full server relative url of the webpart page, e.g. /sites/demo/sitepages/home.aspx|
|Page|ClientSidePagePipeBind|True|Full server relative url of the webpart page, e.g. /sites/demo/sitepages/home.aspx|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-PnPWebPartToWikiPage -ServerRelativePageUrl "/sites/demo/sitepages/home.aspx" -Path "c:\myfiles\listview.webpart" -Row 1 -Column 1
```
This will add the webpart as defined by the XML in the listview.webpart file to the specified page in the first row and the first column of the HTML table present on the page

###Example 2
```powershell
PS:> Add-PnPWebPartToWikiPage -ServerRelativePageUrl "/sites/demo/sitepages/home.aspx" -XML $webpart -Row 1 -Column 1
```
This will add the webpart as defined by the XML in the $webpart variable to the specified page in the first row and the first column of the HTML table present on the page
