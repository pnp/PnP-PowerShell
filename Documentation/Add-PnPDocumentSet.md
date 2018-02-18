---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPDocumentSet

## SYNOPSIS
Creates a new document set in a library.

## SYNTAX 

### 
```powershell
Add-PnPDocumentSet [-List <ListPipeBind>]
                   [-Name <String>]
                   [-ContentType <ContentTypePipeBind>]
                   [-Web <WebPipeBind>]
                   [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPDocumentSet -List "Documents" -ContentType "Test Document Set" -Name "Test"
```

This will add a new document set based upon the 'Test Document Set' content type to a list called 'Documents'. The document set will be named 'Test'

## PARAMETERS

### -ContentType


```yaml
Type: ContentTypePipeBind
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

### -Name


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

### System.String

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)