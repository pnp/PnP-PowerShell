---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPGroup

## SYNOPSIS
Adds group to the Site Groups List and returns a group object

## SYNTAX 

### 
```powershell
New-PnPGroup [-Title <String>]
             [-Description <String>]
             [-Owner <String>]
             [-AllowRequestToJoinLeave [<SwitchParameter>]]
             [-AutoAcceptRequestToJoinLeave [<SwitchParameter>]]
             [-AllowMembersEditMembership [<SwitchParameter>]]
             [-DisallowMembersViewMembership [<SwitchParameter>]]
             [-RequestToJoinEmail <String>]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPGroup -Title "My Site Users"
```



## PARAMETERS

### -AllowMembersEditMembership


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AllowRequestToJoinLeave


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AutoAcceptRequestToJoinLeave


```yaml
Type: SwitchParameter
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

### -DisallowMembersViewMembership


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owner


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RequestToJoinEmail


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


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

### -Web


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [Microsoft.SharePoint.Client.Group](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.group.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)