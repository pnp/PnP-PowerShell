using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Remove, "PnPRoleDefinition")]
    [CmdletHelp("Remove the Role Definitions of a site",
        Category = CmdletHelpCategory.Sites,
        OutputType = typeof(RoleDefinition),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.roledefinition.aspx")]
    [CmdletExample(
        Code = @"PS:> Remove-PnPRoleDefinition",
        Remarks = "Removes the Role Definition (Permission Level) from the current site",
        SortOrder = 1)]
    public class RemoveRoleDefinition : PnPCmdlet
    {
		[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Specifies owner(s) to remove as site collection adminstrators. Can be both users and groups.")]
		public string RoleName;	
		
        protected override void ExecuteCmdlet()
        {
            var roleDefinition = ClientContext.Site.RootWeb.RoleDefinitions.GetByName(RoleName);
            ClientContext.Load(roleDefinition);
            ClientContext.ExecuteQueryRetry();
            if (roleDefinition != null) {
                try
                {
                    roleDefinition.Delete();
                    ClientContext.ExecuteQueryRetry();
                    WriteVerbose("Removed Role Definition \"{RoleName}\"")
                }
                catch (ServerException e)
                {
                    WriteWarning($"Exception occurred while trying to remove the Role Definition: \"{e.Message}\". Will be skipped.");
                }
            }
            else
            {
                WriteWarning($"Unable to remove Role Definition as it wasn't found. Will be skipped.");
            }
        }
    }
}
