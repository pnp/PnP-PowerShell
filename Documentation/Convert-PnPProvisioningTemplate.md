---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Convert-PnPProvisioningTemplate

## SYNOPSIS
Converts a provisioning template to an other schema version

## SYNTAX 

### 
```powershell
Convert-PnPProvisioningTemplate [-Path <String>]
                                [-Out <String>]
                                [-ToSchema <XMLPnPSchemaVersion>]
                                [-Encoding <Encoding>]
                                [-Force [<SwitchParameter>]]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Convert-PnPProvisioningTemplate -Path template.xml
```

Converts a provisioning template to the latest schema and outputs the result to current console.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Convert-PnPProvisioningTemplate -Path template.xml -Out newtemplate.xml
```

Converts a provisioning template to the latest schema and outputs the result the newtemplate.xml file.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Convert-PnPProvisioningTemplate -Path template.xml -Out newtemplate.xml -ToSchema V201512
```

Converts a provisioning template to the latest schema using the 201512 schema and outputs the result the newtemplate.xml file.

## PARAMETERS

### -Encoding


```yaml
Type: Encoding
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

### -Out


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

### -ToSchema


```yaml
Type: XMLPnPSchemaVersion
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Encoding](https://msdn.microsoft.com/en-us/library/system.text.encoding_properties.aspx)