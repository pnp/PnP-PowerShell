---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPContentTypeFromDocumentSet

## SYNOPSIS
Removes a content type from a document set

## SYNTAX 

### 
```powershell
Remove-PnPContentTypeFromDocumentSet [-ContentType <ContentTypePipeBind>]
                                     [-DocumentSet <DocumentSetPipeBind>]
                                     [-Web <WebPipeBind>]
                                     [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPContentTypeFromDocumentSet -ContentType "Test CT" -DocumentSet "Test Document Set"
```

This will remove the content type called 'Test CT' from the document set called ''Test Document Set'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPContentTypeFromDocumentSet -ContentType 0x0101001F1CEFF1D4126E4CAD10F00B6137E969 -DocumentSet 0x0120D520005DB65D094035A241BAC9AF083F825F3B
```

This will remove the content type with ID '0x0101001F1CEFF1D4126E4CAD10F00B6137E969' from the document set with ID '0x0120D520005DB65D094035A241BAC9AF083F825F3B'

## PARAMETERS

### -ContentType


```yaml
Type: ContentTypePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DocumentSet


```yaml
Type: DocumentSetPipeBind
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)