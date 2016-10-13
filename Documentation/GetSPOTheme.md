#Get-SPOTheme
Returns the current theme/composed look of the current web.
##Syntax
```powershell
Get-SPOTheme
        [-DetectCurrentComposedLook [<SwitchParameter>]]
        [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|DetectCurrentComposedLook|SwitchParameter|False|Specify this switch to not use the PnP Provisioning engine based composed look information but try to detect the current composed look as is.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Get-SPOTheme
```
Returns the current composed look of the current web.

###Example 2
```powershell
PS:> Get-SPOTheme -DetectCurrentComposedLook
```
Returns the current composed look of the current web, and will try to detect the currently applied composed look based upon the actual site. Without this switch the cmdlet will first check for the presence of a property bag variable called _PnP_ProvisioningTemplateComposedLookInfo that contains composed look information when applied through the provisioning engine or the Set-SPOTheme cmdlet.
