---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPListItem

## SYNOPSIS
Updates a list item

## SYNTAX 

### 
```powershell
Set-PnPListItem [-List <ListPipeBind>]
                [-Identity <ListItemPipeBind>]
                [-ContentType <ContentTypePipeBind>]
                [-Values <Hashtable>]
                [-SystemUpdate [<SwitchParameter>]]
                [-Web <WebPipeBind>]
                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Set-PnPListItem -List "Demo List" -Identity 1 -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```

Sets fields value in the list item with ID 1 in the "Demo List". It sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

### ------------------EXAMPLE 2------------------
```powershell
Set-PnPListItem -List "Demo List" -Identity 1 -ContentType "Company" -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```

Sets fields value in the list item with ID 1 in the "Demo List". It sets the content type of the item to "Company" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

### ------------------EXAMPLE 3------------------
```powershell
Set-PnPListItem -List "Demo List" -Identity $item -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```

Sets fields value in the list item which has been retrieved by for instance Get-PnPListItem. It sets the content type of the item to "Company" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

## PARAMETERS

### -ContentType


```yaml
Type: ContentTypePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: ListItemPipeBind
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

### -SystemUpdate


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Values


```yaml
Type: Hashtable
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

### [Microsoft.SharePoint.Client.ListItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.listitem.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)