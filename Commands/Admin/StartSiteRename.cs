#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsLifecycle.Start, "PnPSiteRename")]
    [CmdletHelp("Registers a site as a hubsite",
        DetailedDescription = "Registers a site as a hubsite",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Set-PnPHomePage -RootFolderRelativeUrl SitePages/Home.aspx",
        Remarks = "Sets the home page to the home.aspx file which resides in the SitePages library",
        SortOrder = 1)]
    public class StartSiteRename : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = @"The site to register as a hubsite")]
        public SitePipeBind Site;

        protected override void ExecuteCmdlet()
        {
            Tenant
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif