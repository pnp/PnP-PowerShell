#Add-PnPListFoldersToProvisioningTemplate
Adds folders to a list in an in-memory PnP Provisioning Template
##Syntax
```powershell
Add-PnPListFoldersToProvisioningTemplate [-Web <WebPipeBind>]
                                         -Path <String>
                                         -List <ListPipeBind>
                                         [-Recursive [<SwitchParameter>]]
                                         [-IncludeSecurity [<SwitchParameter>]]
                                         [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|IncludeSecurity|SwitchParameter|False|The target Folder for the file to add to the in-memory template.|
|List|ListPipeBind|True|The list to query|
|Path|String|True|Filename of the .PNP Open XML provisioning template to read from, optionally including full path.|
|Recursive|SwitchParameter|False|The target Folder for the file to add to the in-memory template.|
|TemplateProviderExtensions|ITemplateProviderExtension[]|False|Allows you to specify ITemplateProviderExtension to execute while loading the template.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList'
```
Adds top level folders from a list to an in-memory PnP Provisioning Template

###Example 2
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Recursive
```
Adds all folders from a list to an in-memory PnP Provisioning Template

###Example 3
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Recursive -IncludeSecurity
```
Adds all folders from a list with unique permissions to an in-memory PnP Provisioning Template
