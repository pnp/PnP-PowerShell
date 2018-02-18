---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteDesign

## SYNOPSIS
Creates a new Site Design on the current tenant.

## SYNTAX 

### 
```powershell
Add-PnPSiteDesign [-Title <String>]
                  [-SiteScriptIds <GuidPipeBind[]>]
                  [-Description <String>]
                  [-IsDefault [<SwitchParameter>]]
                  [-PreviewImageAltText <String>]
                  [-PreviewImageUrl <String>]
                  [-WebTemplate <SiteWebTemplate>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPSiteDesign -Title "My Company Design" -SiteScriptIds "e84dcb46-3ab9-4456-a136-66fc6ae3d3c5","6def687f-0e08-4f1e-999c-791f3af9a600" -Description "My description" -WebTemplate TeamSite
```

Adds a new Site Design, with the specified title and description. When applied it will run the scripts as referenced by the IDs. Use Get-PnPSiteScript to receive Site Scripts. The WebTemplate parameter specifies that this design applies to Team Sites.

## PARAMETERS

### -Description


```yaml
Type: String
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