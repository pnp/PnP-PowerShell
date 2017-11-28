#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "PnPSiteScript", SupportsShouldProcess = true)]
    [CmdletHelp(@"Creates a new Site Script on the current tenant.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Add-PnPSiteScript",
        Remarks = "Adds a new Site Script",
        SortOrder = 1)]
    public class AddSiteScript : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The title of the site design")]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "The description of the site design")]
        public string Description;     

        [Parameter(Mandatory = true, HelpMessage = "A JSON string containing the site script")]
        public string Content;

        protected override void ExecuteCmdlet()
        {
            TenantSiteScriptCreationInfo siteScriptCreationInfo = new TenantSiteScriptCreationInfo
            {
                Title = Title,
                Description = Description,
                Content = Content
            };
            Tenant.CreateSiteScript(siteScriptCreationInfo);
            ClientContext.ExecuteQueryRetry();
        }
    }
}         
#endif