# Remove-PnPClientSidePage
Removes a Client-Side Page
## Syntax
```powershell
Remove-PnPClientSidePage -Identity <ClientSidePagePipeBind>
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|ClientSidePagePipeBind|True|The name of the page or the page in-memory instance.|
|Force|SwitchParameter|False|Specifying the Force parameter will skip the confirmation question.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Remove-PnPClientSidePage $page
```
Removes the specified Modern Page (Client-Side).

### Example 2
```powershell
PS:> Remove-PnPClientSidePage -Identity MyPage
```
Removes the Modern Page (Client-Side) called 'MyPage.aspx'
