#Load-SPOProvisioningTemplate
Loads a PnP file from the file systems
##Syntax
```powershell
Load-SPOProvisioningTemplate [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                             -Path <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Path|String|True|Filename to read from, optionally including full path.|
|TemplateProviderExtensions|ITemplateProviderExtension[]|False|Allows you to specify ITemplateProviderExtension to execute while loading the template.|
##Examples

###Example 1
```powershell
PS:> Load-SPOProvisioningTemplate -Path template.pnp
```
Loads a PnP file from the file systems

###Example 2
```powershell
PS:> Load-SPOProvisioningTemplate -Path template.pnp -TemplateProviderExtensions $extensions
```
Loads a PnP file from the file systems using some custom template provider extenions while loading the file.
