---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPPublishingPage

## SYNOPSIS
Adds a publishing page

## SYNTAX 

### 
```powershell
Add-PnPPublishingPage [-PageName <String>]
                      [-FolderPath <String>]
                      [-PageTemplateName <String>]
                      [-Title <String>]
                      [-Publish [<SwitchParameter>]]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPPublishingPage -PageName 'OurNewPage' -Title 'Our new page' -PageTemplateName 'ArticleLeft'
```

Creates a new page based on the pagelayout 'ArticleLeft'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPPublishingPage -PageName 'OurNewPage' -Title 'Our new page' -PageTemplateName 'ArticleLeft' -Folder '/Pages/folder'
```

Creates a new page based on the pagelayout 'ArticleLeft' with a site relative folder path

## PARAMETERS

### -FolderPath


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "Folder" }

Required: False
Position: 0
Accept pipeline input: False
```

### -PageName


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "Name" }

Required: False
Position: 0
Accept pipeline input: False
```

### -PageTemplateName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Publish


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


```yaml
Type: String
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