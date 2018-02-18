---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Move-PnPListItemToRecycleBin

## SYNOPSIS
Moves an item from a list to the Recycle Bin

## SYNTAX 

### 
```powershell
Move-PnPListItemToRecycleBin [-List <ListPipeBind>]
                             [-Identity <ListItemPipeBind>]
                             [-Force [<SwitchParameter>]]
                             [-Web <WebPipeBind>]
                             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Move-PnPListItemToRecycleBin -List "Demo List" -Identity "1" -Force
```

Moves the listitem with id "1" from the "Demo List" list to the Recycle Bin.

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
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