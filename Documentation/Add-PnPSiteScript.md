---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteScript

## SYNOPSIS
Creates a new Site Script on the current tenant.

## SYNTAX 

### 
```powershell
Add-PnPSiteScript [-Title <String>]
                  [-Description <String>]
                  [-Content <String>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPSiteScript -Title "My Site Script" -Description "A more detailed description" -Content $script
```

Adds a new Site Script, where $script variable contains the script.

## PARAMETERS

### -Content


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


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