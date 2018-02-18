---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPTaxonomyField

## SYNOPSIS
Add a taxonomy field

## SYNTAX 

### 
```powershell
Add-PnPTaxonomyField [-List <ListPipeBind>]
                     [-DisplayName <String>]
                     [-InternalName <String>]
                     [-TermSetPath <String>]
                     [-TaxonomyItemId <GuidPipeBind>]
                     [-TermPathDelimiter <String>]
                     [-Group <String>]
                     [-Id <GuidPipeBind>]
                     [-AddToDefaultView [<SwitchParameter>]]
                     [-MultiValue [<SwitchParameter>]]
                     [-Required [<SwitchParameter>]]
                     [-FieldOptions <AddFieldOptions>]
                     [-Web <WebPipeBind>]
                     [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Adds a taxonomy/managed metadata field to a list or as a site column.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPTaxonomyField -DisplayName "Test" -InternalName "Test" -TermSetPath "TestTermGroup|TestTermSet"
```

Adds a new taxonomy field called "Test" that points to the TestTermSet which is located in the TestTermGroup

## PARAMETERS

### -AddToDefaultView


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DisplayName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FieldOptions


```yaml
Type: AddFieldOptions
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Group


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Id


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -InternalName


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

### -MultiValue


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Required


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TaxonomyItemId


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermPathDelimiter


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TermSetPath


```yaml
Type: String
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

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)