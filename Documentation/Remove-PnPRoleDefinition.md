---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPRoleDefinition

## SYNOPSIS
Remove a Role Definition from a site

## SYNTAX 

### 
```powershell
Remove-PnPRoleDefinition [-Identity <RoleDefinitionPipeBind>]
                         [-Force [<SwitchParameter>]]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPRoleDefinition -Identity MyRoleDefinition
```

Removes the specified Role Definition (Permission Level) from the current site

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: RoleDefinitionPipeBind
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