---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPTerm

## SYNOPSIS
Returns a taxonomy term

## SYNTAX 

### 
```powershell
Get-PnPTerm [-Identity <Id, Name or Object>]
            [-TermSet <Id, Title or TaxonomyItem>]
            [-TermGroup <Id, Title or TermGroup>]
            [-TermStore <Id, Name or Object>]
            [-Recursive [<SwitchParameter>]]
            [-Includes <String[]>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTerm -TermSet "Departments" -TermGroup "Corporate"
```

Returns all term in the termset "Departments" which is in the group "Corporate" from the site collection termstore

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPTerm -Identity "Finance" -TermSet "Departments" -TermGroup "Corporate"
```

Returns the term named "Finance" in the termset "Departments" from the termgroup called "Corporate" from the site collection termstore

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPTerm -Identity ab2af486-e097-4b4a-9444-527b251f1f8d -TermSet "Departments" -TermGroup "Corporate"
```

Returns the term named with the given id, from the "Departments" termset in a term group called "Corporate" from the site collection termstore

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPTerm -Identity "Small Finance" -TermSet "Departments" -TermGroup "Corporate" -Recursive
```

Returns the term named "Small Finance", from the "Departments" termset in a term group called "Corporate" from the site collection termstore even if it's a subterm below "Finance"

## PARAMETERS

### -Identity


```yaml
Type: Id, Name or Object
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Recursive


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermGroup


```yaml
Type: Id, Title or TermGroup
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermSet


```yaml
Type: Id, Title or TaxonomyItem
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermStore


```yaml
Type: Id, Name or Object
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

## OUTPUTS

### [Microsoft.SharePoint.Client.Taxonomy.Term](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.term.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)