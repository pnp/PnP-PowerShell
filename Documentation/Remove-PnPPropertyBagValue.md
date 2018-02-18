---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPPropertyBagValue

## SYNOPSIS
Removes a value from the property bag

## SYNTAX 

### 
```powershell
Remove-PnPPropertyBagValue [-Key <String>]
                           [-Folder <String>]
                           [-Force [<SwitchParameter>]]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPPropertyBagValue -Key MyKey
```

This will remove the value with key MyKey from the current web property bag

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPPropertyBagValue -Key MyKey -Folder /MyFolder
```

This will remove the value with key MyKey from the folder MyFolder which is located in the root folder of the current web

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPPropertyBagValue -Key MyKey -Folder /
```

This will remove the value with key MyKey from the root folder of the current web

## PARAMETERS

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


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