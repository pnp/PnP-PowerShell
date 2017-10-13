# Get-PnPHomePage

## SYNOPSIS
Returns the URL to the home page

## SYNTAX 

```powershell
Get-PnPHomePage [-Web <WebPipeBind>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPHomePage
```

Will return the URL of the home page of the web.

## PARAMETERS

### -Web
The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## OUTPUTS

### System.String

# RELATED LINKS

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)