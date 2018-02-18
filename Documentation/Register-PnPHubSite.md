---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Register-PnPHubSite

## SYNOPSIS
Registers a site as a hubsite

## SYNTAX 

### 
```powershell
Register-PnPHubSite [-Site <SitePipeBind>]
                    [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Registers a site as a hubsite

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Register-PnPHubSite -Site https://tenant.sharepoint.com/sites/myhubsite
```

This example registers the specified site as a hubsite

## PARAMETERS

### -Site


```yaml
Type: SitePipeBind
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