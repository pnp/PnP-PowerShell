---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPClientSidePage

## SYNOPSIS
Removes a Client-Side Page

## SYNTAX 

### 
```powershell
Remove-PnPClientSidePage [-Identity <ClientSidePagePipeBind>]
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPClientSidePage -Identity "MyPage"
```

Removes the Client-Side page named 'MyPage.aspx'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPClientSidePage $page
```

Removes the specified Client-Side page which is contained in the $page variable.

## PARAMETERS

### -Force


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