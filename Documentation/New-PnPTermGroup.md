---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPTermGroup

## SYNOPSIS
Creates a taxonomy term group

## SYNTAX 

### 
```powershell
New-PnPTermGroup [-Name <String>]
                 [-Id <Guid>]
                 [-Description <String>]
                 [-TermStore <Id, Name or Object>]
                 [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPTermGroup -GroupName "Countries"
```

Creates a new taxonomy term group named "Countries"

## PARAMETERS

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
Aliases: new String[1] { "GroupId" }

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "GroupName" }

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

### [Microsoft.SharePoint.Client.Taxonomy.TermGroup](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.termgroup.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)