---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Send-PnPMail

## SYNOPSIS
Sends an email using the Office 365 SMTP Service or SharePoint, depending on the parameters specified. See detailed help for more information.

## SYNTAX 

### 
```powershell
Send-PnPMail [-Server <String>]
             [-From <String>]
             [-Password <String>]
             [-To <String[]>]
             [-Cc <String[]>]
             [-Subject <String>]
             [-Body <String>]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Send-PnPMail -To address@tenant.sharepointonline.com -Subject test -Body test
```

Sends an e-mail using the SharePoint SendEmail method using the current context. E-mail is sent from the system account and can only be sent to accounts in the same tenant

### ------------------EXAMPLE 2------------------
```powershell
PS:> Send-PnPMail -To address@contoso.com -Subject test -Body test -From me@tenant.onmicrosoft.com -Password xyz
```

Sends an e-mail via Office 365 SMTP and requires a from address and password. E-mail is sent from the from user and can be sent to both internal and external addresses.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Send-PnPMail -To address@contoso.com -Subject test -Body test -From me@server.net -Password xyz -Server yoursmtp.server.net
```

Sends an e-mail via a custom SMTP server and requires a from address and password. E-mail is sent from the from user.

## PARAMETERS

### -Body


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Cc


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -From


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Password


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Server


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Subject


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -To


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