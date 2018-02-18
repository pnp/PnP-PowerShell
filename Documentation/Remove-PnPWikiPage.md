---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPWikiPage

## SYNOPSIS
Removes a wiki page

## SYNTAX 

### 
```powershell
Remove-PnPWikiPage [-ServerRelativePageUrl <String>]
                   [-SiteRelativePageUrl <String>]
                   [-Web <WebPipeBind>]
                   [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPWikiPage -PageUrl '/pages/wikipage.aspx'
```

Removes the page '/pages/wikipage.aspx'

## PARAMETERS

### -ServerRelativePageUrl


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "PageUrl" }

Required: False
Position: 0
Accept pipeline input: False
```

### -SiteRelativePageUrl


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