---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPRoleDefinition

## SYNOPSIS
Retrieves a Role Definitions of a site

## SYNTAX 

### 
```powershell
Get-PnPRoleDefinition [-Identity <RoleDefinitionPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPRoleDefinition
```

Retrieves the Role Definitions (Permission Levels) settings of the current site

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPRoleDefinition -Identity Read
```

Retrieves the specified Role Definition (Permission Level) settings of the current site

## PARAMETERS

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

## OUTPUTS

### [Microsoft.SharePoint.Client.RoleDefinition](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.roledefinition.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)