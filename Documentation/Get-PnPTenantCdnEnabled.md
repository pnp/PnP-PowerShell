---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantCdnEnabled

## SYNOPSIS
Retrieves if the Office 365 Content Delivery Network has been enabled.

## SYNTAX 

### 
```powershell
Get-PnPTenantCdnEnabled [-CdnType <SPOTenantCdnType>]
                        [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Enables or disabled the public or private Office 365 Content Delivery Network (CDN).

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTenantCdnEnabled -CdnType Public -Enable $true
```

This example sets the Public CDN enabled.

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