#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Enums;

namespace SharePointPnP.PowerShell.Commands.Search
{
    [Cmdlet(VerbsCommon.Set, "PnPSearchSettings")]
    [CmdletHelp("Sets search settings for a site",
        Category = CmdletHelpCategory.Search, SupportedPlatform = CmdletSupportedPlatform.Online)]

    public class SetSearchSettings : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SearchBoxInNavBarType? SearchBoxInNavBar = SearchBoxInNavBarType.AllPages;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string SearchPageUrl;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SearchScopeType SearchScope = SearchScopeType.DefaultScope;

        [Parameter(Mandatory = true, HelpMessage = @"Scope to apply the setting")]
        public SearchSettingsScope Scope = SearchSettingsScope.Site;

        protected override void ExecuteCmdlet()
        {
            if (this.Scope == SearchSettingsScope.Site)
            {
                ClientContext.Site.RootWeb.EnsureProperty(w => w.SearchScope);

                if (this.SearchBoxInNavBar.HasValue)
                {
                    ClientContext.Site.SearchBoxInNavBar = this.SearchBoxInNavBar.Value;
                }
                if (!string.IsNullOrWhiteSpace(SearchPageUrl))
                {
                    ClientContext.Web.SetSiteCollectionSearchCenterUrl(SearchPageUrl);
                    ClientContext.Web.Update();
                }
                if (ClientContext.Site.RootWeb.SearchScope != SearchScope)
                {
                    ClientContext.Site.RootWeb.SearchScope = SearchScope;
                    ClientContext.Site.RootWeb.Update();
                }
            }
            else
            {
                if (this.SearchBoxInNavBar.HasValue)
                {
                    ClientContext.Web.SearchBoxInNavBar = this.SearchBoxInNavBar.Value;
                    ClientContext.Web.Update();
                }
                if (!string.IsNullOrWhiteSpace(SearchPageUrl))
                {
                    ClientContext.Web.SetWebSearchCenterUrl(SearchPageUrl);
                    ClientContext.Web.Update();
                }
                ClientContext.Web.EnsureProperty(w => w.SearchScope);
                if (ClientContext.Web.SearchScope != SearchScope)
                {
                    ClientContext.Web.SearchScope = SearchScope;
                    ClientContext.Web.Update();
                }
            }

            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif