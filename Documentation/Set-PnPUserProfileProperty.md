---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPUserProfileProperty

## SYNOPSIS
Office365 only: Uses the tenant API to retrieve site information.

You must connect to the tenant admin website (https://:<tenant>-admin.sharepoint.com) with Connect-PnPOnline in order to use this command. 


## SYNTAX 

### 
```powershell
Set-PnPUserProfileProperty [-Account <String>]
                           [-PropertyName <String>]
                           [-Value <String>]
                           [-Values <String[]>]
                           [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Requires a connection to a SharePoint Tenant Admin site.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPUserProfileProperty -Account 'user@domain.com' -Property 'SPS-Location' -Value 'Stockholm'
```

Sets the SPS-Location property for the user as specified by the Account parameter

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPUserProfileProperty -Account 'user@domain.com' -Property 'MyProperty' -Values 'Value 1','Value 2'
```

Sets the MyProperty multi value property for the user as specified by the Account parameter

## PARAMETERS

### -Account


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PropertyName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Value


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Values


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)