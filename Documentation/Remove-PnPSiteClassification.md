---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteClassification

## SYNOPSIS
Removes one or more existing site classification values from the list of available values. Requires a connection to the Microsoft Graph

## SYNTAX 

### 
```powershell
Remove-PnPSiteClassification [-Classifications <List`1>]
                             [-Confirm [<SwitchParameter>]]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Remove-PnPSiteClassification -Classifications "HBI"
```

Removes the "HBI" site classification from the list of available values.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Remove-PnPSiteClassification -Classifications "HBI", "Top Secret"
```

Removes the "HBI" site classification from the list of available values.

## PARAMETERS

### -Classifications


```yaml
Type: List`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Confirm


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)