---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPTenantTheme

## SYNOPSIS
Removes a theme

## SYNTAX 

### 
```powershell
Remove-PnPTenantTheme [-Identity <ThemePipeBind>]
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


```yaml
Type: ThemePipeBind
Parameter Sets: 
Aliases: new String[1] { "Name" }

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