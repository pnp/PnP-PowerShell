using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPTeamsTeam")]
    [CmdletHelp("Gets one Office 365 Group (aka Unified Group) or a list of Office 365 Groups. Requires the Azure Active Directory application permission 'Group.Read.All'.",
        Category = CmdletHelpCategory.Graph,
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
    public class GetTeamsTeam : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false)]
        public string GroupId;

        [Parameter(Mandatory = false)]
        public TeamIncludes[] Includes;

        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.Read.All") || JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All"))
            {
                var includeChannels = false;
                var includeMessages = false;
                var includeApps = false;
                var includeSecurity = false;
                if (ParameterSpecified(nameof(Includes)))
                {
                    includeChannels = Includes.Contains(TeamIncludes.Channels);
                    includeApps = Includes.Contains(TeamIncludes.Apps);
                    includeSecurity = Includes.Contains(TeamIncludes.Security);
                }
                if (ParameterSpecified(nameof(GroupId)))
                {
                    WriteObject(TeamsUtility.GetTeam(AccessToken, GroupId, includeChannels, includeMessages, includeApps, includeSecurity));
                }
                else
                {
                    WriteObject(TeamsUtility.GetAllTeams(AccessToken, includeChannels, includeMessages, includeApps, includeSecurity), true);
                }
            }
            else
            {
                WriteWarning("The current access token lacks the Group.Read.All or equivalent permission scope");
            }
        }

        public enum TeamIncludes
        {
            Channels,
            Apps,
            Security
        }
    }
}
