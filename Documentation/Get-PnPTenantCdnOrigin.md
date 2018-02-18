---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantCdnOrigin

## SYNOPSIS
Returns the current registered origins from the public or private content delivery network (CDN).

## SYNTAX 

```powershell
Get-PnPTenantCdnOrigin -CdnType <SPOTenantCdnType>
                       [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns the current registered origins from the public or private content delivery network (CDN).

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTenantCdnOrigin -CdnType Public
```

Returns the configured CDN origins for the specified CDN type

## PARAMETERS

### -CdnType
The type of cdn to retrieve the origins from

```yaml
Type: SPOTenantCdnType
Parameter Sets: (All)

Required: True
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