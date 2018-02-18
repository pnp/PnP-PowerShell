---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPRequestAccessEmails

## SYNOPSIS
Sets Request Access Emails on a web

## SYNTAX 

### 
```powershell
Set-PnPRequestAccessEmails [-Emails <String[]>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPRequestAccessEmails -Emails someone@example.com 
```

This will update the request access e-mail address

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPRequestAccessEmails -Emails @( someone@example.com; someoneelse@example.com )
```

This will update multiple request access e-mail addresses

## PARAMETERS

### -Emails


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