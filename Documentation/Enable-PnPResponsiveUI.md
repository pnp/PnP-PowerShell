---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Enable-PnPResponsiveUI

## SYNOPSIS
Activates the PnP Response UI Add-on

## SYNTAX 

### 
```powershell
Enable-PnPResponsiveUI [-InfrastructureSiteUrl <String>]
                       [-Web <WebPipeBind>]
                       [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Enables the PnP Responsive UI implementation on a classic SharePoint Site

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Enable-PnPResponsiveUI
```

Will upload a CSS file, a JavaScript file and adds a custom action to the root web of the current site collection, enabling the responsive UI on the site collection. The CSS and JavaScript files are located in the style library, in a folder called SP.Responsive.UI.

## PARAMETERS

### -InfrastructureSiteUrl


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