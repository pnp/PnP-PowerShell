using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Collections.Generic;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Add, "PnPRoleDefinition")]
    [CmdletHelp("Adds a Role Defintion (Permission Level) to the site collection in the current context",
        DetailedDescription = "This command allows adding a custom Role Defintion (Permission Level) to the site collection in the current context. It does not replace or remove existing Role Definitions.",
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> Add-PnPRoleDefinition -RoleName ""CustomPerm""",
        Remarks = @"Creates additional permission level with no permission flags enabled.", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPRoleDefinition -RoleName ""NoDelete"" -Clone ""Contribute"" -Exclude ""DeleteListItems""",
        Remarks = @"Creates additional permission level by cloning ""Contribute"" and removes flags ""DeleteListItems""", SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Add-PnPRoleDefinition -RoleName ""AddOnly"" -Clone ""Contribute"" -Exclude ""DeleteListItems,EditListItems""",
        Remarks = @"Creates additional permission level by cloning ""Contribute"" and removes flags ""DeleteListItems,EditListItems""", SortOrder = 3)]

    public class AddSiteCollectionAdmin : PnPCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Name of new permission level.")]
        public string RoleName;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Name of existing permission level to clone as base template.")]
        public string Clone;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Specifies permission flags(s) to enable.")]
        public string Include;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Specifies permission flags(s) to disable.")]
        public string Exclude;

        protected override void ExecuteCmdlet()
        {
            // Validate user inputs
            var roleDefinition = ClientContext.Site.RootWeb.RoleDefinitions.GetByName(RoleName);
            ClientContext.Load(roleDefinition);
            ClientContext.ExecuteQuery();
            if (roleDefinition == null) {
                try {
                    // Prepare Role Definition Information
                    var spRoleDef = new Microsoft.SharePoint.Client.RoleDefinitionCreationInformation();
                    var spBasePerm = new Microsoft.SharePoint.Client.BasePermissions();

                    if (Clone) {
                        try {
                            var clonePerm = ClientContext.Site.RootWeb.RoleDefinitions.GetByName(Clone);
                        } catch {
                            WriteWarning($"Unable to add Role Defintion as clone name cannot be found.  Will be skipped.");
                            return;
                        }
                        var spBasePerm = clonePerm.BasePermissions;
                    }
					
					// Include and Exclude Flags
					foreach (string flag in Include.Split(",")) {
						spBasePerm.Set(flag)
					}
					foreach (string flag in Exclude.Split(",")) {
						spBasePerm.Clear(flag)
					}

                    // Create Role Definition
                    spRoleDef.Name = RoleName;
                    spRoleDef.Description = Description;
                    spRoleDef.BasePermissions = spBasePerm;
                    ClientContext.Site.RootWeb.RoleDefinitions.Add(spRoleDef);
                    ClientContext.ExecuteQuery();

                    WriteVerbose($"Role Definition (Permission Level) with the name $RoleName created");

                    // Echo created object
                    var roleDefinition = ClientContext.Site.RootWeb.RoleDefinitions.GetByName(RoleName);
                    ClientContext.Load(roleDefinition);
                    ClientContext.ExecuteQuery();
                    roleDefinition;
                } catch {

                }
            } else {
                 WriteWarning($"Unable to add Role Defintion as name already in use.  Will be skipped.");
            }
        }
    }
}