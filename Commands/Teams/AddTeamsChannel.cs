#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Add, "PnPTeamsChannel")]
    [CmdletHelp("Adds a channel to an existing Microsoft Teams instance.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -TeamIdentity 4efdf392-8225-4763-9e7f-4edeb7f721aa -DisplayName \"My Channel\"",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 1)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class AddTeamsChannel : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Either group id (4efdf392-8225-4763-9e7f-4edeb7f721aa) or mailNickName of the group (e.g. 'mymailnickname'")]
        public TeamsTeamPipeBind TeamIdentity;

        [Parameter(Mandatory = true)]
        public string DisplayName;

        [Parameter(Mandatory = false)]
        public string Description;

        protected override void ExecuteCmdlet()
        {
            Model.Teams.TeamChannel channel = null;

            var groupId = TeamIdentity.GetGroupId(HttpClient, AccessToken);
            if (groupId != null)
            {
                channel = TeamsUtility.AddChannel(AccessToken, HttpClient, groupId, DisplayName, Description);
                WriteObject(channel);
            }
            
        }
    }
}
#endif