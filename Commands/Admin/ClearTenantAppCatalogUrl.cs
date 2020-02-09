#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Clear, "PnPTenantAppCatalogUrl", SupportsShouldProcess = true)]
    [CmdletHelp(@"Removes the url of the tenant scoped app catalog. It will not delete the site collection itself.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Clear-PnPTenantAppCatalogUrl",
        Remarks = @"Removes the url of the tenant scoped app catalog", SortOrder = 1)]
    public class ClearTenantAppCatalogUrl : PnPAdminCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var settings = TenantSettings.GetCurrent(ClientContext);
            settings.ClearCorporateCatalog();
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif