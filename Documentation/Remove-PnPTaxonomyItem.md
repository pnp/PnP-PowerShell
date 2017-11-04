---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPTaxonomyItem

## SYNOPSIS
Removes a taxonomy item

## SYNTAX 

```powershell
Remove-PnPTaxonomyItem -TermPath <String>
                       [-Force [<SwitchParameter>]]
                       [-Connection <SPOnlineConnection>]
```

## PARAMETERS

### -Connection
Connection to be used by cmdlet

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -TermPath
The path, delimited by | of the taxonomy item to remove, alike GROUPLABEL|TERMSETLABEL|TERMLABEL

```yaml
Type: String
Parameter Sets: (All)
Aliases: Term

Required: True
Position: 0
Accept pipeline input: True
```

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)