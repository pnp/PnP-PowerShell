---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPApp

## SYNOPSIS
Returns the available apps from the app catalog

## SYNTAX 

### 
```powershell
Get-PnPApp [-Identity <GuidPipeBind>]
           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPApp
```

This will return all available app metadata from the tenant app catalog. It will list the installed version in the current site.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPApp -Identity 2646ccc3-6a2b-46ef-9273-81411cbbb60f
```

This will the specific app metadata from the app catalog.

## PARAMETERS

### -Identity


```yaml
Type: GuidPipeBind
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

## OUTPUTS

### List<OfficeDevPnP.Core.ALM.AppMetadata>

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)