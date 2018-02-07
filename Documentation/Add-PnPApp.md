---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPApp

## SYNOPSIS
Add/uploads an available app to the app catalog

## SYNTAX 

### Add only
```powershell
Add-PnPApp -Path <String>
           [-Overwrite [<SwitchParameter>]]
           [-Connection <SPOnlineConnection>]
```

### Add and Publish
```powershell
Add-PnPApp -Publish [<SwitchParameter>]
           -Path <String>
           [-SkipFeatureDeployment [<SwitchParameter>]]
           [-Overwrite [<SwitchParameter>]]
           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPApp -Path ./myapp.sppkg
```

This will upload the specified app package to the app catalog

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPApp -Path ./myapp.sppkg -Publish
```

This will upload the specified app package to the app catalog and deploy/trust it at the same time.

## PARAMETERS

### -Overwrite
Overwrites the existing app package if it already exists

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Path
Specifies the Id or an actual app metadata instance

```yaml
Type: String
Parameter Sets: Add only

Required: True
Position: 0
Accept pipeline input: True
```

### -Publish
This will deploy/trust an app into the app catalog

```yaml
Type: SwitchParameter
Parameter Sets: Add and Publish

Required: True
Position: Named
Accept pipeline input: False
```

### -SkipFeatureDeployment


```yaml
Type: SwitchParameter
Parameter Sets: Add and Publish

Required: False
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

## OUTPUTS

### OfficeDevPnP.Core.ALM.AppMetadata

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)