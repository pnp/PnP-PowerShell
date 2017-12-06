---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteDesign

## SYNOPSIS
Removes a Site Design

## SYNTAX 

```powershell
Remove-PnPSiteDesign -Identity <TenantSiteDesignPipeBind>
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
If specified you will not be asked to confirm removing the specified Site Design

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Identity
The ID of the site design to remove

```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: (All)

Required: True
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