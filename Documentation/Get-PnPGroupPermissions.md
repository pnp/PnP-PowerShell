---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPGroupPermissions

## SYNOPSIS
Returns the permissions for a specific SharePoint group

## SYNTAX 

### 
```powershell
Get-PnPGroupPermissions [-Identity <GroupPipeBind>]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPGroupPermissions -Identity 'My Site Members'
```

Returns the permissions for the SharePoint group with the name 'My Site Members'

## PARAMETERS

### -Identity


```yaml
Type: GroupPipeBind
Parameter Sets: 
Aliases: new String[1] { "Name" }

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

### [Microsoft.SharePoint.Client.RoleDefinitionBindingCollection](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.roledefinitionbindingcollection.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)