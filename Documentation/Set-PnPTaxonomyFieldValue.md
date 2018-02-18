---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPTaxonomyFieldValue

## SYNOPSIS
Sets a taxonomy term value in a listitem field

## SYNTAX 

### 
```powershell
Set-PnPTaxonomyFieldValue [-ListItem <ListItem>]
                          [-InternalFieldName <String>]
                          [-TermId <GuidPipeBind>]
                          [-Label <String>]
                          [-TermPath <String>]
                          [-Terms <Hashtable>]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermId 863b832b-6818-4e6a-966d-2d3ee057931c
```

Sets the field called 'Department' to the value of the term with the ID specified

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermPath 'CORPORATE|DEPARTMENTS|HR'
```

Sets the field called 'Department' to the term called HR which is located in the DEPARTMENTS termset, which in turn is located in the CORPORATE termgroup.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -Terms @{"TermId1"="Label1";"TermId2"="Label2"}
```

Sets the field called 'Department' with multiple terms by ID and label. You can refer to those terms with the {ID:label} token.

## PARAMETERS

### -InternalFieldName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Label


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListItem


```yaml
Type: ListItem
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermId


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermPath


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Terms


```yaml
Type: Hashtable
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