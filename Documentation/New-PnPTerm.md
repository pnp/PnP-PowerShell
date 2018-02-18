---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPTerm

## SYNOPSIS
Creates a taxonomy term

## SYNTAX 

### 
```powershell
New-PnPTerm [-Name <String>]
            [-Id <Guid>]
            [-Lcid <Int>]
            [-TermSet <Id, Title or TaxonomyItem>]
            [-TermGroup <Id, Title or TermGroup>]
            [-Description <String>]
            [-CustomProperties <Hashtable>]
            [-LocalCustomProperties <Hashtable>]
            [-TermStore <Id, Name or Object>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPTerm -TermSet "Departments" -TermGroup "Corporate" -Name "Finance"
```

Creates a new taxonomy term named "Finance" in the termset Departments which is located in the "Corporate" termgroup

## PARAMETERS

### -CustomProperties


```yaml
Type: Hashtable
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Id


```yaml
Type: Guid
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

### -LocalCustomProperties


```yaml
Type: Hashtable
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


```yaml
Type: String
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
Aliases: new String[1] { "TermStoreName" }

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