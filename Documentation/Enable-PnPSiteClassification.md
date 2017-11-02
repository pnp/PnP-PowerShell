---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Enable-PnPSiteClassification

## SYNOPSIS
Set site information.

## SYNTAX 

```powershell
Enable-PnPSiteClassification -Classifications <List`1>
                             [-DefaultClassification <String>]
                             [-GuidanceUrl <String>]
```

## DESCRIPTION
Sets site properties for existing sites.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com -Title "Contoso Website" -Sharing Disabled
```

This will set the title of the site collection with the URL 'https://contoso.sharepoint.com' to 'Contoso Website' and disable sharing on this site collection.

## PARAMETERS

### -Classifications


```yaml
Type: List`1
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -DefaultClassification


```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -GuidanceUrl


```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)