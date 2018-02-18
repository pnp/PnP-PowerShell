---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteSearchQueryResults

## SYNOPSIS
Executes a search query to retrieve indexed site collections

## SYNTAX 

### 
```powershell
Get-PnPSiteSearchQueryResults [-Query <String>]
                              [-StartRow <Int>]
                              [-MaxResults <Int>]
                              [-All [<SwitchParameter>]]
                              [-Web <WebPipeBind>]
                              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults
```

Returns the top 500 site collections indexed by SharePoint Search

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults -Query "WebTemplate:STS"
```

Returns the top 500 site collections indexed by SharePoint Search which have are based on the STS (Team Site) template

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults -Query "WebTemplate:SPSPERS"
```

Returns the top 500 site collections indexed by SharePoint Search which have are based on the SPSPERS (MySite) template, up to the MaxResult limit

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults -Query "Title:Intranet*"
```

Returns the top 500 site collections indexed by SharePoint Search of which the title starts with the word Intranet

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults -MaxResults 10
```

Returns the top 10 site collections indexed by SharePoint Search

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPSiteSearchQueryResults -All
```

Returns absolutely all site collections indexed by SharePoint Search

## PARAMETERS

### -All


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MaxResults


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Query


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StartRow


```yaml
Type: Int
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

### List<System.Object>

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)