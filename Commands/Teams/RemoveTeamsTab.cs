using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPTeamsTab")]
    [CmdletHelp("Removes a Microsoft Teams tab in a channel.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Remove-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype -Identity Wiki",
       Remarks = "Removes the tab with the display name 'Wiki' from the channel",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Remove-PnPTeamsTab -GroupId 5beb63c5-0571-499e-94d5-3279fdd9b6b5 -ChannelId 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype -Identity fcef815d-2e8e-47a5-b06b-9bebba5c7852",
       Remarks = "Removes a tab with the specified id from the channel",
       SortOrder = 2)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class RemoveTeamsTab : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Specify the group id of the team to retrieve.")]
        public GuidPipeBind GroupId;

        [Parameter(Mandatory = true, HelpMessage = "Specify the channel id of the team to retrieve.")]
        public string ChannelId;

        [Parameter(Mandatory = true, HelpMessage = "Identity")]
        public TeamsTabPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue("Removing the tab will remove the settings of this tab too.", Properties.Resources.Confirm))
            {
                var tabId = string.Empty;
                if(Identity.Id != Guid.Empty)
                {
                    tabId = Identity.Id.ToString();
                } else
                {
                    var tabs = TeamsUtility.GetTabs(AccessToken, HttpClient, GroupId.Id.ToString(), ChannelId);
                    var tab = tabs.FirstOrDefault(t => t.DisplayName.Equals(Identity.DisplayName, StringComparison.OrdinalIgnoreCase));
                    if(tab != null)
                    {
                        tabId = tab.Id;
                    } else
                    {
                        throw new PSArgumentException("Cannot find tab");
                    }
                }
                if (!TeamsUtility.DeleteTab(AccessToken, HttpClient, GroupId.Id.ToString(), ChannelId, tabId))
                {
                    throw new PSInvalidOperationException("Tab remove failed");
                }
            }
        }
    }
}
