---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPTenantCdnOrigin

## SYNOPSIS
Adds a new origin to the public or private content delivery network (CDN).

## SYNTAX 

### 
```powershell
Add-PnPTenantCdnOrigin [-OriginUrl <String>]
                       [-CdnType <SPOTenantCdnType>]
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


```yaml
Type: SPOTenantCdnType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -OriginUrl


```yaml
Type: String
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