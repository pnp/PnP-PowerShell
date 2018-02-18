---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPTermSet

## SYNOPSIS
Creates a taxonomy term set

## SYNTAX 

### 
```powershell
New-PnPTermSet [-Name <String>]
               [-Id <Guid>]
               [-Lcid <Int>]
               [-TermGroup <Id, Title or TermGroup>]
               [-Contact <String>]
               [-Description <String>]
               [-IsOpenForTermCreation [<SwitchParameter>]]
               [-IsNotAvailableForTagging [<SwitchParameter>]]
               [-Owner <String>]
               [-StakeHolders <String[]>]
               [-CustomProperties <Hashtable>]
               [-TermStore <Id, Name or Object>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPTermSet -Name "Department" -TermGroup "Corporate"
```

Creates a new termset named "Department" in the group named "Corporate"

## PARAMETERS

### -Contact


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

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

### -IsNotAvailableForTagging


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsOpenForTermCreation


```yaml
Type: SwitchParameter
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

### -Name


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owner


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StakeHolders


```yaml
Type: String[]
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

### [Microsoft.SharePoint.Client.Taxonomy.TermSet](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.termset.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)