---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPGroupMembers

## SYNOPSIS
Retrieves all members of a group

## SYNTAX 

### 
```powershell
Get-PnPGroupMembers [-Identity <GroupPipeBind>]
                    [-Web <WebPipeBind>]
                    [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command will return all the users that are a member of the provided SharePoint Group

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPGroupMembers -Identity 'Marketing Site Members'
```

Returns all the users that are a member of the group 'Marketing Site Members' in the current sitecollection

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPGroup | Get-PnPGroupMembers
```

Returns all the users that are a member of any of the groups in the current sitecollection

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPGroup | ? Title -Like 'Marketing*' | Get-PnPGroupMembers
```

Returns all the users that are a member of any of the groups of which their name starts with the word 'Marketing' in the current sitecollection

## PARAMETERS

### -Identity


```yaml
Type: GroupPipeBind
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

### [Microsoft.SharePoint.Client.User](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.user.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)