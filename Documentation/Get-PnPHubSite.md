---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPHubSite

## SYNOPSIS
Retrieve all or a specific hubsite.

## SYNTAX 

```powershell
Get-PnPHubSite [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPStorageEntity
```

Returns all site storage entities/farm properties

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPTenantSite -Key MyKey
```

Returns the storage entity/farm property with the given key.

## PARAMETERS

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)