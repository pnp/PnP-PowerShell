# Get-PnPAuthenticationRealm

## SYNOPSIS
Gets the authentication realm for the current web

## SYNTAX 

```powershell
Get-PnPAuthenticationRealm [-Url <String>]
```


## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPAuthenticationRealm
```

This will get the authentication realm for the current connected site

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPAuthenticationRealm -Url https://contoso.sharepoint.com
```

This will get the authentication realm for https://contoso.sharepoint.com

## PARAMETERS

### -Url
Specifies the URL of the site

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
```

# RELATED LINKS

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)