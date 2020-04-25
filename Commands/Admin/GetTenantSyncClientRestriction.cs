#if !ONPREMISES
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using SharePointPnP.PowerShell.Commands.Model;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantSyncClientRestriction")]
    [CmdletHelp(@"Returns organization-level OneDrive synchronization restriction settings",
        DetailedDescription = @"Returns organization-level OneDrive synchronization restriction properties such as BlockMacSync,
OptOutOfGrooveBlock, and TenantRestrictionEnabled.

Currently, there are no parameters for this cmdlet.

You must have the SharePoint Online admin or Global admin role to run the cmdlet.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin,
        OutputType = typeof(SPOTenantSyncClientRestriction))]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantSyncClientRestriction",
        Remarks = @"This example returns all tenant OneDrive synchronization restriction settings", SortOrder = 1)]
    public class GetPnPTenantSyncClientRestriction : PnPAdminCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            ClientContext.Load(Tenant);
            ClientContext.Load(Tenant, t => t.HideDefaultThemes);
            ClientContext.ExecuteQueryRetry();
            WriteObject(new SPOTenantSyncClientRestriction(Tenant));
        }
    }
}
#endif