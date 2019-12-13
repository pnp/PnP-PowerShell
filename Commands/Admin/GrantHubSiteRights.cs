#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsSecurity.Grant, "PnPHubSiteRights")]
    [CmdletHelp(@"Grant additional permissions to the permissions already in place to associate sites to Hub Sites for one or more specific users",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Grant-PnPHubSiteRights -Identity https://contoso.sharepoint.com/sites/hubsite -Principals ""myuser@mydomain.com"",""myotheruser@mydomain.com"" -Rights Join", Remarks = "This example shows how to grant rights to myuser and myotheruser to associate their sites with the provided Hub Site", SortOrder = 1)]
    [CmdletExample(Code = @"PS:> Grant-PnPHubSiteRights -Identity https://contoso.sharepoint.com/sites/hubsite -Principals ""myuser@mydomain.com"" -Rights None", Remarks = "This example shows how to revoke rights from myuser to associate their sites with the provided Hub Site", SortOrder = 2)]
    public class GrantHubSiteRights : PnPAdminCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true, Mandatory = true, HelpMessage = "The Hub Site to set the permissions on to associate another site with this Hub Site")]
        [Alias("HubSite")]
        public HubSitePipeBind Identity { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "One or more usernames that will be given or revoked the permission to associate a site with this Hub Site. It does not replace permissions given out before but adds to the already existing permissions.")]
        public string[] Principals { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Provide Join to give permissions to associate a site with this Hub Site or use None to revoke the permissions for the user(s) specified with the Principals argument")]
        public SPOHubSiteUserRights Rights { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.Tenant.GrantHubSiteRights(Identity.Url ?? Identity.GetHubSite(Tenant).SiteUrl, Principals, Rights);
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif
