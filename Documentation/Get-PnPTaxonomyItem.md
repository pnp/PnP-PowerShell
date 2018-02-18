---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPTaxonomyItem

## SYNOPSIS
Returns a taxonomy item

## SYNTAX 

### 
```powershell
Get-PnPTaxonomyItem [-TermPath <String>]
                    [-Connection <SPOnlineConnection>]
```

## PARAMETERS

### -TermPath


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "Term" }

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

## OUTPUTS

### [Microsoft.SharePoint.Client.Taxonomy.TaxonomyItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.taxonomyitem.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)