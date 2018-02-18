---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteDesignRights

## SYNOPSIS
Returns the principals with design rights on a specific Site Design

## SYNTAX 

### 
```powershell
Get-PnPSiteDesignRights [-Identity <TenantSiteDesignPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSiteDesignRights -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd
```

Returns the principals with rights on a specific site design

## PARAMETERS

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