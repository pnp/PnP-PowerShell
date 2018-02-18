---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteCollectionAppCatalog

## SYNOPSIS
Adds a Site Collection scoped App Catalog to a site

## SYNTAX 

```powershell
Add-PnPSiteCollectionAppCatalog -Site <SitePipeBind>
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
Url of the site to add the app catalog to.

```yaml
Type: SitePipeBind
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