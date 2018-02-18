---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteScript

## SYNOPSIS
Removes a Site Script

## SYNTAX 

```powershell
Remove-PnPSiteScript -Identity <TenantSiteScriptPipeBind>
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
If specified you will not be asked to confirm removing the specified Site Script

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Identity
The ID of the Site Script to remove

```yaml
Type: TenantSiteScriptPipeBind
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