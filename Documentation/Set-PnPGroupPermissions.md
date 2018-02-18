---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPGroupPermissions

## SYNOPSIS
Adds and/or removes permissions of a specific SharePoint group

## SYNTAX 

### 
```powershell
Set-PnPGroupPermissions [-Identity <GroupPipeBind>]
                        [-List <ListPipeBind>]
                        [-AddRole <String[]>]
                        [-RemoveRole <String[]>]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPGroupPermissions -Identity 'My Site Members' -AddRole Contribute
```

Adds the 'Contribute' permission to the SharePoint group with the name 'My Site Members'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPGroupPermissions -Identity 'My Site Members' -RemoveRole 'Full Control' -AddRole 'Read'
```

Removes the 'Full Control' from and adds the 'Contribute' permissions to the SharePoint group with the name 'My Site Members'

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPGroupPermissions -Identity 'My Site Members' -AddRole @('Contribute', 'Design')
```

Adds the 'Contribute' and 'Design' permissions to the SharePoint group with the name 'My Site Members'

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPGroupPermissions -Identity 'My Site Members' -RemoveRole @('Contribute', 'Design')
```

Removes the 'Contribute' and 'Design' permissions from the SharePoint group with the name 'My Site Members'

### ------------------EXAMPLE 5------------------
```powershell
PS:> Set-PnPGroupPermissions -Identity 'My Site Members' -List 'MyList' -RemoveRole @('Contribute')
```

Removes the 'Contribute' permissions from the list 'MyList' for the group with the name 'My Site Members'

## PARAMETERS

### -AddRole


```yaml
Type: String[]
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

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RemoveRole


```yaml
Type: String[]
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