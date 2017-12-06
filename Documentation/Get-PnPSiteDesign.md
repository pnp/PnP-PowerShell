---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteDesign

## SYNOPSIS
Retrieve Site Designs that have been registered on the current tenant.

## SYNTAX 

```powershell
Get-PnPSiteDesign [-Identity <TenantSiteDesignPipeBind>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSiteDesign
```

Returns all registered site designs

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSiteDesign -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd
```

Returns a specific registered site designs

## PARAMETERS

### -Identity
If specified will retrieve the specified site design

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