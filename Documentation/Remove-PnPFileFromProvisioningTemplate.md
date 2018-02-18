---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPFileFromProvisioningTemplate

## SYNOPSIS
Removes a file from a PnP Provisioning Template

## SYNTAX 

### 
```powershell
Remove-PnPFileFromProvisioningTemplate [-Path <String>]
                                       [-FilePath <String>]
                                       [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPFileFromProvisioningTemplate -Path template.pnp -FilePath filePath
```

Removes a file from an in-memory PnP Provisioning Template

## PARAMETERS

### -FilePath


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