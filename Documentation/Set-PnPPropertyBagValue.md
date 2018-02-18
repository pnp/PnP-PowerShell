---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPPropertyBagValue

## SYNOPSIS
Sets a property bag value

## SYNTAX 

### 
```powershell
Set-PnPPropertyBagValue [-Key <String>]
                        [-Value <String>]
                        [-Indexed [<SwitchParameter>]]
                        [-Folder <String>]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPPropertyBagValue -Key MyKey -Value MyValue
```

This sets or adds a value to the current web property bag

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPPropertyBagValue -Key MyKey -Value MyValue -Folder /
```

This sets or adds a value to the root folder of the current web

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPPropertyBagValue -Key MyKey -Value MyValue -Folder /MyFolder
```

This sets or adds a value to the folder MyFolder which is located in the root folder of the current web

## PARAMETERS

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Indexed


```yaml
Type: SwitchParameter
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