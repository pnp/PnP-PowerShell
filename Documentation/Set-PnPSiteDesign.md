---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSiteDesign

## SYNOPSIS
Updates a Site Design on the current tenant.

## SYNTAX 

```powershell
Set-PnPSiteDesign -Identity <TenantSiteDesignPipeBind>
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
The description of the site design

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Identity
The guid or an object representing the site design

```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -IsDefault
Specifies if the site design is a default site design

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -PreviewImageAltText
Sets the text for the preview image

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -PreviewImageUrl
Sets the url to the preview image

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -SiteScriptIds
An array of guids of site scripts

```yaml
Type: GuidPipeBind[]
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Title
The title of the site design

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Version
Specifies the version of the design

```yaml
Type: Int
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -WebTemplate
Specifies the type of site to which this design applies

```yaml
Type: SiteWebTemplate
Parameter Sets: (All)

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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)