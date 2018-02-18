---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPRoleDefinition

## SYNOPSIS
Adds a Role Defintion (Permission Level) to the site collection in the current context

## SYNTAX 

### 
```powershell
Add-PnPRoleDefinition [-RoleName <String>]
                      [-Clone <RoleDefinitionPipeBind>]
                      [-Include <PermissionKind[]>]
                      [-Exclude <PermissionKind[]>]
                      [-Description <String>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command allows adding a custom Role Defintion (Permission Level) to the site collection in the current context. It does not replace or remove existing Role Definitions.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPRoleDefinition -RoleName "CustomPerm"
```

Creates additional permission level with no permission flags enabled.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPRoleDefinition -RoleName "NoDelete" -Clone "Contribute" -Exclude DeleteListItems
```

Creates additional permission level by cloning "Contribute" and removes flags DeleteListItems

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPRoleDefinition -RoleName "AddOnly" -Clone "Contribute" -Exclude DeleteListItems, EditListItems
```

Creates additional permission level by cloning "Contribute" and removes flags DeleteListItems and EditListItems

### ------------------EXAMPLE 4------------------
```powershell
PS> $roleDefinition = Get-PnPRoleDefinition -Identity "Contribute"
PS:> Add-PnPRoleDefinition -RoleName "AddOnly" -Clone $roleDefinition -Exclude DeleteListItems, EditListItems
```

Creates additional permission level by cloning "Contribute" and removes flags DeleteListItems and EditListItems

## PARAMETERS

### -Clone


```yaml
Type: RoleDefinitionPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Exclude


```yaml
Type: PermissionKind[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Include


```yaml
Type: PermissionKind[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RoleName


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