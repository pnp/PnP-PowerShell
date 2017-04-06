#Add-PnPPage
Adds a page
##Syntax
```powershell
Add-PnPPage -PageName <String>
            [-PageTitle <String>]
            [-Layout <PageLayoutType>]
            [-Content <String>]
            [-KeepDefaultWebParts [<SwitchParameter>]]
            [-PromoteAsNews [<SwitchParameter>]]
            [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|PageName|String|True|The name of the page, including .aspx as the file extension|
|Content|String|False|Page HTML containing canvas and web part markup|
|KeepDefaultWebParts|SwitchParameter|False|Keep any default web parts providided by the layout|
|Layout|PageLayoutType|False|The layout to be used. 'Article' for a page with a header, 'Home' for a page without header.|
|PageTitle|String|False|The title of the page|
|PromoteAsNews|SwitchParameter|False|Promote the page as a news article|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-PnPPage -PageName 'MyPage.aspx'
```
Creates a new site page named 'MyPage' with the default Article layout

###Example 2
```powershell
PS:> Add-PnPPage -PageName 'MyPage.aspx' -Layout Home 
```
Creates a new site page named 'MyPage' with the Home layout, which does not include a page banner
