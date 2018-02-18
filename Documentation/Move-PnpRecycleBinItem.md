---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Move-PnPRecycleBinItem

## SYNOPSIS
Moves all items or a specific item in the first stage recycle bin of the current site collection to the second stage recycle bin

## SYNTAX 

### 
```powershell
Move-PnPRecycleBinItem [-Identity <RecycleBinItemPipeBind>]
                       [-Force [<SwitchParameter>]]
                       [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Move-PnpRecycleBinItem
```

Moves all the items in the first stage recycle bin of the current site collection to the second stage recycle bin

### ------------------EXAMPLE 2------------------
```powershell
PS:> Move-PnpRecycleBinItem -Identity 26ffff29-b526-4451-9b6f-7f0e56ba7125
```

Moves the item with the provided ID in the first stage recycle bin of the current site collection to the second stage recycle bin without asking for confirmation first

### ------------------EXAMPLE 3------------------
```powershell
PS:> Move-PnpRecycleBinItem -Force
```

Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin without asking for confirmation first

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
Type: RecycleBinItemPipeBind
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)