---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Unregister-PnPHubSite

## SYNOPSIS
Unregisters a site as a hubsite

## SYNTAX 

### 
```powershell
Unregister-PnPHubSite [-Site <SitePipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Registers a site as a hubsite

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Unregister-PnPHubSite -Site https://tenant.sharepoint.com/sites/myhubsite
```

This example unregisters the specified site as a hubsite

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