#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration.Internal;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsSecurity.Revoke, "PnPTenantServicePrincipalPermission")]
    [CmdletHelp(@"Revokes a permission that was previously granted to the ""SharePoint Online Client"" service principal.",
        DetailedDescription = @"Revokes a permission that was previously granted to the ""SharePoint Online Client"" service principal.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    public class RevokeTenantServicePrincipal : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true)]
        public string ObjectId;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue("Revoke permission?","Continue"))
            {
                var servicePrincipal = new SPOWebAppServicePrincipal(ClientContext);
                var grant = servicePrincipal.PermissionGrants.GetByObjectId(ObjectId);
                grant.DeleteObject();
                ClientContext.ExecuteQuery();
            }
        }
    }
}
#endif