#if !ONPREMISES
using System.Management.Automation;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantRecycleBinItem", DefaultParameterSetName = "All")]
    [CmdletHelp("Returns the items in the tenant scoped recycle bin",
        DetailedDescription = "This command will return all the items in the tenant recycle bin for the Office 365 tenant you are connected to. Be sure to connect to the SharePoint Online Admin endpoint (https://yourtenantname-admin.sharepoint.com) in order for this command to work.",
        Category = CmdletHelpCategory.RecycleBin,
        SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputType = typeof(DeletedSiteProperties),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.online.sharepoint.tenantadministration.deletedsiteproperties.aspx")]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantRecycleBinItem",
        Remarks = "Returns all classic site collections in the tenant scoped recycle bin",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantRecycleBinItem -IncludeModernSites",
        Remarks = "Returns all modern and classic site collections in the tenant scoped recycle bin",
        SortOrder = 2)]
    public class GetTenantRecycleBinItems : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, it will also return all Modern Sites next to the classic sites that have been deleted and are in the tenant scoped recycle bin")]
        public SwitchParameter IncludeModernSites;

        protected override void ExecuteCmdlet()
        {
            var deletedSites = IncludeModernSites ? Tenant.GetDeletedSitePropertiesFromSharePoint("0") : Tenant.GetDeletedSiteProperties(0);
            ClientContext.Load(deletedSites, c => c.IncludeWithDefaultProperties(s => s.Url, s => s.SiteId, s => s.DaysRemaining, s => s.Status));
            ClientContext.ExecuteQueryRetry();
            if (deletedSites.AreItemsAvailable)
            {
                WriteObject(deletedSites, true);
            }
        }
    }
}
#endif