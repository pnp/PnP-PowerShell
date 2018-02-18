---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPContentTypeToDocumentSet

## SYNOPSIS
Adds a content type to a document set

## SYNTAX 

### 
```powershell
Add-PnPContentTypeToDocumentSet [-ContentType <ContentTypePipeBind[]>]
                                [-DocumentSet <DocumentSetPipeBind>]
                                [-Web <WebPipeBind>]
                                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPContentTypeToDocumentSet -ContentType "Test CT" -DocumentSet "Test Document Set"
```

This will add the content type called 'Test CT' to the document set called ''Test Document Set'

### ------------------EXAMPLE 2------------------
```powershell
PS:> $docset = Get-PnPDocumentSetTemplate -Identity "Test Document Set"
PS:> $ct = Get-PnPContentType -Identity "Test CT"
PS:> Add-PnPContentTypeToDocumentSet -ContentType $ct -DocumentSet $docset
```

This will add the content type called 'Test CT' to the document set called ''Test Document Set'

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPContentTypeToDocumentSet -ContentType 0x0101001F1CEFF1D4126E4CAD10F00B6137E969 -DocumentSet 0x0120D520005DB65D094035A241BAC9AF083F825F3B
```

This will add the content type called 'Test CT' to the document set called ''Test Document Set'

## PARAMETERS

### -ContentType


```yaml
Type: ContentTypePipeBind[]
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