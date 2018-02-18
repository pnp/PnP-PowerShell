---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSiteDesign

## SYNOPSIS
Updates a Site Design on the current tenant.

## SYNTAX 

### 
```powershell
Set-PnPSiteDesign [-Identity <TenantSiteDesignPipeBind>]
                  [-Title <String>]
                  [-SiteScriptIds <GuidPipeBind[]>]
                  [-Description <String>]
                  [-IsDefault [<SwitchParameter>]]
                  [-PreviewImageAltText <String>]
                  [-PreviewImageUrl <String>]
                  [-WebTemplate <SiteWebTemplate>]
                  [-Version <Int>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSiteDesign -Identity 046e2e76-67ba-46ca-a5f6-8eb418a7821e -Title "My Updated Company Design"
```

Updates an existing Site Design and sets a new title.

### ------------------EXAMPLE 2------------------
```powershell
PS:> $design = Get-PnPSiteDesign -Identity 046e2e76-67ba-46ca-a5f6-8eb418a7821e
PS:> Set-PnPSiteDesign -Identity $design -Title "My Updated Company Design"
```

Updates an existing Site Design and sets a new title.

## PARAMETERS

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsDefault


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PreviewImageAltText


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PreviewImageUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SiteScriptIds


```yaml
Type: GuidPipeBind[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Version


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -WebTemplate


```yaml
Type: SiteWebTemplate
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