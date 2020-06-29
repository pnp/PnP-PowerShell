using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Model.Teams;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPTeamsTab")]
    [CmdletHelp("Gets one or all tabs in a channel.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype",
       Remarks = "Retrieves the tabs for  the Microsoft Teams instances",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype -Identity \"Wiki\"",
       Remarks = "Retrieves a tab with the display name 'Wiki' from the specified team and channel",
       SortOrder = 2)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_Read_All)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class GetTeamsTab : PnPGraphCmdlet
    {

        [Parameter(Mandatory = true, HelpMessage = "Specify the group id of the team to retrieve.")]
        public GuidPipeBind GroupId;

        [Parameter(Mandatory = true, HelpMessage = "Specify the channel id of the team to retrieve.")]
        public string ChannelId;

        [Parameter(Mandatory = false, HelpMessage = "Identity")]
        public TeamTabPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Identity)))
            {
                var tabs = TeamsUtility.GetTabs(AccessToken, HttpClient, GroupId.Id.ToString(), ChannelId);
                if (tabs != null)
                {
                    TeamTab tab = null;
                    if (Identity.Id != Guid.Empty)
                    {
                        tab = tabs.FirstOrDefault(t => t.Id == Identity.Id.ToString());
                    }
                    else
                    {
                        tab = tabs.FirstOrDefault(t => t.DisplayName.Equals(Identity.DisplayName, System.StringComparison.OrdinalIgnoreCase));
                    }
                    WriteObject(tab);
                }
            }
            else
            {
                WriteObject(TeamsUtility.GetTabs(AccessToken, HttpClient, GroupId.Id.ToString(), ChannelId));
            }
        }
    }
}
