using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Add, "PnPTeamsUser")]
    [CmdletHelp("Adds a new user to an existing team. Requires the Azure Active Directory application permission 'Group.ReadWrite.All'.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -TeamId 27c42116-6645-419a-a66e-e30f762e7607 -DisplayName 'My Test Channel' -Description 'A description'",
       Remarks = "Adds a new channel to the specified team.",
       SortOrder = 1)]
    public class AddTeamsUser : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The Group/Team id of the team to add the channel to.")]
        [Alias("GroupId")]
        public GuidPipeBind TeamId;

        [Parameter(Mandatory = true, HelpMessage = "The name of the channel to add")]
        public string User;

        [Parameter(Mandatory = false, HelpMessage = "An optional description of the channel")]
        [ValidateSet("Member", "Owner")]
        public string Role = "Member";

        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All"))
            {

                //var id = TeamsUtility.AddUser(AccessToken, TeamId.Id.ToString(), DisplayName, Description);
                //WriteObject(new { Id = id, DisplayName, Description });

            }
            else
            {
                WriteWarning("The current access token lacks the Group.ReadWrite.All permission scope");
            }
        }
    }
}
