#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration.Internal;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.ALM;
using OfficeDevPnP.Core.Enums;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Enums;
using SharePointPnP.PowerShell.Commands.Model;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsSecurity.Grant, "PnPTenantServicePrincipalPermission")]
    [CmdletHelp(@"Explicitely grants a specified permission to the ""SharePoint Online Client"" service principal",
        Category = CmdletHelpCategory.Apps, SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputType = typeof(AppMetadata))]
    [CmdletExample(
        Code = @"PS:> Grant-PnPTenantServicePrincipalPermission -Scope ""Group.Read.All"" -Resource ""Microsoft Graph""",
        Remarks = @"This will explicitely grant the Group.Read.All permission on the Microsoft Graph resource", SortOrder = 1)]
    public class GrantTenantServicePrincipalPermission : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The scope to grant the permission for")]
        public string Scope;

        [Parameter(Mandatory = true, HelpMessage = "The resource to grant the permission for")]
        public string Resource;

        protected override void ExecuteCmdlet()
        {
            var packageName = $"pnp-temporary-request-{System.Guid.NewGuid()}";
            var appCatalog = Tenant.GetAppCatalog();
            using (var appCatalogContext = ClientContext.Clone(appCatalog))
            {
                var list = appCatalogContext.Web.Lists.GetByTitle("Web Api Permission Requests");
                var itemCI = new ListItemCreationInformation();
                var item = list.AddItem(itemCI);
                item["_ows_PackageName"] = packageName;
                item["_ows_PackageVersion"] = "0.0.0.0";
                item["_ows_Scope"] = Scope;
                item["_ows_ResourceId"] = Resource;
                item.Update();
                appCatalogContext.ExecuteQueryRetry();
            }

            var servicePrincipal = new SPOWebAppServicePrincipal(ClientContext);
            var requests = ClientContext.LoadQuery(servicePrincipal.PermissionRequests.Where(r => r.PackageName == packageName));
            ClientContext.ExecuteQueryRetry();
            if (requests.Any())
            {
                var newRequest = requests.First();
                var request = servicePrincipal.PermissionRequests.GetById(newRequest.Id);
                var grant = request.Approve();
                ClientContext.Load(grant);
                ClientContext.ExecuteQueryRetry();
                WriteObject(new TenantServicePrincipalPermissionGrant(grant));
            }
        }
    }
}
#endif
