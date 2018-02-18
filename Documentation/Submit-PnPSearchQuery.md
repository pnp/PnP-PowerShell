---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Submit-PnPSearchQuery

## SYNOPSIS
Executes an arbitrary search query against the SharePoint search index

## SYNTAX 

### 
```powershell
Submit-PnPSearchQuery [-Query <String>]
                      [-StartRow <Int>]
                      [-MaxResults <Int>]
                      [-All [<SwitchParameter>]]
                      [-TrimDuplicates <Boolean>]
                      [-Properties <Hashtable>]
                      [-Refiners <String>]
                      [-Culture <Int>]
                      [-QueryTemplate <String>]
                      [-SelectProperties <String[]>]
                      [-RefinementFilters <String[]>]
                      [-SortList <Hashtable>]
                      [-RankingModelId <String>]
                      [-ClientType <String>]
                      [-HiddenConstraints <String>]
                      [-TimeZoneId <Int>]
                      [-EnablePhonetic <Boolean>]
                      [-EnableStemming <Boolean>]
                      [-EnableQueryRules <Boolean>]
                      [-SourceId <Guid>]
                      [-ProcessBestBets <Boolean>]
                      [-ProcessPersonalFavorites <Boolean>]
                      [-RelevantResults [<SwitchParameter>]]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Submit-PnPSearchQuery -Query "finance"
```

Returns the top 500 items with the term finance

### ------------------EXAMPLE 2------------------
```powershell
PS:> Submit-PnPSearchQuery -Query "Title:Intranet*" -MaxResults 10
```

Returns the top 10 items indexed by SharePoint Search of which the title starts with the word Intranet

### ------------------EXAMPLE 3------------------
```powershell
PS:> Submit-PnPSearchQuery -Query "Title:Intranet*" -All
```

Returns absolutely all items indexed by SharePoint Search of which the title starts with the word Intranet

### ------------------EXAMPLE 4------------------
```powershell
PS:> Submit-PnPSearchQuery -Query "Title:Intranet*" -Refiners "contentclass,FileType(filter=6/0/*)"
```

Returns absolutely all items indexed by SharePoint Search of which the title starts with the word Intranet, and return refiners for contentclass and FileType managed properties

## PARAMETERS

### -All


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ClientType


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Culture


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -EnablePhonetic


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -EnableQueryRules


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -EnableStemming


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -HiddenConstraints


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MaxResults


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ProcessBestBets


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ProcessPersonalFavorites


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Properties


```yaml
Type: Hashtable
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Query


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -QueryTemplate


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RankingModelId


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RefinementFilters


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Refiners


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RelevantResults


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SelectProperties


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SortList


```yaml
Type: Hashtable
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SourceId


```yaml
Type: Guid
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StartRow


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TimeZoneId


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TrimDuplicates


```yaml
Type: Boolean
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

## OUTPUTS

### List<System.Object>

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)