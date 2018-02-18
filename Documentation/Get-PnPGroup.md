---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPGroup

## SYNOPSIS
Returns a specific group or all groups.

## SYNTAX 

### 
```powershell
Get-PnPGroup [-Identity <GroupPipeBind>]
             [-AssociatedMemberGroup [<SwitchParameter>]]
             [-AssociatedVisitorGroup [<SwitchParameter>]]
             [-AssociatedOwnerGroup [<SwitchParameter>]]
             [-Web <WebPipeBind>]
             [-Includes <String[]>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPGroup
```

Returns all groups

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPGroup -Identity 'My Site Users'
```

This will return the group called 'My Site Users' if available

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPGroup -AssociatedMemberGroup
```

This will return the current members group for the site

## PARAMETERS

### -AssociatedMemberGroup


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AssociatedOwnerGroup


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AssociatedVisitorGroup


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: GroupPipeBind
Parameter Sets: 
Aliases: new String[1] { "Name" }

Required: False
Position: 0
Accept pipeline input: False
```

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
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

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [List<Microsoft.SharePoint.Client.Group>](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.group.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)