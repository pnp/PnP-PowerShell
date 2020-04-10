using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Framework.Provisioning.Model.Teams;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Set, "PnPTeamsTeam")]
    [CmdletHelp("Gets one Office 365 Group (aka Unified Group) or a list of Office 365 Groups. Requires the Azure Active Directory application permission 'Group.Read.All' and the Graph permission 'User.Read.All'.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup",
       Remarks = "Retrieves all the Office 365 Groups",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupId",
       Remarks = "Retrieves a specific Office 365 Group based on its ID",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupDisplayName",
       Remarks = "Retrieves a specific or list of Office 365 Groups that start with the given DisplayName",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupSiteMailNickName",
       Remarks = "Retrieves a specific or list of Office 365 Groups for which the email starts with the provided mail nickName",
       SortOrder = 4)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $group",
       Remarks = "Retrieves a specific Office 365 Group based on its object instance",
       SortOrder = 5)]
    public class SetTeamsTeam : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public TeamPipeBind Id;

        [Parameter(Mandatory = false)]
        public string DisplayName;

        [Parameter(Mandatory = false)]
        public string MailNickName;

        [Parameter(Mandatory = false)]
        public string Description;

        [Parameter(Mandatory = false)]
        public bool AllowGiphy;

        [Parameter(Mandatory = false)]
        public bool AllowStickersAndMemes;

        [Parameter(Mandatory = false)]
        [ValidateSet("Strict", "Moderate")]
        public string GiphyContentRating = "Strict";

        [Parameter(Mandatory = false)]
        public bool AllowCustomMemes;

        // Guest settings
        [Parameter(Mandatory = false)]
        public bool AllowGuestsDeleteChannels;

        [Parameter(Mandatory = false)]
        public bool AllowGuestsUpdateChannels;

        // Member settings
        [Parameter(Mandatory = false)]
        public bool AllowMembersDeleteChannels;

        [Parameter(Mandatory = false)]
        public bool AllowMembersCreateUpdateChannels;

        [Parameter(Mandatory = false)]
        public bool AllowMembersAddRemoveApps;

        [Parameter(Mandatory = false)]
        public bool AllowMembersCreatePrivateChannels;

        [Parameter(Mandatory = false)]
        public bool AllowMembersUpdateRemoveConnectors;

        [Parameter(Mandatory = false)]
        public bool AllowMembersCreateUpdateRemoveTabs;

        [Parameter(Mandatory = false)]
        public bool AllowChannelMentions;
        [Parameter(Mandatory = false)]
        public bool AllowOwnerDeleteMessages;
        [Parameter(Mandatory = false)]
        public bool AllowTeamMentions;
        [Parameter(Mandatory = false)]
        public bool AllowUserDeleteMessages;
        [Parameter(Mandatory = false)]
        public bool AllowUserEditMessages;

        [Parameter(Mandatory = false)]
        public TeamVisibility Visibility = TeamVisibility.Private;


        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All") && JwtUtility.HasScope(AccessToken,"User.Read.All"))
            {
                var funSettings = new TeamFunSettings()
                {
                    AllowCustomMemes = AllowCustomMemes,
                    AllowGiphy = AllowGiphy,
                    AllowStickersAndMemes = AllowStickersAndMemes,
                    GiphyContentRating = GiphyContentRating,
                };
                var guestSettings = new TeamGuestSettings()
                {
                    AllowCreateUpdateChannels = AllowGuestsUpdateChannels,
                    AllowDeleteChannels = AllowGuestsDeleteChannels,
                };
                var memberSettings = new TeamMemberSettings()
                {
                    AllowAddRemoveApps = AllowMembersAddRemoveApps,
                    AllowCreatePrivateChannels = AllowMembersCreatePrivateChannels,
                    AllowCreateUpdateChannels = AllowMembersCreateUpdateChannels,
                    AllowCreateUpdateRemoveConnectors = AllowMembersUpdateRemoveConnectors,
                    AllowCreateUpdateRemoveTabs = AllowMembersCreateUpdateRemoveTabs,
                    AllowDeleteChannels = AllowMembersDeleteChannels
                };
                var messagingSettings = new TeamMessagingSettings()
                {
                    AllowChannelMentions = AllowChannelMentions,
                    AllowOwnerDeleteMessages = AllowOwnerDeleteMessages,
                    AllowTeamMentions = AllowTeamMentions,
                    AllowUserDeleteMessages = AllowUserDeleteMessages,
                    AllowUserEditMessages = AllowUserEditMessages
                };
                TeamsUtility.UpdateTeam(AccessToken, Id.GetTeamId(), DisplayName, MailNickName, Description, funSettings, guestSettings, memberSettings, messagingSettings, Visibility);
            }
            else
            {
                WriteWarning("The current access token lacks the Group.ReadWrite.All permission scope");
            }
        }
    }
}
