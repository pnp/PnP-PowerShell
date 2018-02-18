---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPUnifiedGroup

## SYNOPSIS
Sets Office 365 Group (aka Unified Group) properties

## SYNTAX 

### 
```powershell
Set-PnPUnifiedGroup [-Identity <UnifiedGroupPipeBind>]
                    [-DisplayName <String>]
                    [-Description <String>]
                    [-Owners <String[]>]
                    [-Members <String[]>]
                    [-IsPrivate [<SwitchParameter>]]
                    [-GroupLogoPath <String>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPUnifiedGroup -Identity $group -DisplayName "My Displayname"
```

Sets the display name of the group where $group is a Group entity

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPUnifiedGroup -Identity $groupId -Descriptions "My Description" -DisplayName "My DisplayName"
```

Sets the display name and description of a group based upon its ID

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPUnifiedGroup -Identity $group -GroupLogoPath ".\MyLogo.png"
```

Sets a specific Office 365 Group logo.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPUnifiedGroup -Identity $group -IsPrivate:$false
```

Sets a group to be Public if previously Private.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Set-PnPUnifiedGroup -Identity $group -Owners demo@contoso.com
```

Adds demo@contoso.com as an additional owner to the group.

## PARAMETERS

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DisplayName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -GroupLogoPath


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: UnifiedGroupPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsPrivate


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Members


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owners


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)