---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Disconnect-PnPHubSite

## SYNOPSIS
Disconnects a site from a hubsite.

## SYNTAX 

### 
```powershell
Disconnect-PnPHubSite [-Site <SitePipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Disconnects an site from a hubsite

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Disconnect-PnPHubSite -Site https://tenant.sharepoint.com/sites/mysite -HubSite https://tenant.sharepoint.com/sites/hubsite
```

This example adds the specified site to the hubsite.

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