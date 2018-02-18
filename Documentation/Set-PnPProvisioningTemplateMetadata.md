---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPProvisioningTemplateMetadata

## SYNOPSIS
Sets metadata of a provisioning template

## SYNTAX 

### 
```powershell
Set-PnPProvisioningTemplateMetadata [-Path <String>]
                                    [-TemplateDisplayName <String>]
                                    [-TemplateImagePreviewUrl <String>]
                                    [-TemplateProperties <Hashtable>]
                                    [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                                    [-Web <WebPipeBind>]
                                    [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.xml -TemplateDisplayName "DisplayNameValue"
```

Sets the DisplayName property of a provisioning template in XML format.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.pnp -TemplateDisplayName "DisplayNameValue"
```

Sets the DisplayName property of a provisioning template in Office Open XML format.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.xml -TemplateImagePreviewUrl "Full URL of the Image Preview"
```

Sets the Url to the preview image of a provisioning template in XML format.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.pnp -TemplateImagePreviewUrl "Full URL of the Image Preview"
```

Sets the to the preview image of a provisioning template in Office Open XML format.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.xml -TemplateProperties @{"Property1" = "Test Value 1"; "Property2"="Test Value 2"}
```

Sets the property 'Property1' to the value 'Test Value 1' of a provisioning template in XML format.

### ------------------EXAMPLE 6------------------
```powershell
PS:> Set-PnPProvisioningTemplateMetadata -Path template.pnp -TemplateProperties @{"Property1" = "Test Value 1"; "Property2"="Test Value 2"}
```

Sets the property 'Property1' to the value 'Test Value 1' of a provisioning template in Office Open XML format.

## PARAMETERS

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TemplateDisplayName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TemplateImagePreviewUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TemplateProperties


```yaml
Type: Hashtable
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