---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPStorageEntity

## SYNOPSIS
Remove Storage Entities / Farm Properties.

## SYNTAX 

```powershell
Remove-PnPStorageEntity -Key <String>
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
The key of the value to set.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)