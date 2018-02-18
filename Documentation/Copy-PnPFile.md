---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Copy-PnPFile

## SYNOPSIS
Copies a file or folder to a different location

## SYNTAX 

### 
```powershell
Copy-PnPFile [-SourceUrl <String>]
             [-TargetUrl <String>]
             [-OverwriteIfAlreadyExists [<SwitchParameter>]]
             [-Force [<SwitchParameter>]]
             [-SkipSourceFolderName [<SwitchParameter>]]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx
```

Copies a file named company.docx located in a document library called Documents in the current site to the site collection otherproject. If a file named company.docx already exists, it won't perform the copy.

### ------------------EXAMPLE 2------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl Documents/company2.docx
```

Copies a file named company.docx located in a document library called Documents to a new document named company2.docx in the same library.

### ------------------EXAMPLE 3------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl Documents2/company.docx
```

Copies a file named company.docx located in a document library called Documents to a document library called Documents2 in the same site. 

### ------------------EXAMPLE 4------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl Subsite/Documents/company2.docx
```

Copies a file named company.docx located in a document library called Documents to the document library named Document in a subsite named Subsite as a new document named company2.docx.

### ------------------EXAMPLE 5------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl Subsite/Documents
```

Copies a file named company.docx located in a document library called Documents to the document library named Document in a subsite named Subsite keeping the file name.

### ------------------EXAMPLE 6------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx -OverwriteIfAlreadyExists
```

Copies a file named company.docx located in a document library called Documents in the current site to the site collection otherproject. If a file named company.docx already exists, it will still perform the copy and replace the original company.docx file.

### ------------------EXAMPLE 7------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/MyDocs -TargetUrl /sites/otherproject/Documents -OverwriteIfAlreadyExists
```

Copies a folder named MyDocs in the document library called Documents located in the current site to the site collection otherproject. If the MyDocs folder exist it will copy into it, if not it will be created.

### ------------------EXAMPLE 8------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/MyDocs -TargetUrl /sites/otherproject/Documents -SkipSourceFolderName -OverwriteIfAlreadyExists
```

Copies a folder named MyDocs in the document library called Documents located in the current site to the root folder of the library named Documents in the site collection otherproject.

### ------------------EXAMPLE 9------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/MyDocs -TargetUrl /sites/otherproject/Documents/MyDocs -SkipSourceFolderName -OverwriteIfAlreadyExists
```

Copies a folder named MyDocs in the MyDocs folder of the library named Documents. If the MyDocs folder does not exists, it will be created.

### ------------------EXAMPLE 10------------------
```powershell
PS:>Copy-PnPFile -SourceUrl Documents/MyDocs -TargetUrl /sites/otherproject/Documents/MyDocs -OverwriteIfAlreadyExists
```

Copies a folder named MyDocs in the root of the library named Documents. If the MyDocs folder exists in the target, a subfolder also named MyDocs is created.

### ------------------EXAMPLE 11------------------
```powershell
PS:>Copy-PnPFile -SourceUrl SubSite1/Documents/company.docx -TargetUrl SubSite2/Documents
```

Copies a file named company.docx in the library named Documents in SubSite1 to the library named Documents in SubSite2.

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

### -SkipSourceFolderName


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SourceUrl


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "SiteRelativeUrl" }

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