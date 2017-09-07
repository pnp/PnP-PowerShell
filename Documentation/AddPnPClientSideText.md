# Add-PnPClientSideText
Adds a Client-Side Page
## Syntax
```powershell
Add-PnPClientSideText -Text <String>
                      -Page <ClientSidePagePipeBind>
                      [-Order <Int>]
                      [-Section <Nullable`1>]
                      [-Column <Nullable`1>]
                      [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Page|ClientSidePagePipeBind|True|The name of the page or the page in-memory instance.|
|Text|String|True|Specifies the text to display in the text area.|
|Column|Nullable`1|False|Sets the column where to insert the text control.|
|Order|Int|False|Sets the order of the text control. (Default = 1)|
|Section|Nullable`1|False|Sets the section where to insert the text control.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Add-PnPClientSideText -Page 'OurNewPage' -Text 'Hello World!'
```
Adds the text 'Hello World!' on the Modern Page 'OurNewPage'
