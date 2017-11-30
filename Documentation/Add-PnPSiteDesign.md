---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteDesign

## SYNOPSIS
Creates a new Site Design on the current tenant.

## SYNTAX 

```powershell
Add-PnPSiteDesign -Title <String>
                  -SiteScriptIds <GuidPipeBind[]>
                  -WebTemplate <SiteWebTemplate>
                  [-Description <String>]
                  [-IsDefault [<SwitchParameter>]]
                  [-PreviewImageAltText <String>]
                  [-PreviewImageUrl <String>]
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
The description of the site design

```yaml
Type: String
Parameter Sets: (All)

Required: False
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

Required: True
Position: Named
Accept pipeline input: False
```

### -Title
The title of the site design

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -WebTemplate
Specifies the type of site to which this design applies

```yaml
Type: SiteWebTemplate
Parameter Sets: (All)

Required: True
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