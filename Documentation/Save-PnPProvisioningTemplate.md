---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Save-PnPProvisioningTemplate

## SYNOPSIS
Saves a PnP file to the file systems

## SYNTAX 

### 
```powershell
Save-PnPProvisioningTemplate [-InputInstance <ProvisioningTemplate>]
                             [-Out <String>]
                             [-Force [<SwitchParameter>]]
                             [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Save-PnPProvisioningTemplate -InputInstance $template -Out .\template.pnp
```

Saves a PnP file to the file systems

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -InputInstance


```yaml
Type: ProvisioningTemplate
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