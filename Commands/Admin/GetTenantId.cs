#if !ONPREMISES
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantId")]
    [CmdletHelp(@"Returns the Tenant ID",
        DetailedDescription = @"Returns the current Tenant Id for the tenant currently connected to.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantId",
        Remarks = @"Returns the current Tenant Id", SortOrder = 1)]
    public class GetTenantId : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            WriteObject(TenantExtensions.GetTenantIdByUrl(ClientContext.Url));
        }
    }
}
#endif