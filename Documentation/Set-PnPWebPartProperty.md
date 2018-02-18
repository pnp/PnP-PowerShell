---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPWebPartProperty

## SYNOPSIS
Sets a web part property

## SYNTAX 

### 
```powershell
Set-PnPWebPartProperty [-ServerRelativePageUrl <String>]
                       [-Identity <GuidPipeBind>]
                       [-Key <String>]
                       [-Value <PSObject>]
                       [-Web <WebPipeBind>]
                       [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPWebPartProperty -ServerRelativePageUrl /sites/demo/sitepages/home.aspx -Identity ccd2c98a-c9ae-483b-ae72-19992d583914 -Key "Title" -Value "New Title" 
```

Sets the title property of the webpart.

## PARAMETERS

### -Identity


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Key


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ServerRelativePageUrl


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "PageUrl" }

Required: False
Position: 0
Accept pipeline input: False
```

### -Value


```yaml
Type: PSObject
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