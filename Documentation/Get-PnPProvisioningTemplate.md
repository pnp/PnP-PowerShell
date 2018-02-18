---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPProvisioningTemplate

## SYNOPSIS
Generates a provisioning template from a web

## SYNTAX 

### 
```powershell
Get-PnPProvisioningTemplate [-Out <String>]
                            [-Schema <XMLPnPSchemaVersion>]
                            [-IncludeAllTermGroups [<SwitchParameter>]]
                            [-IncludeSiteCollectionTermGroup [<SwitchParameter>]]
                            [-IncludeSiteGroups [<SwitchParameter>]]
                            [-IncludeTermGroupsSecurity [<SwitchParameter>]]
                            [-IncludeSearchConfiguration [<SwitchParameter>]]
                            [-PersistBrandingFiles [<SwitchParameter>]]
                            [-PersistPublishingFiles [<SwitchParameter>]]
                            [-IncludeNativePublishingFiles [<SwitchParameter>]]
                            [-SkipVersionCheck [<SwitchParameter>]]
                            [-PersistMultiLanguageResources [<SwitchParameter>]]
                            [-ResourceFilePrefix <String>]
                            [-Handlers <Handlers>]
                            [-ExcludeHandlers <Handlers>]
                            [-ExtensibilityHandlers <ExtensibilityHandler[]>]
                            [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                            [-ContentTypeGroups <String[]>]
                            [-Force [<SwitchParameter>]]
                            [-Encoding <Encoding>]
                            [-TemplateDisplayName <String>]
                            [-TemplateImagePreviewUrl <String>]
                            [-TemplateProperties <Hashtable>]
                            [-OutputInstance [<SwitchParameter>]]
                            [-ExcludeContentTypesFromSyndication [<SwitchParameter>]]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp
```

Extracts a provisioning template in Office Open XML from the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.xml
```

Extracts a provisioning template in XML format from the current web.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -Schema V201503
```

Extracts a provisioning template in Office Open XML from the current web and saves it in the V201503 version of the schema.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -IncludeAllTermGroups
```

Extracts a provisioning template in Office Open XML from the current web and includes all term groups, term sets and terms from the Managed Metadata Service Taxonomy.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -IncludeSiteCollectionTermGroup
```

Extracts a provisioning template in Office Open XML from the current web and includes the term group currently (if set) assigned to the site collection.

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -PersistComposedLookFiles
```

Extracts a provisioning template in Office Open XML from the current web and saves the files that make up the composed look to the same folder as where the template is saved.

### ------------------EXAMPLE 7------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -Handlers Lists, SiteSecurity
```

Extracts a provisioning template in Office Open XML from the current web, but only processes lists and site security when generating the template.

### ------------------EXAMPLE 8------------------
```powershell

PS:> $handler1 = New-PnPExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler1
PS:> $handler2 = New-PnPExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler1
PS:> Get-PnPProvisioningTemplate -Out NewTemplate.xml -ExtensibilityHandlers $handler1,$handler2
```

This will create two new ExtensibilityHandler objects that are run during extraction of the template

### ------------------EXAMPLE 9------------------
Only supported on SP2016 and SP Online
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -PersistMultiLanguageResources
```

Extracts a provisioning template in Office Open XML from the current web, and for supported artifacts it will create a resource file for each supported language (based upon the language settings of the current web). The generated resource files will be named after the value specified in the Out parameter. For instance if the Out parameter is specified as -Out 'template.xml' the generated resource file will be called 'template.en-US.resx'.

### ------------------EXAMPLE 10------------------
Only supported on SP2016 and SP Online
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -PersistMultiLanguageResources -ResourceFilePrefix MyResources
```

Extracts a provisioning template in Office Open XML from the current web, and for supported artifacts it will create a resource file for each supported language (based upon the language settings of the current web). The generated resource files will be named 'MyResources.en-US.resx' etc.

### ------------------EXAMPLE 11------------------
```powershell
PS:> $template = Get-PnPProvisioningTemplate -OutputInstance
```

Extracts an instance of a provisioning template object from the current web. This syntax cannot be used together with the -Out parameter, but it can be used together with any other supported parameters.

### ------------------EXAMPLE 12------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -ContentTypeGroups "Group A","Group B"
```

Extracts a provisioning template in Office Open XML from the current web, but only processes content types from the to given content type groups.

### ------------------EXAMPLE 13------------------
```powershell
PS:> Get-PnPProvisioningTemplate -Out template.pnp -ExcludeContentTypesFromSyndication
```

Extracts a provisioning template in Office Open XML from the current web, excluding content types provisioned through content type syndication (content type hub), in order to prevent provisioning errors if the target also provision the content type using syndication.

## PARAMETERS

### -ContentTypeGroups


```yaml
Type: String[]
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

### -ExcludeContentTypesFromSyndication


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

### -Force


```yaml
Type: SwitchParameter
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

### -IncludeAllTermGroups


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeNativePublishingFiles


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeSearchConfiguration


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeSiteCollectionTermGroup


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeSiteGroups


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeTermGroupsSecurity


```yaml
Type: SwitchParameter
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

### -OutputInstance


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PersistBrandingFiles


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PersistMultiLanguageResources


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PersistPublishingFiles


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ResourceFilePrefix


```yaml
Type: String
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

### -SkipVersionCheck


```yaml
Type: SwitchParameter
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

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Encoding](https://msdn.microsoft.com/en-us/library/system.text.encoding_properties.aspx)