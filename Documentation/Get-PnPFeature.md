---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPFeature

## SYNOPSIS
Returns all activated or a specific activated feature

## SYNTAX 

### 
```powershell
Get-PnPFeature [-Identity <FeaturePipeBind>]
               [-Scope <FeatureScope>]
               [-Web <WebPipeBind>]
               [-Includes <String[]>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPFeature
```

This will return all activated web scoped features

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPFeature -Scope Site
```

This will return all activated site scoped features

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPFeature -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22
```

This will return a specific activated web scoped feature

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPFeature -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22 -Scope Site
```

This will return a specific activated site scoped feature

## PARAMETERS

### -Identity


```yaml
Type: FeaturePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Scope


```yaml
Type: FeatureScope
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

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [List<Microsoft.SharePoint.Client.Feature>](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.feature.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)