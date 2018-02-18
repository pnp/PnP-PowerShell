---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPUnifiedGroupMembers

## SYNOPSIS
Gets members of a paricular Office 365 Group (aka Unified Group)

## SYNTAX 

```powershell
Get-PnPUnifiedGroupMembers -Identity <UnifiedGroupPipeBind>
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPUnifiedGroupMembers -Identity $groupId
```

Retrieves all the members of a specific Office 365 Group based on its ID

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPUnifiedGroupMembers -Identity $group
```

Retrieves all the members of a specific Office 365 Group based on the group's object instance

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