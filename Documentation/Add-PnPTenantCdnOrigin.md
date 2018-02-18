---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPTenantCdnOrigin

## SYNOPSIS
Adds a new origin to the public or private content delivery network (CDN).

## SYNTAX 

```powershell
Add-PnPTenantCdnOrigin -OriginUrl <String>
                       -CdnType <SPOTenantCdnType>
                       [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Add a new origin to the public or private CDN, on either Tenant level or on a single Site level. Effectively, a tenant admin points out to a document library, or a folder in the document library and requests that content in that library should be retrievable by using a CDN.

You must be a SharePoint Online global administrator and a site collection administrator to run the cmdlet.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPTenantCdnOrigin -Url /sites/site/subfolder -CdnType Public
```

This example configures a public CDN on site level.

## PARAMETERS

### -CdnType
Specifies the CDN type. The valid values are: public or private.

```yaml
Type: SPOTenantCdnType
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -OriginUrl
Specifies a path to the doc library to be configured. It can be provided in two ways: relative path, or a mask.

Relative-Relative path depends on the OriginScope. If the originScope is Tenant, a path must be a relative path under the tenant root. If the originScope is Site, a path must be a relative path under the given Site. The path must point to the valid Document Library or a folder with a document library.

```yaml
Type: String
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