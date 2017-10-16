# Get-PnPTaxonomyItem

## SYNOPSIS
Returns a taxonomy item

## SYNTAX 

```powershell
Get-PnPTaxonomyItem -TermPath <String>
```

## PARAMETERS

### -TermPath
The path, delimited by | of the taxonomy item to retrieve, alike GROUPLABEL|TERMSETLABEL|TERMLABEL

```yaml
Type: String
Parameter Sets: (All)
Aliases: Term

Required: True
Position: 0
Accept pipeline input: True
```

## OUTPUTS

### [Microsoft.SharePoint.Client.Taxonomy.TaxonomyItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.taxonomyitem.aspx)

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)