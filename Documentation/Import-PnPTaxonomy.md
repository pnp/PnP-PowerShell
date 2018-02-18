---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Import-PnPTaxonomy

## SYNOPSIS
Imports a taxonomy from either a string array or a file

## SYNTAX 

### 
```powershell
Import-PnPTaxonomy [-Terms <String[]>]
                   [-Path <String>]
                   [-Lcid <Int>]
                   [-TermStoreName <String>]
                   [-Delimiter <String>]
                   [-SynchronizeDeletions [<SwitchParameter>]]
                   [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Import-PnPTaxonomy -Terms 'Company|Locations|Stockholm'
```

Creates a new termgroup, 'Company', a termset 'Locations' and a term 'Stockholm'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Import-PnPTaxonomy -Terms 'Company|Locations|Stockholm|Central','Company|Locations|Stockholm|North'
```

Creates a new termgroup, 'Company', a termset 'Locations', a term 'Stockholm' and two subterms: 'Central', and 'North'

## PARAMETERS

### -Delimiter


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Lcid


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SynchronizeDeletions


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Terms


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermStoreName


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)