---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPStorageEntity

## SYNOPSIS
Set Storage Entities / Farm Properties.

## SYNTAX 

### 
```powershell
Set-PnPStorageEntity [-Key <String>]
                     [-Value <String>]
                     [-Comment <String>]
                     [-Description <String>]
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


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Key


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Value


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