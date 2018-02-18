---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPWikiPageContent

## SYNOPSIS
Gets the contents/source of a wiki page

## SYNTAX 

### 
```powershell
Get-PnPWikiPageContent [-ServerRelativePageUrl <String>]
                       [-Web <WebPipeBind>]
                       [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWikiPageContent -PageUrl '/sites/demo1/pages/wikipage.aspx'
```

Gets the content of the page '/sites/demo1/pages/wikipage.aspx'

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

## OUTPUTS

### System.String

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)