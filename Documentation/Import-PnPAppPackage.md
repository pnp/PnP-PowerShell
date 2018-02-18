---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Import-PnPAppPackage

## SYNOPSIS
Adds a SharePoint Addin to a site

## SYNTAX 

### 
```powershell
Import-PnPAppPackage [-Path <String>]
                     [-Force [<SwitchParameter>]]
                     [-LoadOnly [<SwitchParameter>]]
                     [-Locale <Int>]
                     [-Web <WebPipeBind>]
                     [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This commands requires that you have an addin package to deploy

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Import-PnPAppPackage -Path c:\files\demo.app -LoadOnly
```

This will load the addin in the demo.app package, but will not install it to the site.
 

### ------------------EXAMPLE 2------------------
```powershell
PS:> Import-PnPAppPackage -Path c:\files\demo.app -Force
```

This load first activate the addin sideloading feature, upload and install the addin, and deactivate the addin sideloading feature.
    

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -LoadOnly


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Locale


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Path


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

## OUTPUTS

### [Microsoft.SharePoint.Client.AppInstance](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.appinstance.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)