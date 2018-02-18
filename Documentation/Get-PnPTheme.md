---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPTheme

## SYNOPSIS
Returns the current theme/composed look of the current web.

## SYNTAX 

### 
```powershell
Get-PnPTheme [-DetectCurrentComposedLook [<SwitchParameter>]]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTheme
```

Returns the current composed look of the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPTheme -DetectCurrentComposedLook
```

Returns the current composed look of the current web, and will try to detect the currently applied composed look based upon the actual site. Without this switch the cmdlet will first check for the presence of a property bag variable called _PnP_ProvisioningTemplateComposedLookInfo that contains composed look information when applied through the provisioning engine or the Set-PnPTheme cmdlet.

## PARAMETERS

### -DetectCurrentComposedLook


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

## OUTPUTS

### OfficeDevPnP.Core.Entities.ThemeEntity

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)