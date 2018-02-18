---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Rename-PnPFile

## SYNOPSIS
Renames a file in its current location

## SYNTAX 

### 
```powershell
Rename-PnPFile [-ServerRelativeUrl <String>]
               [-SiteRelativeUrl <String>]
               [-TargetFileName <String>]
               [-OverwriteIfAlreadyExists [<SwitchParameter>]]
               [-Force [<SwitchParameter>]]
               [-Web <WebPipeBind>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:>Rename-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetFileName mycompany.docx
```

Renames a file named company.docx located in the document library called Documents located in the projects sitecollection under the managed path sites to mycompany.docx. If a file named mycompany.aspx already exists, it won't perform the rename.

### ------------------EXAMPLE 2------------------
```powershell
PS:>Rename-PnPFile -SiteRelativeUrl Documents/company.aspx -TargetFileName mycompany.docx
```

Renames a file named company.docx located in the document library called Documents located in the current site to mycompany.aspx. If a file named mycompany.aspx already exists, it won't perform the rename.

### ------------------EXAMPLE 3------------------
```powershell
PS:>Rename-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetFileName mycompany.docx -OverwriteIfAlreadyExists
```

Renames a file named company.docx located in the document library called Documents located in the projects sitecollection under the managed path sites to mycompany.aspx. If a file named mycompany.aspx already exists, it will still perform the rename and replace the original mycompany.aspx file.

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

### -TargetFileName


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