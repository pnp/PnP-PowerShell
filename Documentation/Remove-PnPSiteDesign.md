---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteDesign

## SYNOPSIS
Removes a Site Design

## SYNTAX 

### 
```powershell
Remove-PnPSiteDesign [-Identity <TenantSiteDesignPipeBind>]
                     [-Force [<SwitchParameter>]]
                     [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPSiteDesign -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd
```

Removes the specified site design

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
Type: TenantSiteDesignPipeBind
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