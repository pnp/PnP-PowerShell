---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantCdnPolicies

## SYNOPSIS
Returns the CDN Policies for the specified CDN (Public | Private).

## SYNTAX 

### 
```powershell
Get-PnPTenantCdnPolicies [-CdnType <SPOTenantCdnType>]
                         [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Enables or disabled the public or private Office 365 Content Delivery Network (CDN).

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTenantCdnPolicies -CdnType Public
```

Returns the policies for the specified CDN type

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