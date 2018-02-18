---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPField

## SYNOPSIS
Add a field

## SYNTAX 

### 
```powershell
Add-PnPField [-List <ListPipeBind>]
             [-Field <FieldPipeBind>]
             [-DisplayName <String>]
             [-InternalName <String>]
             [-Type <FieldType>]
             [-Id <GuidPipeBind>]
             [-AddToDefaultView [<SwitchParameter>]]
             [-Required [<SwitchParameter>]]
             [-Group <String>]
             [-ClientSideComponentId <GuidPipeBind>]
             [-ClientSideComponentProperties <String>]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

### Add field to list
```powershell
Add-PnPField [-Choices <String[]>]
```

### Add field to Web
```powershell
Add-PnPField [-Choices <String[]>]
```

## DESCRIPTION
Adds a field to a list or as a site column

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPField -List "Demo list" -DisplayName "Location" -InternalName "SPSLocation" -Type Choice -Group "Demo Group" -AddToDefaultView -Choices "Stockholm","Helsinki","Oslo"
```

This will add a field of type Choice to the list "Demo List".

### ------------------EXAMPLE 2------------------
```powershell
PS:>Add-PnPField -List "Demo list" -DisplayName "Speakers" -InternalName "SPSSpeakers" -Type MultiChoice -Group "Demo Group" -AddToDefaultView -Choices "Obiwan Kenobi","Darth Vader", "Anakin Skywalker"
```

This will add a field of type Multiple Choice to the list "Demo List". (you can pick several choices for the same item)

## PARAMETERS

### -AddToDefaultView


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Choices
Specify choices, only valid if the field type is Choice

```yaml
Type: String[]
Parameter Sets: Add field to list

Required: False
Position: 0
Accept pipeline input: False
```

### -ClientSideComponentId


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ClientSideComponentProperties


```yaml
Type: String
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

### -Field


```yaml
Type: FieldPipeBind
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

### -Required


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Type


```yaml
Type: FieldType
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