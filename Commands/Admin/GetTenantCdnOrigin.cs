#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using OfficeDevPnP.Core.Sites;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantCdnOrigin")]
    [CmdletHelp("Adds a new origin to the public or private content delivery network (CDN).",
        DetailedDescription = @"Add a new origin to the public or private CDN, on either Tenant level or on a single Site level. Effectively, a tenant admin points out to a document library, or a folder in the document library and requests that content in that library should be retrievable by using a CDN.

You must be a SharePoint Online global administrator and a site collection administrator to run the cmdlet.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Add-PnPTenantCdnOrigin -Url /sites/site/subfolder",
        Remarks = @"This example configures a public CDN on site level.", SortOrder = 1)]
    public class GetTenantCdnOrigin : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The type of cdn to retrieve the origins from. Defaults to Public.")]
        public SPOTenantCdnType CdnType = SPOTenantCdnType.Public;

        protected override void ExecuteCmdlet()
        {
            var origins = Tenant.GetTenantCdnOrigins(CdnType);
            ClientContext.ExecuteQueryRetry();
            WriteObject(origins, true);
        }
    }
}
#endif