---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteCollectionAppCatalog

## SYNOPSIS
Removes a Site Collection scoped App Catalog from a site

## SYNTAX 

### 
```powershell
Remove-PnPSiteCollectionAppCatalog [-Site <SitePipeBind>]
                                   [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Notice that this will not remove the App Catalog list and its contents from the site.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPOffice365GroupToSite -Url "https://contoso.sharepoint.com/sites/FinanceTeamsite"
```

This will remove a SiteCollection app catalog from the specified site

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