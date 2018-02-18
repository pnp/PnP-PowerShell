---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPStorageEntity

## SYNOPSIS
Remove Storage Entities / Farm Properties.

## SYNTAX 

### 
```powershell
Remove-PnPStorageEntity [-Key <String>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPStorageEntity -Key MyKey 
```

Removes an existing storage entity / farm property

## PARAMETERS

### -Key


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)