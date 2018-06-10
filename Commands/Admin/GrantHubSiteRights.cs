#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsSecurity.Grant, "PnPHubSiteRights")]
    [CmdletHelp(@"Grant Permissions to associate sites to Hub Sites.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Grant-PnPHubSiteRights -Identity https://contoso.sharepoint.com/sites/hubsite -Principals ""myuser@mydomain.com"",""myotheruser@mydomain.com"" -Rights Join", Remarks = "This example shows how to grant right to myuser and myotheruser to associate their sites with hubsite", SortOrder = 1)]
    public class GrantHubSiteRights : PnPAdminCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true, Mandatory = true)]
        [Alias("HubSite")]
        public HubSitePipeBind Identity { get; set; }

        [Parameter(Mandatory = true)]
        public string[] Principals { get; set; }

        [Parameter(Mandatory = true)]
        public SPOHubSiteUserRights Rights { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.Tenant.GrantHubSiteRights(Identity.Url, Principals, Rights);
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif
