---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Apply-PnPProvisioningTemplate

## SYNOPSIS
Applies a provisioning template to a web

## SYNTAX 

### 
```powershell
Apply-PnPProvisioningTemplate [-Path <String>]
                              [-ResourceFolder <String>]
                              [-OverwriteSystemPropertyBagValues [<SwitchParameter>]]
                              [-IgnoreDuplicateDataRowErrors [<SwitchParameter>]]
                              [-ProvisionContentTypesToSubWebs [<SwitchParameter>]]
                              [-ClearNavigation [<SwitchParameter>]]
                              [-Parameters <Hashtable>]
                              [-Handlers <Handlers>]
                              [-ExcludeHandlers <Handlers>]
                              [-ExtensibilityHandlers <ExtensibilityHandler[]>]
                              [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                              [-InputInstance <ProvisioningTemplate>]
                              [-GalleryTemplateId <Guid>]
                              [-Web <WebPipeBind>]
                              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path template.xml
```

Applies a provisioning template in XML format to the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path template.xml -ResourceFolder c:\provisioning\resources
```

Applies a provisioning template in XML format to the current web. Any resources like files that are referenced in the template will be retrieved from the folder as specified with the ResourceFolder parameter.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path template.xml -Parameters @{"ListTitle"="Projects";"parameter2"="a second value"}
```

Applies a provisioning template in XML format to the current web. It will populate the parameter in the template the values as specified and in the template you can refer to those values with the {parameter:<key>} token.

For instance with the example above, specifying {parameter:ListTitle} in your template will translate to 'Projects' when applying the template. These tokens can be used in most string values in a template.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path template.xml -Handlers Lists, SiteSecurity
```

Applies a provisioning template in XML format to the current web. It will only apply the lists and site security part of the template.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path template.pnp
```

Applies a provisioning template from a pnp package to the current web.

### ------------------EXAMPLE 6------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path https://tenant.sharepoint.com/sites/templatestorage/Documents/template.pnp
```

Applies a provisioning template from a pnp package stored in a library to the current web.

### ------------------EXAMPLE 7------------------
```powershell

PS:> $handler1 = New-PnPExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler1
PS:> $handler2 = New-PnPExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler1
PS:> Apply-PnPProvisioningTemplate -Path NewTemplate.xml -ExtensibilityHandlers $handler1,$handler2
```

This will create two new ExtensibilityHandler objects that are run while provisioning the template

### ------------------EXAMPLE 8------------------
```powershell
PS:> Apply-PnPProvisioningTemplate -Path .\ -InputInstance $template
```

Applies a provisioning template from an in-memory instance of a ProvisioningTemplate type of the PnP Core Component, reading the supporting files, if any, from the current (.\) path. The syntax can be used together with any other supported parameters.

## PARAMETERS

### -ClearNavigation


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ExcludeHandlers


```yaml
Type: Handlers
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ExtensibilityHandlers


```yaml
Type: ExtensibilityHandler[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -GalleryTemplateId


```yaml
Type: Guid
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Handlers


```yaml
Type: Handlers
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IgnoreDuplicateDataRowErrors


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

### -OverwriteSystemPropertyBagValues


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Parameters


```yaml
Type: Hashtable
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

### -ProvisionContentTypesToSubWebs


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ResourceFolder


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