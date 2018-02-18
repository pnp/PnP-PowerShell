---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPWebTemplates

## SYNOPSIS
Returns the available web templates.

## SYNTAX 

### 
```powershell
Get-PnPWebTemplates [-Lcid <UInt32>]
                    [-CompatibilityLevel <Int>]
                    [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Will list all available templates one can use to create a classic site.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWebTemplates
```



### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWebTemplates -LCID 1033
```

Returns all webtemplates for the Locale with ID 1033 (English)

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPWebTemplates -CompatibilityLevel 15
```

Returns all webtemplates for the compatibility level 15

## PARAMETERS

### -CompatibilityLevel


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Lcid


```yaml
Type: UInt32
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

### [Microsoft.Online.SharePoint.TenantAdministration.SPOTenantWebTemplateCollection](https://msdn.microsoft.com/en-us/library/microsoft.online.sharepoint.tenantadministration.spotenantwebtemplatecollection.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Locale IDs](http://go.microsoft.com/fwlink/p/?LinkId=242911Id=242911)