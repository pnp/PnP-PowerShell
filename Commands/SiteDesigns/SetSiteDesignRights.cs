#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "PnPSiteDesignRights", SupportsShouldProcess = true)]
    [CmdletHelp(@"Grants the specified principles rights to the site design.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSiteDesignRights -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd -Principles ""myuser@mydomain.com"",""myotheruser@mydomain.com""",
        Remarks = "Grants the specified principles View rights on the site design specified",
        SortOrder = 1)]
    public class SetSiteDesignRights : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline =true, HelpMessage = "The site design to use.")]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "The principles to grant rights to.")]
        public string[] Principles;

        [Parameter(Mandatory = false, HelpMessage = "The rights to set. Defaults to 'View'")]
        public TenantSiteDesignPrincipalRights Rights = TenantSiteDesignPrincipalRights.View;

        protected override void ExecuteCmdlet()
        {
            Tenant.GrantSiteDesignRights(Identity.Id, Principles, Rights);
            ClientContext.ExecuteQueryRetry();
        }
    }
}         
#endif