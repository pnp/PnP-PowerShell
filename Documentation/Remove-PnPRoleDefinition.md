---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPRoleDefinition

## SYNOPSIS
Remove a Role Definition from a site

## SYNTAX 

```powershell
Remove-PnPRoleDefinition -Identity <RoleDefinitionPipeBind>
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
Do not ask for confirmation to delete the role definition

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Identity
The identity of the role definition, either a RoleDefinition object or a the name of roledefinition

```yaml
Type: RoleDefinitionPipeBind
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