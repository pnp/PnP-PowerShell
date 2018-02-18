---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantCdnOrigin

## SYNOPSIS
Returns the current registered origins from the public or private content delivery network (CDN).

## SYNTAX 

### 
```powershell
Get-PnPTenantCdnOrigin [-CdnType <SPOTenantCdnType>]
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


```yaml
Type: SPOTenantCdnType
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