#Add-SPOWebPartToWikiPage
*Topic automatically generated on: 2015-09-17*

Adds a webpart to a wiki page in a specified table row and column
##Syntax
```powershell
Add-SPOWebPartToWikiPage -Path <String> -PageUrl <String> -Row <Int32> -Column <Int32> [-AddSpace [<SwitchParameter>]] [-Web <WebPipeBind>]
```


```powershell
Add-SPOWebPartToWikiPage -Xml <String> -PageUrl <String> -Row <Int32> -Column <Int32> [-AddSpace [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|AddSpace|SwitchParameter|False||
|Column|Int32|True||
|PageUrl|String|True|Full server relative url of the webpart page, e.g. /sites/demo/sitepages/home.aspx|
|Path|String|True||
|Row|Int32|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
|Xml|String|True||
##Examples

###Example 1
```powershell
PS:> Add-SPOWebPartToWikiPage -PageUrl "/sites/demo/sitepages/home.aspx" -Path "c:\myfiles\listview.webpart" -Row 1 -Column 1
```
This will add the webpart as defined by the XML in the listview.webpart file to the specified page in the first row and the first column of the HTML table present on the page

###Example 2
```powershell
PS:> Add-SPOWebPartToWikiPage -PageUrl "/sites/demo/sitepages/home.aspx" -XML $webpart -Row 1 -Column 1
```
This will add the webpart as defined by the XML in the $webpart variable to the specified page in the first row and the first column of the HTML table present on the page
<!-- Ref: E8D7E616ADAE07583A5DB80C54B23C8F -->