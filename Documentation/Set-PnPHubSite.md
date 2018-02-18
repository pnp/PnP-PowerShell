---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPHubSite

## SYNOPSIS
Sets hubsite properties

## SYNTAX 

### 
```powershell
Set-PnPHubSite [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPHubSite -Identity https://tenant.sharepoint.com/sites/myhubsite -Title "My New Title"
```

Sets the title of the hubsite

## PARAMETERS

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