---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPListItem

## SYNOPSIS
Deletes an item from a list

## SYNTAX 

### 
```powershell
Remove-PnPListItem [-List <ListPipeBind>]
                   [-Identity <ListItemPipeBind>]
                   [-Recycle [<SwitchParameter>]]
                   [-Force [<SwitchParameter>]]
                   [-Web <WebPipeBind>]
                   [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPListItem -List "Demo List" -Identity "1" -Force
```

Removes the listitem with id "1" from the "Demo List" list.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPListItem -List "Demo List" -Identity "1" -Force -Recycle
```

Removes the listitem with id "1" from the "Demo List" list and saves it in the Recycle Bin.

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

### -Recycle


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