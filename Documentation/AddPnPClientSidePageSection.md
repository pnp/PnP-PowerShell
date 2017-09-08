# Add-PnPClientSidePageSection
Adds a new section to a Client-Side page
>*Only available for SharePoint Online*
## Syntax
```powershell
Add-PnPClientSidePageSection -SectionTemplate <CanvasSectionTemplate>
                             -Page <ClientSidePagePipeBind>
                             [-Order <Int>]
                             [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Page|ClientSidePagePipeBind|True|The name of the page|
|SectionTemplate|CanvasSectionTemplate|True|Specifies the columns template to use for the section.|
|Order|Int|False|Sets the order of the section. (Default = 1)|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Add-PnPClientSidePageSection -Page "MyPage" -SectionTemplate OneColumn
```
Adds a new one-column section to the Client-Side page 'MyPage'

### Example 2
```powershell
PS:> Add-PnPClientSidePageSection -Page "MyPage" -SectionTemplate ThreeColumn -Order 10
```
Adds a new Three columns section to the Client-Side page 'MyPage' with an order index of 10

### Example 3
```powershell
PS:> $page = Add-PnPClientSidePage -Name "MyPage"
PS> Add-PnPClientSidePageSection -Page $page -SectionTemplate OneColumn
```
Adds a new one column section to the Client-Side page 'MyPage'
