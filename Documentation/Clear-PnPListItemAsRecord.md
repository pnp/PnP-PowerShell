---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Clear-PnPListItemAsRecord

## SYNOPSIS
Undeclares a list item as a record

## SYNTAX 

### 
```powershell
Clear-PnPListItemAsRecord [-List <ListPipeBind>]
                          [-Identity <ListItemPipeBind>]
                          [-Web <WebPipeBind>]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Clear-PnPListItemAsRecord -List "Documents" -Identity 4
```

Undeclares the document in the documents library with id 4 as a record

## PARAMETERS

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