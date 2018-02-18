---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Connect-PnPHubSite

## SYNOPSIS
Connects a site to a hubsite.

## SYNTAX 

```powershell
Connect-PnPHubSite -Site <SitePipeBind>
                   -HubSite <SitePipeBind>
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
The hubsite to connect the site to

```yaml
Type: SitePipeBind
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Site
The site to connect to the hubsite

```yaml
Type: SitePipeBind
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