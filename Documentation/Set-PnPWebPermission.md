---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPWebPermission

## SYNOPSIS
Set permissions

## SYNTAX 

### 
```powershell
Set-PnPWebPermission [-Identity <WebPipeBind>]
                     [-Url <String>]
                     [-Group <GroupPipeBind>]
                     [-User <String>]
                     [-AddRole <String[]>]
                     [-RemoveRole <String[]>]
                     [-Web <WebPipeBind>]
                     [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets web permissions

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPWebPermission -Url projectA -User 'user@contoso.com' -AddRole 'Contribute'
```

Adds the 'Contribute' permission to the user 'user@contoso.com' for a web, specified by its site relative url

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPWebPermission -Identity 5fecaf67-6b9e-4691-a0ff-518fc9839aa0 -User 'user@contoso.com' -RemoveRole 'Contribute'
```

Removes the 'Contribute' permission to the user 'user@contoso.com' for a web, specified by its ID

## PARAMETERS

### -AddRole


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Group


```yaml
Type: GroupPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: WebPipeBind
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

### -Url


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -User


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