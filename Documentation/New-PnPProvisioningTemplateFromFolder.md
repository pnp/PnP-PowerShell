---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPProvisioningTemplateFromFolder

## SYNOPSIS
Generates a provisioning template from a given folder, including only files that are present in that folder

## SYNTAX 

### 
```powershell
New-PnPProvisioningTemplateFromFolder [-Out <String>]
                                      [-Folder <String>]
                                      [-TargetFolder <String>]
                                      [-Match <String>]
                                      [-ContentType <ContentTypePipeBind>]
                                      [-Properties <Hashtable>]
                                      [-Schema <XMLPnPSchemaVersion>]
                                      [-AsIncludeFile [<SwitchParameter>]]
                                      [-Force [<SwitchParameter>]]
                                      [-Encoding <Encoding>]
                                      [-Web <WebPipeBind>]
                                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml
```

Creates an empty provisioning template, and includes all files in the current folder.

### ------------------EXAMPLE 2------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml -Folder c:\temp
```

Creates an empty provisioning template, and includes all files in the c:\temp folder.

### ------------------EXAMPLE 3------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml -Folder c:\temp -Match *.js
```

Creates an empty provisioning template, and includes all files with a JS extension in the c:\temp folder.

### ------------------EXAMPLE 4------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml -Folder c:\temp -Match *.js -TargetFolder "Shared Documents"
```

Creates an empty provisioning template, and includes all files with a JS extension in the c:\temp folder and marks the files in the template to be added to the 'Shared Documents' folder

### ------------------EXAMPLE 5------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml -Folder c:\temp -Match *.js -TargetFolder "Shared Documents" -ContentType "Test Content Type"
```

Creates an empty provisioning template, and includes all files with a JS extension in the c:\temp folder and marks the files in the template to be added to the 'Shared Documents' folder. It will add a property to the item for the content type.

### ------------------EXAMPLE 6------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.xml -Folder c:\temp -Match *.js -TargetFolder "Shared Documents" -Properties @{"Title" = "Test Title"; "Category"="Test Category"}
```

Creates an empty provisioning template, and includes all files with a JS extension in the c:\temp folder and marks the files in the template to be added to the 'Shared Documents' folder. It will add the specified properties to the file entries.

### ------------------EXAMPLE 7------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.pnp
```

Creates an empty provisioning template as a pnp package file, and includes all files in the current folder

### ------------------EXAMPLE 8------------------
```powershell
PS:> New-PnPProvisioningTemplateFromFolder -Out template.pnp -Folder c:\temp
```

Creates an empty provisioning template as a pnp package file, and includes all files in the c:\temp folder

## PARAMETERS

### -AsIncludeFile


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ContentType


```yaml
Type: ContentTypePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Encoding


```yaml
Type: Encoding
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Match


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Out


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Properties


```yaml
Type: Hashtable
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Schema


```yaml
Type: XMLPnPSchemaVersion
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TargetFolder


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

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Encoding](https://msdn.microsoft.com/en-us/library/system.text.encoding_properties.aspx)