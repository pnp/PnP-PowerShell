---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPContentTypePublishingHubUrl

## SYNOPSIS
Returns the url to Content Type Publishing Hub

## SYNTAX 

### 
```powershell
Get-PnPContentTypePublishingHubUrl [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> $url = Get-PnPContentTypePublishingHubUrl
PS:> Connect-PnPOnline -Url $url
PS:> Get-PnPContentType

```

This will retrieve the url to the content type hub, connect to it, and then retrieve the content types form that site

## PARAMETERS

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