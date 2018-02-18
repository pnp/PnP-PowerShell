---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPExtensibilityHandlerObject

## SYNOPSIS
Creates an ExtensibilityHandler Object, to be used by the Get-SPOProvisioningTemplate cmdlet

## SYNTAX 

### 
```powershell
New-PnPExtensibilityHandlerObject [-Assembly <String>]
                                  [-Type <String>]
                                  [-Configuration <String>]
                                  [-Disabled [<SwitchParameter>]]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell

PS:> $handler = New-PnPExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler
PS:> Get-PnPProvisioningTemplate -Out NewTemplate.xml -ExtensibilityHandlers $handler
```

This will create a new ExtensibilityHandler object that is run during extraction of the template

## PARAMETERS

### -Assembly


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Configuration


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Disabled


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Type


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### OfficeDevPnP.Core.Framework.Provisioning.Model.ExtensibilityHandler

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)