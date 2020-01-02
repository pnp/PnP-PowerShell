#if !ONPREMISES
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Add, "PnPOrgNewsSite")]
    [CmdletHelp("Adds the site as an organization news source in your tenant",
     SupportedPlatform = CmdletSupportedPlatform.Online,
     Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
     Code = @"PS:> Add-PnPOrgNewsSite -OrgNewsSiteUrl https://yourtenant.sharepoint.com/sites/news",
     Remarks = @"Adds the site as one of multiple possible tenant's organizational news sites", SortOrder = 1)]
    public class AddOrgNewsSite : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The url of the site to be marked as one of organization's news sites")]
        public SitePipeBind OrgNewsSiteUrl;

        protected override void ExecuteCmdlet()
        {
            Tenant.SetOrgNewsSite(OrgNewsSiteUrl.Url);
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif