using Microsoft.Identity.Client;
using OfficeDevPnP.Core;
using PnP.PowerShell.CmdletHelpAttributes;
using PnP.PowerShell.Commands.Model;
using System;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsLifecycle.Register, "PnPManagementShellAccess")]
    [CmdletHelp("Registers the multi-tenant app PnP Management Shell for delegate access to the required environments",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
       Code = "PS:> Register-PnPManagementShellAccess -SiteUrl https://yourtenant.sharepoint.com",
       Remarks = "Will prompt you to authenticate and if needed will ask you to provide consent to specific required rights.",
       SortOrder = 1)]
    public class RegisterPnPManagementShellAccess : PSCmdlet
    {
        [Parameter(Mandatory = false)]
        public AzureEnvironment AzureEnvironment = AzureEnvironment.Production;

        [Parameter(Mandatory = true)]
        public string SiteUrl;
        protected override void ProcessRecord()
        {
            var endPoint = GenericToken.GetAzureADLoginEndPoint(AzureEnvironment);
            var uri = new Uri(SiteUrl);
            var scopes = new[] { $"{uri.Scheme}://{uri.Authority}//.default" };

            var application = PublicClientApplicationBuilder.Create(PnPConnection.PnPManagementShellClientId).WithAuthority($"{endPoint}/organizations/").WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient").Build();

            var result = application.AcquireTokenInteractive(scopes).ExecuteAsync().GetAwaiter().GetResult();
            result = application.AcquireTokenInteractive(new[] { "https://graph.microsoft.com/.default" }).ExecuteAsync().GetAwaiter().GetResult();

        }
    }
}