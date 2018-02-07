#if !ONPREMISES
using System.Linq;
using System.Management.Automation;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantAppCatalogUrl", SupportsShouldProcess = true)]
    [CmdletHelp(@"Retrieves the url of the tenant scoped app catalog.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Get-PnPTenantAppCatalogUrl", Remarks = "Returns the url of the tenant scoped app catalog site collection", SortOrder = 1)]
    public class GetTenantAppCatalogUrl : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var settings = Microsoft.SharePoint.Client.TenantSettings.GetCurrent(ClientContext);
            settings.EnsureProperties(s => s.CorporateCatalogUrl);
            WriteObject(settings.CorporateCatalogUrl);
        }
    }
}
#endif