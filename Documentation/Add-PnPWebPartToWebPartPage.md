---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPWebPartToWebPartPage

## SYNOPSIS
Adds a webpart to a web part page in a specified zone

## SYNTAX 

### 
```powershell
Add-PnPWebPartToWebPartPage [-ServerRelativePageUrl <String>]
                            [-Xml <String>]
                            [-Path <String>]
                            [-ZoneId <String>]
                            [-ZoneIndex <Int>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPWebPartToWebPartPage -ServerRelativePageUrl "/sites/demo/sitepages/home.aspx" -Path "c:\myfiles\listview.webpart" -ZoneId "Header" -ZoneIndex 1 
```

This will add the webpart as defined by the XML in the listview.webpart file to the specified page in the specified zone and with the order index of 1

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPWebPartToWebPartPage -ServerRelativePageUrl "/sites/demo/sitepages/home.aspx" -XML $webpart -ZoneId "Header" -ZoneIndex 1 
```

This will add the webpart as defined by the XML in the $webpart variable to the specified page in the specified zone and with the order index of 1

## PARAMETERS

### -Path


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

### -Xml


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ZoneId


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ZoneIndex


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)