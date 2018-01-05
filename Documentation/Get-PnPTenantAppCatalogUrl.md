---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantAppCatalogUrl

## SYNOPSIS
Retrieves the url of the tenant scoped app catalog.

## SYNTAX 

```powershell
Get-PnPTenantAppCatalogUrl [-Key <String>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTenantAppCatalogUrl
```

Returns the url of the tenant scoped app catalog site collection

## PARAMETERS

### -Key
The key of the value to retrieve.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

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