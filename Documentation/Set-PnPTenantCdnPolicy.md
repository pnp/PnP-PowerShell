---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPTenantCdnPolicy

## SYNOPSIS
Sets the CDN Policies for the specified CDN (Public | Private).

## SYNTAX 

```powershell
Set-PnPTenantCdnPolicy -CdnType <SPOTenantCdnType>
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
The type of cdn to retrieve the policies from

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