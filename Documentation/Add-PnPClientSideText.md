---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPClientSideText

## SYNOPSIS
Adds a text element to a client-side page.

## SYNTAX 

### 
```powershell
Add-PnPClientSideText [-Page <ClientSidePagePipeBind>]
                      [-Text <String>]
                      [-Order <Int>]
                      [-Section <Int>]
                      [-Column <Int>]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Adds a new text element to a section on a client-side page.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPClientSideText -Page "MyPage" -Text "Hello World!"
```

Adds the text 'Hello World!' to the Client-Side Page 'MyPage'

## PARAMETERS

### -Column


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Order


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Page


```yaml
Type: ClientSidePagePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Section


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Text


```yaml
Type: String
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