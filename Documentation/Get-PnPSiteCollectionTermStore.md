---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteCollectionTermStore

## SYNOPSIS
Returns the site collection term store

## SYNTAX 

### 
```powershell
Get-PnPSiteCollectionTermStore [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSiteCollectionTermStore
```

Returns the site collection term store.

## PARAMETERS

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [Microsoft.SharePoint.Client.Taxonomy.TermStore](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.termstore.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)