---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPTenantCdnPolicy

## SYNOPSIS
Sets the CDN Policies for the specified CDN (Public | Private).

## SYNTAX 

### 
```powershell
Set-PnPTenantCdnPolicy [-CdnType <SPOTenantCdnType>]
                       [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets the CDN Policies for the specified CDN (Public | Private).

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTenantCdnPolicies -CdnType Public -PolicyType IncludeFileExtensions -PolicyValue "CSS,EOT,GIF,ICO,JPEG,JPG,JS,MAP,PNG,SVG,TTF,WOFF"
```

This example sets the IncludeFileExtensions policy to the specified value.

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