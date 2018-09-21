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
    [Cmdlet(VerbsCommon.Get, "PnPHubSite")]
    [CmdletHelp(@"Retrieve all or a specific hubsite.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Get-PnPHubSite", Remarks = "Returns all hubsite properties", SortOrder = 1)]
    [CmdletExample(Code = @"PS:> Get-PnPHubSite -Identity https://contoso.sharepoint.com/sites/myhubsite", Remarks = "Returns the properties of the specified hubsite", SortOrder = 2)]
    public class GetHubSite : PnPAdminCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public HubSitePipeBind Identity { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (this.Identity != null)
            {
                HubSiteProperties hubSiteProperties;
                hubSiteProperties = base.Tenant.GetHubSitePropertiesByUrl(this.Identity.Url);
                ClientContext.Load<HubSiteProperties>(hubSiteProperties);
                ClientContext.ExecuteQueryRetry();
                WriteObject(hubSiteProperties);
            }
            else
            {
                var hubSitesProperties = base.Tenant.GetHubSitesProperties();
                ClientContext.Load(hubSitesProperties);
                ClientContext.ExecuteQueryRetry();
                WriteObject(hubSitesProperties, true);
            }
        }
    }
}
#endif