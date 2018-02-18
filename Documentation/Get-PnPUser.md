---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPUser

## SYNOPSIS
Returns site users of current web

## SYNTAX 

### 
```powershell
Get-PnPUser [-Identity <UserPipeBind>]
            [-WithRightsAssigned [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command will return all the users that exist in the current site collection its User Information List

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPUser
```

Returns all users from the User Information List of the current site collection regardless if they currently have rights to access the current site

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPUser -Identity 23
```

Returns the user with Id 23 from the User Information List of the current site collection

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPUser -Identity i:0#.f|membership|user@tenant.onmicrosoft.com
```

Returns the user with LoginName i:0#.f|membership|user@tenant.onmicrosoft.com from the User Information List of the current site collection

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPUser | ? Email -eq "user@tenant.onmicrosoft.com"
```

Returns the user with e-mail address user@tenant.onmicrosoft.com from the User Information List of the current site collection

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPUser -WithRightsAssigned
```

Returns only those users from the User Information List of the current site collection who currently have any kind of access rights given either directly to the user or Active Directory Group or given to the user or Active Directory Group via membership of a SharePoint Group to the current site

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPUser -WithRightsAssigned -Web subsite1
```

Returns only those users from the User Information List of the current site collection who currently have any kind of access rights given either directly to the user or Active Directory Group or given to the user or Active Directory Group via membership of a SharePoint Group to subsite 'subsite1'

## PARAMETERS

### -Identity


```yaml
Type: UserPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -WithRightsAssigned


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

## OUTPUTS

### [Microsoft.SharePoint.Client.User](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.user.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)