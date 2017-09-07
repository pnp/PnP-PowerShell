# Add-PnPClientSidePage
Adds a Client-Side Page
## Syntax
```powershell
Add-PnPClientSidePage [-Name <String>]
                      [-LayoutType <ClientSidePageLayoutType>]
                      [-PromoteAs <EPagePromoteType>]
                      [-CommentsEnabled <Nullable`1>]
                      [-Publish [<SwitchParameter>]]
                      [-PublishMessage <String>]
                      [-Web <WebPipeBind>]
                      [-Identity <ClientSidePagePipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|CommentsEnabled|Nullable`1|False|Enables or Disables the comments on the page|
|Identity|ClientSidePagePipeBind|False|The name of the page or the page in-memory instance.|
|LayoutType|ClientSidePageLayoutType|False|Specifies the layout type of the page.|
|Name|String|False|Spcifies the chosen name of the page.|
|PromoteAs|EPagePromoteType|False|Allows to promote the page for a specific purpose (HomePage | NewsPage)|
|Publish|SwitchParameter|False|Publishes the page once it is saved.|
|PublishMessage|String|False|Sets the message for publishing the page.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Add-PnPClientSidePage -PageName 'OurNewPage'
```
Creates a new Modern Page (Client-Side) called 'OurNewPage'

### Example 2
```powershell
PS:> Add-PnPClientSidePage
```
Creates a new Modern Page (Client-Side) in-memory instance that need to be explicitly saved to be persisted in SharePoint
