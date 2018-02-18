---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteScript

## SYNOPSIS
Retrieve Site Scripts that have been registered on the current tenant.

## SYNTAX 

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
If specified will retrieve the specified site script

```yaml
Type: TenantSiteScriptPipeBind
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
```

### -SiteDesign
If specified will retrieve the site scripts for this design

```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
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