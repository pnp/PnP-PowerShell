---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPClientSidePage

## SYNOPSIS
Sets parameters of a Client-Side Page

## SYNTAX 

### 
```powershell
Set-PnPClientSidePage [-Identity <ClientSidePagePipeBind>]
                      [-Name <String>]
                      [-LayoutType <ClientSidePageLayoutType>]
                      [-PromoteAs <ClientSidePagePromoteType>]
                      [-CommentsEnabled [<SwitchParameter>]]
                      [-Publish [<SwitchParameter>]]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPClientSidePage -Identity "MyPage" -LayoutType Home
```

Updates the properties of the Client-Side page named 'MyPage'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPClientSidePage -Identity "MyPage" -CommentsEnabled
```

Enables the comments on the Client-Side page named 'MyPage'

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPClientSidePage -Identity "MyPage" -CommentsEnabled:$false
```

Disables the comments on the Client-Side page named 'MyPage'

## PARAMETERS

### -CommentsEnabled


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: ClientSidePagePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -LayoutType


```yaml
Type: ClientSidePageLayoutType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PromoteAs


```yaml
Type: ClientSidePagePromoteType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Publish


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Web


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)