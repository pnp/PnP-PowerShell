---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPUserToGroup

## SYNOPSIS
Adds a user to a group

## SYNTAX 

### 
```powershell
Add-PnPUserToGroup [-LoginName <String>]
                   [-Identity <GroupPipeBind>]
                   [-EmailAddress <String>]
                   [-SendEmail [<SwitchParameter>]]
                   [-EmailBody <String>]
                   [-Web <WebPipeBind>]
                   [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPUserToGroup -LoginName user@company.com -Identity 'Marketing Site Members'
```

Add the specified user to the group "Marketing Site Members"

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPUserToGroup -LoginName user@company.com -Identity 5
```

Add the specified user to the group with Id 5

## PARAMETERS

### -EmailAddress


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -EmailBody


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: GroupPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -LoginName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SendEmail


```yaml
Type: SwitchParameter
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