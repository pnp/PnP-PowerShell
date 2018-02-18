---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPClientSidePageSection

## SYNOPSIS
Adds a new section to a Client-Side page

## SYNTAX 

### 
```powershell
Add-PnPClientSidePageSection [-Page <ClientSidePagePipeBind>]
                             [-SectionTemplate <CanvasSectionTemplate>]
                             [-Order <Int>]
                             [-Web <WebPipeBind>]
                             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPClientSidePageSection -Page "MyPage" -SectionTemplate OneColumn
```

Adds a new one-column section to the Client-Side page 'MyPage'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPClientSidePageSection -Page "MyPage" -SectionTemplate ThreeColumn -Order 10
```

Adds a new Three columns section to the Client-Side page 'MyPage' with an order index of 10

### ------------------EXAMPLE 3------------------
```powershell
PS:> $page = Add-PnPClientSidePage -Name "MyPage"
PS> Add-PnPClientSidePageSection -Page $page -SectionTemplate OneColumn
```

Adds a new one column section to the Client-Side page 'MyPage'

## PARAMETERS

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

### -SectionTemplate


```yaml
Type: CanvasSectionTemplate
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