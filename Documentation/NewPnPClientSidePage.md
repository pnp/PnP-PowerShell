# New-PnPClientSidePage
Creates a new Client-Side Page object
## Syntax
```powershell
New-PnPClientSidePage [-Web <WebPipeBind>]
                      [-Name <String>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Name|String|False|Sets the name of the page once it is saved.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> New-PnPClientSidePage
```
Creates a new Modern Page (Client-Side) in-memory instance

### Example 2
```powershell
PS:> New-PnPClientSidePage MyPage.aspx
```
Creates a new Modern Page (Client-Side) in-memory instance with a name MyPage.aspx

### Example 3
```powershell
PS:> New-PnPClientSidePage -Name MyPage.aspx
```
Creates a new Modern Page (Client-Side) in-memory instance with a name MyPage.aspx
