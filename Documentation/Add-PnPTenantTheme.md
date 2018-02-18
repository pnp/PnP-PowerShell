---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPTenantTheme

## SYNOPSIS
Adds or updates a theme to the tenant.

## SYNTAX 

### 
```powershell
Add-PnPTenantTheme [-Identity <ThemePipeBind>]
                   [-Palette <ThemePalettePipeBind>]
                   [-IsInverted <Boolean>]
                   [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Adds or updates atheme to the tenant.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> $themepalette = @{
  "themePrimary" = "#00ffff";
  "themeLighterAlt" = "#f3fcfc";
  "themeLighter" = "#daffff";
  "themeLight" = "#affefe";
  "themeTertiary" = "#76ffff";
  "themeSecondary" = "#39ffff";
  "themeDarkAlt" = "#00c4c4";
  "themeDark" = "#009090";
  "themeDarker" = "#005252";
  "neutralLighterAlt" = "#f8f8f8";
  "neutralLighter" = "#f4f4f4";
  "neutralLight" = "#eaeaea";
  "neutralQuaternaryAlt" = "#dadada";
  "neutralQuaternary" = "#d0d0d0";
  "neutralTertiaryAlt" = "#c8c8c8";
  "neutralTertiary" = "#a6a6a6";
  "neutralSecondaryAlt" = "#767676";
  "neutralSecondary" = "#666666";
  "neutralPrimary" = "#333";
  "neutralPrimaryAlt" = "#3c3c3c";
  "neutralDark" = "#212121";
  "black" = "#000000";
  "white" = "#fff";
  "primaryBackground" = "#fff";
  "primaryText" = "#333"
 }
PS:>Add-PnPTenantTheme -Identity "MyCompanyTheme" -Palette $themepalette -IsInverted $false
```

This example adds a theme to the current tenant.

## PARAMETERS

### -Identity


```yaml
Type: ThemePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsInverted


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Palette


```yaml
Type: ThemePalettePipeBind
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