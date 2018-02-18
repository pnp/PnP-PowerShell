---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPFileToProvisioningTemplate

## SYNOPSIS
Adds a file to a PnP Provisioning Template

## SYNTAX 

### 
```powershell
Add-PnPFileToProvisioningTemplate [-Path <String>]
                                  [-Source <String>]
                                  [-Folder <String>]
                                  [-Container <String>]
                                  [-FileLevel <FileLevel>]
                                  [-FileOverwrite [<SwitchParameter>]]
                                  [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPFileToProvisioningTemplate -Path template.pnp -Source $sourceFilePath -Folder $targetFolder
```

Adds a file to a PnP Provisioning Template

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPFileToProvisioningTemplate -Path template.xml -Source $sourceFilePath -Folder $targetFolder
```

Adds a file reference to a PnP Provisioning XML Template

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPFileToProvisioningTemplate -Path template.pnp -Source "./myfile.png" -Folder "folderinsite" -FileLevel Published -FileOverwrite:$false
```

Adds a file to a PnP Provisioning Template, specifies the level as Published and defines to not overwrite the file if it exists in the site.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Add-PnPFileToProvisioningTemplate -Path template.pnp -Source $sourceFilePath -Folder $targetFolder -Container $container
```

Adds a file to a PnP Provisioning Template with a custom container for the file

## PARAMETERS

### -Container


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FileLevel


```yaml
Type: FileLevel
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FileOverwrite


```yaml
Type: SwitchParameter
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

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Source


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TemplateProviderExtensions


```yaml
Type: ITemplateProviderExtension[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)