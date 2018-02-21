---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPSiteCollectionAppCatalog

## SYNOPSIS
Removes a Site Collection scoped App Catalog from a site

## SYNTAX 

```powershell
Remove-PnPSiteCollectionAppCatalog -Site <SitePipeBind>
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
Url of the site to remove the app catalog from.

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