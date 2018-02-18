---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPGroup

## SYNOPSIS
Updates a group

## SYNTAX 

### 
```powershell
Set-PnPGroup [-Identity <GroupPipeBind>]
             [-SetAssociatedGroup <AssociatedGroupType>]
             [-AddRole <String>]
             [-RemoveRole <String>]
             [-Title <String>]
             [-Owner <String>]
             [-Description <String>]
             [-AllowRequestToJoinLeave <Boolean>]
             [-AutoAcceptRequestToJoinLeave <Boolean>]
             [-AllowMembersEditMembership <Boolean>]
             [-OnlyAllowMembersViewMembership <Boolean>]
             [-RequestToJoinEmail <String>]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPGroup -Identity 'My Site Members' -SetAssociatedGroup Members
```

Sets the SharePoint group with the name 'My Site Members' as the associated members group

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPGroup -Identity 'My Site Members' -Owner 'site owners'
```

Sets the SharePoint group with the name 'site owners' as the owner of the SharePoint group with the name 'My Site Members'

## PARAMETERS

### -AddRole


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AllowMembersEditMembership


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AllowRequestToJoinLeave


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AutoAcceptRequestToJoinLeave


```yaml
Type: Boolean
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

### -Identity


```yaml
Type: GroupPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -OnlyAllowMembersViewMembership


```yaml
Type: Boolean
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

### -RemoveRole


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

### -SetAssociatedGroup


```yaml
Type: AssociatedGroupType
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)