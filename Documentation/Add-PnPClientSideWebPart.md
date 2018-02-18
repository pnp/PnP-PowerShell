---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPClientSideWebPart

## SYNOPSIS
Adds a Client-Side Web Part to a client-side page

## SYNTAX 

### 
```powershell
Add-PnPClientSideWebPart [-Page <ClientSidePagePipeBind>]
                         [-DefaultWebPartType <DefaultClientSideWebParts>]
                         [-Component <ClientSideComponentPipeBind>]
                         [-WebPartProperties <PropertyBagPipeBind>]
                         [-Order <Int>]
                         [-Section <Int>]
                         [-Column <Int>]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Adds a client-side web part to an existing client-side page.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPClientSideWebPart -Page "MyPage" -DefaultWebPartType BingMap
```

Adds a built-in Client-Side component 'BingMap' to the page called 'MyPage'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPClientSideWebPart -Page "MyPage" -Component "HelloWorld"
```

Adds a Client-Side component 'HelloWorld' to the page called 'MyPage'

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPClientSideWebPart  -Page "MyPage" -Component "HelloWorld" -Section 1 -Column 2
```

Adds a Client-Side component 'HelloWorld' to the page called 'MyPage' in section 1 and column 2

## PARAMETERS

### -Column


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Component


```yaml
Type: ClientSideComponentPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DefaultWebPartType


```yaml
Type: DefaultClientSideWebParts
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

### -WebPartProperties


```yaml
Type: PropertyBagPipeBind
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