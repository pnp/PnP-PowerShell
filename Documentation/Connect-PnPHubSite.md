---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Connect-PnPHubSite

## SYNOPSIS
Connects a site to a hubsite.

## SYNTAX 

### 
```powershell
Connect-PnPHubSite [-Site <SitePipeBind>]
                   [-HubSite <SitePipeBind>]
                   [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Connects an existing site to a hubsite

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPHubSite -Site https://tenant.sharepoint.com/sites/mysite -HubSite https://tenant.sharepoint.com/sites/hubsite
```

This example adds the specified site to the hubsite.

## PARAMETERS

### -HubSite


```yaml
Type: SitePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

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