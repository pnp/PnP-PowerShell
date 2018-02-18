---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Move-PnPFile

## SYNOPSIS
Moves a file to a different location

## SYNTAX 

### 
```powershell
Move-PnPFile [-ServerRelativeUrl <String>]
             [-SiteRelativeUrl <String>]
             [-TargetUrl <String>]
             [-OverwriteIfAlreadyExists [<SwitchParameter>]]
             [-Force [<SwitchParameter>]]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:>Move-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx
```

Moves a file named company.docx located in the document library called Documents located in the projects sitecollection under the managed path sites to the site collection otherproject located in the managed path sites. If a file named company.aspx already exists, it won't perform the move.

### ------------------EXAMPLE 2------------------
```powershell
PS:>Move-PnPFile -SiteRelativeUrl Documents/company.aspx -TargetUrl /sites/otherproject/Documents/company.docx
```

Moves a file named company.docx located in the document library called Documents located in the current site to the Documents library in the site collection otherproject located in the managed path sites. If a file named company.aspx already exists, it won't perform the move.

### ------------------EXAMPLE 3------------------
```powershell
PS:>Move-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx -OverwriteIfAlreadyExists
```

Moves a file named company.docx located in the document library called Documents located in the projects sitecollection under the managed path sites to the site collection otherproject located in the managed path sites. If a file named company.aspx already exists, it will still perform the move and replace the original company.aspx file.

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -OverwriteIfAlreadyExists


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ServerRelativeUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SiteRelativeUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TargetUrl


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