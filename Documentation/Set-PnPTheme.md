---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPTheme

## SYNOPSIS
Sets the theme of the current web.

## SYNTAX 

### 
```powershell
Set-PnPTheme [-ColorPaletteUrl <String>]
             [-FontSchemeUrl <String>]
             [-BackgroundImageUrl <String>]
             [-ResetSubwebsToInherit [<SwitchParameter>]]
             [-UpdateRootWebOnly [<SwitchParameter>]]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
 Sets the theme of the current web, if any of the attributes is not set, that value will be set to null

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTheme
```

Removes the current theme and resets it to the default.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPTheme -ColorPaletteUrl /_catalogs/theme/15/company.spcolor
```



### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPTheme -ColorPaletteUrl /_catalogs/theme/15/company.spcolor -BackgroundImageUrl '/sites/Team Site/style library/background.png'
```



### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPTheme -ColorPaletteUrl /_catalogs/theme/15/company.spcolor -BackgroundImageUrl '/sites/Team Site/style library/background.png' -ResetSubwebsToInherit
```

Sets the theme to the web, and updates all subwebs to inherit the theme from this web.

## PARAMETERS

### -BackgroundImageUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ColorPaletteUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FontSchemeUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ResetSubwebsToInherit


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UpdateRootWebOnly


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