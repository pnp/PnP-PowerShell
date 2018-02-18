---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPUnifiedGroupOwners

## SYNOPSIS
Gets owners of a paricular Office 365 Group (aka Unified Group)

## SYNTAX 

```powershell
Get-PnPUnifiedGroupOwners -Identity <UnifiedGroupPipeBind>
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPUnifiedGroupOwners -Identity $groupId
```

Retrieves all the owners of a specific Office 365 Group based on its ID

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPUnifiedGroupOwners -Identity $group
```

Retrieves all the owners of a specific Office 365 Group based on the group's object instance

## PARAMETERS

### -Identity
The Identity of the Office 365 Group.

```yaml
Type: UnifiedGroupPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)