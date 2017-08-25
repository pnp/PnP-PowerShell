# Get-PnPAvailableClientSideComponents
Gets the available client side components on a particular page
## Syntax
```powershell
Get-PnPAvailableClientSideComponents [-Component <ClientSideComponentPipeBind>]
                                     [-Web <WebPipeBind>]
                                     [-Page <ClientSidePagePipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Component|ClientSideComponentPipeBind|False|Specifies the component instance or Id to look for.|
|Page|ClientSidePagePipeBind|False|The name of the page or the page in-memory instance.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Get-PnPAvailableClientSideComponents $page
```
Gets the list of available client side components on the page $page

### Example 2
```powershell
PS:> Get-PnPAvailableClientSideComponents -Identity MyPage.aspx
```
Gets the list of available client side components on the page 'MyPage.aspx'

### Example 3
```powershell
PS:> Get-PnPAvailableClientSideComponents -Identity MyPage.aspx -ComponentName "HelloWorld"
```
Gets the client side component 'HelloWorld' if available on the page 'MyPage.aspx'
