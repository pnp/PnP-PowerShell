---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPDocumentSetField

## SYNOPSIS
Sets a site column from the available content types to a document set

## SYNTAX 

### 
```powershell
Set-PnPDocumentSetField [-DocumentSet <DocumentSetPipeBind>]
                        [-Field <FieldPipeBind>]
                        [-SetSharedField [<SwitchParameter>]]
                        [-SetWelcomePageField [<SwitchParameter>]]
                        [-RemoveSharedField [<SwitchParameter>]]
                        [-RemoveWelcomePageField [<SwitchParameter>]]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPDocumentSetField -Field "Test Field" -DocumentSet "Test Document Set" -SetSharedField -SetWelcomePageField
```

This will set the field, available in one of the available content types, as a Shared Field and as a Welcome Page Field.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPDocumentSetField -Field "Test Field" -DocumentSet "Test Document Set" -RemoveSharedField -RemoveWelcomePageField
```

This will remove the field, available in one of the available content types, as a Shared Field and as a Welcome Page Field.

## PARAMETERS

### -DocumentSet


```yaml
Type: DocumentSetPipeBind
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

### -RemoveSharedField


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RemoveWelcomePageField


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SetSharedField


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SetWelcomePageField


```yaml
Type: SwitchParameter
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