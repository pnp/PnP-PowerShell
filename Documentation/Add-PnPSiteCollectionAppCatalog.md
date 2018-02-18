---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteCollectionAppCatalog

## SYNOPSIS
Adds a Site Collection scoped App Catalog to a site

## SYNTAX 

### 
```powershell
Add-PnPSiteCollectionAppCatalog [-Site <SitePipeBind>]
                                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPOffice365GroupToSite -Site "https://contoso.sharepoint.com/sites/FinanceTeamsite"
```

This will add a SiteCollection app catalog to the specified site

## PARAMETERS

### -Site


```yaml
Type: SitePipeBind
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