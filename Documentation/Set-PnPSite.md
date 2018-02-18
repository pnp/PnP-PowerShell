---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSite

## SYNOPSIS
Sets Site Collection properties.

## SYNTAX 

### 
```powershell
Set-PnPSite [-Classification <String>]
            [-DisableFlows [<SwitchParameter>]]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSite -Classification "HBI"
```

Sets the current site classification to HBI

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPSite -Classification $null
```

Unsets the current site classification

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPSite -DisableFlows
```

Disables Flows for this site

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPSite -DisableFlows:$false
```

Enables Flows for this site

## PARAMETERS

### -Classification


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DisableFlows


```yaml
Type: SwitchParameter
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