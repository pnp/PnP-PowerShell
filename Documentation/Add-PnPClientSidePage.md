---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPClientSidePage

## SYNOPSIS
Adds a Client-Side Page

## SYNTAX 

### 
```powershell
Add-PnPClientSidePage [-Name <String>]
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
PS:> Add-PnPClientSidePage -Name "NewPage"
```

Creates a new Client-Side page named 'NewPage'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPClientSidePage "NewPage"
```

Creates a new Client-Side page named 'NewPage'

## PARAMETERS

### -CommentsEnabled


```yaml
Type: SwitchParameter
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