---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteScript

## SYNOPSIS
Retrieve Site Scripts that have been registered on the current tenant.

## SYNTAX 

### 
```powershell
Get-PnPSiteScript [-Identity <TenantSiteScriptPipeBind>]
                  [-SiteDesign <TenantSiteDesignPipeBind>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSiteScript
```

Returns all registered site scripts

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSiteScript -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd
```

Returns a specific registered site script

## PARAMETERS

### -Identity


```yaml
Type: TenantSiteScriptPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SiteDesign


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