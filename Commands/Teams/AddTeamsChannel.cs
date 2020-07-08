#if !ONPREMISES
using PnP.PowerShell.CmdletHelpAttributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Base.PipeBinds;
using PnP.PowerShell.Commands.Model.Teams;
using PnP.PowerShell.Commands.Utilities;
using System.Management.Automation;

namespace PnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Add, "PnPTeamsChannel")]
    [CmdletHelp("Adds a channel to an existing Microsoft Teams instance.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -Team 4efdf392-8225-4763-9e7f-4edeb7f721aa -DisplayName \"My Channel\"",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -Team MyTeam -DisplayName \"My Channel\"",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -Team MyTeam -DisplayName \"My Channel\" -Private",
       Remarks = "Adds a new private channel to the specified Teams instance",
       SortOrder = 3)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class AddTeamsChannel : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Specify the group id, mailNickname or display name of the team to use.")]
        public TeamsTeamPipeBind Team;

        [Parameter(Mandatory = true, HelpMessage = "The display name of the new channel. Letters, numbers and spaces are allowed.")]
        public string DisplayName;

        [Parameter(Mandatory = false, HelpMessage = "An optional description of the channel.")]
        public string Description;

        [Parameter(Mandatory = false, HelpMessage = "Specify to mark the channel as private.")]
        public SwitchParameter Private;

        protected override void ExecuteCmdlet()
        {
            Model.Teams.TeamChannel channel = null;

            var groupId = Team.GetGroupId(HttpClient, AccessToken);
            if (groupId != null)
            {
                try
                {
                    channel = TeamsUtility.AddChannel(AccessToken, HttpClient, groupId, DisplayName, Description, Private);
                    WriteObject(channel);
                }
                catch (GraphException ex)
                {
                    if (ex.Error != null)
                    {
                        throw new PSInvalidOperationException(ex.Error.Message);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                throw new PSArgumentException("Group not found");
            }

        }
    }
}
#endif