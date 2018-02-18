---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Disable-PnPResponsiveUI

## SYNOPSIS
Deactive the PnP Response UI add-on

## SYNTAX 

### 
```powershell
Disable-PnPResponsiveUI [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Disables the PnP Responsive UI implementation on a classic SharePoint Site

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Disable-PnPResponsiveUI
```

If enabled previously, this will remove the PnP Responsive UI from a site.

## PARAMETERS

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