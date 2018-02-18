---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPTenantCdnEnabled

## SYNOPSIS
Enables or disabled the public or private Office 365 Content Delivery Network (CDN).

## SYNTAX 

### 
```powershell
Set-PnPTenantCdnEnabled [-Enable <Boolean>]
                        [-CdnType <CdnType>]
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
Type: CdnType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Enable


```yaml
Type: Boolean
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