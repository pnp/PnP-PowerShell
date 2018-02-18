---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPTenantTheme

## SYNOPSIS
Removes a theme

## SYNTAX 

```powershell
Remove-PnPTenantTheme -Identity <ThemePipeBind>
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes the specified theme from the tenant configuration

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPTenantTheme -Name "MyCompanyTheme"
```

Removes the specified theme.

## PARAMETERS

### -Identity
The name of the theme to retrieve

```yaml
Type: ThemePipeBind
Parameter Sets: (All)
Aliases: Name

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