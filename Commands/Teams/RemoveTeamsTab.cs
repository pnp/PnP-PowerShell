using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPTeamsTab")]
    [CmdletHelp("Gets one or all tabs in a channel.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype",
       Remarks = "Retrieves the tabs for  the Microsoft Teams instances",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype -DisplayName \"Wiki\"",
       Remarks = "Retrieves a tab with the display name 'Wiki' from the specified team and channel",
       SortOrder = 2)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class RemoveTeamsTab : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Specify the group id of the team to retrieve.")]
        public GuidPipeBind GroupId;

        [Parameter(Mandatory = true, HelpMessage = "Specify the channel id of the team to retrieve.")]
        public string ChannelId;

        [Parameter(Mandatory = true, HelpMessage = "DisplayName")]
        public string TabId;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue("Removing the tab will remove the settings of this tab too.", Properties.Resources.Confirm))
            {
                if (!TeamsUtility.DeleteTab(AccessToken, HttpClient, GroupId.Id.ToString(), ChannelId, TabId))
                {
                    WriteError(new ErrorRecord(new Exception($"Tab remove failed"), "REMOVEFAILED", ErrorCategory.InvalidResult, this));
                }
            }
        }
    }
}
