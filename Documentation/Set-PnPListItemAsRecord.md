---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPListItemAsRecord

## SYNOPSIS
Declares a list item as a record

## SYNTAX 

### 
```powershell
Set-PnPListItemAsRecord [-List <ListPipeBind>]
                        [-Identity <ListItemPipeBind>]
                        [-DeclarationDate <DateTime>]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPListItemAsRecord -List "Documents" -Identity 4
```

Declares the document in the documents library with id 4 as a record

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPListItemAsRecord -List "Documents" -Identity 4 -DeclarationDate $date
```

Declares the document in the documents library with id as a record

## PARAMETERS

### -DeclarationDate


```yaml
Type: DateTime
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