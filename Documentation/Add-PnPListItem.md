---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPListItem

## SYNOPSIS
Adds an item to a list

## SYNTAX 

### 
```powershell
Add-PnPListItem [-List <ListPipeBind>]
                [-ContentType <ContentTypePipeBind>]
                [-Values <Hashtable>]
                [-Folder <String>]
                [-Web <WebPipeBind>]
                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Add-PnPListItem -List "Demo List" -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```

Adds a new list item to the "Demo List", and sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

### ------------------EXAMPLE 2------------------
```powershell
Add-PnPListItem -List "Demo List" -ContentType "Company" -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```

Adds a new list item to the "Demo List", sets the content type to "Company" and sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

### ------------------EXAMPLE 3------------------
```powershell
Add-PnPListItem -List "Demo List" -Values @{"MultiUserField"="user1@domain.com","user2@domain.com"}
```

Adds a new list item to the "Demo List" and sets the user field called MultiUserField to 2 users. Separate multiple users with a comma.

### ------------------EXAMPLE 4------------------
```powershell
Add-PnPListItem -List "Demo List" -Values @{"Title"="Sales Report"} -Folder "projects/europe"
```

Adds a new list item to the "Demo List". It will add the list item to the europe folder which is located in the projects folder. Folders will be created if needed.

## PARAMETERS

### -ContentType


```yaml
Type: ContentTypePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Folder


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