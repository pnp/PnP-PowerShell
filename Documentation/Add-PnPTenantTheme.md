---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPTenantTheme

## SYNOPSIS
Adds or updates a theme to the tenant.

## SYNTAX 

```powershell
Add-PnPTenantTheme -Identity <ThemePipeBind>
                   -Palette <ThemePalettePipeBind>
                   -IsInverted <Boolean>
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
The name of the theme to add or update

```yaml
Type: ThemePipeBind
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: True
```

### -IsInverted
If the theme is inverted or not

```yaml
Type: Boolean
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Palette
The palette to add. See examples for more information.

```yaml
Type: ThemePalettePipeBind
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