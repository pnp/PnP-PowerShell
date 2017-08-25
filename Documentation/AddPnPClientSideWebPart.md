# Add-PnPClientSideWebPart
Adds a Client-Side Component to a page
## Syntax
```powershell
Add-PnPClientSideWebPart -Page <ClientSidePagePipeBind>
                         [-DefaultWebPartType <Nullable`1>]
                         [-Component <ClientSideComponentPipeBind>]
                         [-WebPartProperties <GenericPropertiesPipeBind>]
                         [-Order <Int>]
                         [-Section <Nullable`1>]
                         [-Column <Nullable`1>]
                         [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Page|ClientSidePagePipeBind|True|The name of the page or the page in-memory instance.|
|Column|Nullable`1|False|Sets the column where to insert the WebPart control.|
|Component|ClientSideComponentPipeBind|False|Specifies the component instance or Id to add.|
|DefaultWebPartType|Nullable`1|False|Defines a default WebPart type to insert. This takes precedence on the Component argument.|
|Order|Int|False|Sets the order of the WebPart control. (Default = 1)|
|Section|Nullable`1|False|Sets the section where to insert the WebPart control.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
|WebPartProperties|GenericPropertiesPipeBind|False|The properties of the WebPart|
## Examples

### Example 1
```powershell
PS:> Add-PnPClientSideWebPart -Page 'OurNewPage' -Component 'HelloWorld'
```
Adds a Client-Side component 'HelloWorld' to the page called 'OurNewPage'

### Example 2
```powershell
PS:> Add-PnPClientSideWebPart  -Page 'OurNewPage' -Component 'HelloWorld' -Zone 1 -Section 2
```
Adds a Client-Side component 'HelloWorld' to the page called 'OurNewPage' in zone 1 and section 2
