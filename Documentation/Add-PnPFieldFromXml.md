---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPFieldFromXml

## SYNOPSIS
Adds a field to a list or as a site column based upon a CAML/XML field definition

## SYNTAX 

### 
```powershell
Add-PnPFieldFromXml [-List <ListPipeBind>]
                    [-FieldXml <String>]
                    [-Web <WebPipeBind>]
                    [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> $xml = '<Field Type="Text" Name="PSCmdletTest" DisplayName="PSCmdletTest" ID="{27d81055-f208-41c9-a976-61c5473eed4a}" Group="Test" Required="FALSE" StaticName="PSCmdletTest" />'
PS:> Add-PnPFieldFromXml -FieldXml $xml
```

Adds a field with the specified field CAML code to the site.

### ------------------EXAMPLE 2------------------
```powershell
PS:> $xml = '<Field Type="Text" Name="PSCmdletTest" DisplayName="PSCmdletTest" ID="{27d81055-f208-41c9-a976-61c5473eed4a}" Group="Test" Required="FALSE" StaticName="PSCmdletTest" />'
PS:> Add-PnPFieldFromXml -List "Demo List" -FieldXml $xml
```

Adds a field with the specified field CAML code to the list "Demo List".

## PARAMETERS

### -FieldXml


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
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

## OUTPUTS

### [Microsoft.SharePoint.Client.Field](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.field.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Field CAML](http://msdn.microsoft.com/en-us/library/office/ms437580(v=office.15).aspx)