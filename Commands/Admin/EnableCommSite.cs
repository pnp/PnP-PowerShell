#if !ONPREMISES
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;


namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsLifecycle.Enable, "PnPCommSite")]
    [CmdletHelp("Enable communication site on the root site of a tenant",
        @"The Enable-PnPCommSite cmdlet converts the root site of a tenant to be a communication site. This action is not reversible.",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Enable-PnPCommSite",
        Remarks = @"This will convert the root site collection to become a communication site",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Enable-PnPCommSite -SiteUrl https://tenant.sharepoint.com",
        Remarks = @"This will convert the root site collection to become a communication site",
        SortOrder = 2)]
    public class EnableCommSite : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the full URL of the new site collection. It must be in a valid managed path in the company's site. For example, for company contoso, valid managed paths are https://contoso.sharepoint.com/sites and https://contoso.sharepoint.com/teams.")]
        public string SiteUrl;

        protected override void ExecuteCmdlet()
        {
            Tenant.EnableCommSite(SiteUrl);
        }
    }
}
#endif
