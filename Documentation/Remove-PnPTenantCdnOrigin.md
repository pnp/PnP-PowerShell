---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPTenantCdnOrigin

## SYNOPSIS
Removes an origin from the Public or Private content delivery network (CDN).

## SYNTAX 

### 
```powershell
Remove-PnPTenantCdnOrigin [-OriginUrl <String>]
                          [-CdnType <SPOTenantCdnType>]
                          [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes an origin from the Public or Private content delivery network (CDN).

You must be a SharePoint Online global administrator to run the cmdlet.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPTenantCdnOrigin -Url /sites/site/subfolder -CdnType Public
```

This example removes the specified origin from the public CDN

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