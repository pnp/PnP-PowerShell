---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPUserFromGroup

## SYNOPSIS
Removes a user from a group

## SYNTAX 

### 
```powershell
Remove-PnPUserFromGroup [-LoginName <String>]
                        [-Identity <GroupPipeBind>]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPUserFromGroup -LoginName user@company.com -GroupName 'Marketing Site Members'
```

Removes the user user@company.com from the Group 'Marketing Site Members'

## PARAMETERS

### -Identity


```yaml
Type: GroupPipeBind
Parameter Sets: 
Aliases: new String[1] { "GroupName" }

Required: False
Position: 0
Accept pipeline input: False
```

### -LoginName


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "LogonName" }

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

### -Web


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)