---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPHomePage

## SYNOPSIS
Return the homepage

## SYNTAX 

### 
```powershell
Get-PnPHomePage [-Web <WebPipeBind>]
                [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns the URL to the page set as home page

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPHomePage
```

Will return the URL of the home page of the web.

## PARAMETERS

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

### System.String

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)