#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Add, "PnPSiteCollectionAppCatalog")]
    [CmdletHelp("Adds a Site Collection scoped App Catalog to a site",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputTypeLink = "https://docs.microsoft.com/sharepoint/dev/general-development/site-collection-app-catalog#configure-and-manage-site-collection-app-catalogs",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Add-PnPSiteCollectionAppCatalog -Site ""https://contoso.sharepoint.com/sites/FinanceTeamsite""",
        Remarks = @"This will add a SiteCollection app catalog to the specified site", SortOrder = 1)]
    public class AddSiteCollectionAppCatalog : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = @"Url of the site to add the app catalog to.")]
        public SitePipeBind Site;

        protected override void ExecuteCmdlet()
        {
            string url = null;
            if(Site.Site != null)
            {
                Site.Site.EnsureProperty(s => s.Url);
                url = Site.Site.Url;
            } else if(!string.IsNullOrEmpty(Site.Url))
            {
                url = Site.Url;
            }
            
            Tenant.GetSiteByUrl(url).RootWeb.TenantAppCatalog.SiteCollectionAppCatalogsSites.Add(url);
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif
