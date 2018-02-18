---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantTheme

## SYNOPSIS
Returns all or a specific theme

## SYNTAX 

### 
```powershell
Get-PnPTenantTheme [-Name <String>]
                   [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns all or a specific tenant theme.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTenantTheme
```

Returns all themes

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPTenantTheme -Name "MyCompanyTheme"
```

Returns the specified theme

## PARAMETERS

### -Name


```yaml
Type: String
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