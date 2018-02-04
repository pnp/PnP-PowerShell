using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Get, "PnPRoleDefinition")]
    [CmdletHelp("Get the Role Definitions of a site",
        Category = CmdletHelpCategory.Sites,
        OutputType = typeof(RoleDefinition),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.roledefinition.aspx")]
    [CmdletExample(
        Code = @"PS:> Get-PnPRoleDefinition",
        Remarks = "Gets the Role Definitions (Permission Levels) settings of the current site",
        SortOrder = 1)]
    public class GetRoleDefinition : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var roleDefinitions = ClientContext.Site.RootWeb.roleDefinitions;
            ClientContext.Load(roleDefinitions);
            ClientContext.ExecuteQueryRetry();
            WriteObject(roleDefinitions);
        }
    }
}
