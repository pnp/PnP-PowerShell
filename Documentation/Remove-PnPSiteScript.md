---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteScript

## SYNOPSIS
Removes a Site Script

## SYNTAX 

### 
```powershell
Remove-PnPSiteScript [-Identity <TenantSiteScriptPipeBind>]
                     [-Force [<SwitchParameter>]]
                     [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPSiteScript -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd
```

Removes the specified site script

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: TenantSiteScriptPipeBind
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