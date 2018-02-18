---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPStorageEntity

## SYNOPSIS
Set Storage Entities / Farm Properties.

## SYNTAX 

```powershell
Set-PnPStorageEntity -Key <String>
                     -Value <String>
                     -Comment <String>
                     -Description <String>
                     [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPStorageEntity -Key MyKey -Value "MyValue" -Comment "My Comment" -Description "My Description"
```

Sets an existing or adds a new storage entity / farm property

## PARAMETERS

### -Comment
The comment to set.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Description
The description to set.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Key
The key of the value to set.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Value
The value to set.

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