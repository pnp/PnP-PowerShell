#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Search
{
    [Cmdlet(VerbsCommon.Get, "PnPSearchSettings")]
    [CmdletHelp("Retrieves search settings for a site",
        Category = CmdletHelpCategory.Search, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchSettings",
        Remarks = "Retrieve search settings for the site",
        SortOrder = 1)]

    public class GetSearchSettings : PnPWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            ClientContext.Web.EnsureProperties(w => w.SearchScope, w => w.SearchBoxInNavBar);
            ClientContext.Site.EnsureProperty(s => s.SearchBoxInNavBar);

            string siteUrl = ClientContext.Web.GetSiteCollectionSearchCenterUrl();
            string webUrl = ClientContext.Web.GetWebSearchCenterUrl();

            PSObject res = new PSObject();
            res.Properties.Add(new PSNoteProperty("Classic Search Center URL", siteUrl));
            res.Properties.Add(new PSNoteProperty("Redirect search URL", webUrl));
            res.Properties.Add(new PSNoteProperty("Site Search Scope", ClientContext.Web.SearchScope));
            res.Properties.Add(new PSNoteProperty("Site collection search box visibility", ClientContext.Site.SearchBoxInNavBar));
            res.Properties.Add(new PSNoteProperty("Site search box visibility", ClientContext.Web.SearchBoxInNavBar));
            WriteObject(res);
        }
    }
}
#endif