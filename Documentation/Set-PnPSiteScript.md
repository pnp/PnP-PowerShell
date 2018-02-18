---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSiteScript

## SYNOPSIS
Updates an existing Site Script on the current tenant.

## SYNTAX 

### 
```powershell
Set-PnPSiteScript [-Identity <TenantSiteScriptPipeBind>]
                  [-Title <String>]
                  [-Description <String>]
                  [-Content <String>]
                  [-Version <Int>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSiteScript -Identity f1d55d9b-b116-4f54-bc00-164a51e7e47f -Title "My Site Script"
```

Updates an existing Site Script and changes the title.

### ------------------EXAMPLE 2------------------
```powershell
PS:> $script = Get-PnPSiteScript -Identity f1d55d9b-b116-4f54-bc00-164a51e7e47f 
PS:> Set-PnPSiteScript -Identity $script -Title "My Site Script"
```

Updates an existing Site Script and changes the title.

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

### -Identity


```yaml
Type: TenantSiteScriptPipeBind
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

### -Version


```yaml
Type: Int
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