using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Teams
{
    [Cmdlet(VerbsCommon.Get, "PnPTeamsChannel")]
    [CmdletHelp("Gets all of a specific channel from a specific team.",
       Category = CmdletHelpCategory.Teams,
       SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
      Code = "PS:> Get-PnPTeamsChannel -Team 27c42116-6645-419a-a66e-e30f762e7607",
      Remarks = "Returns all channels for the specified team",
      SortOrder = 1)]
    [CmdletExample(
      Code = "PS:> Get-PnPTeamsChannel -Team 27c42116-6645-419a-a66e-e30f762e7607 -Channel 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype",
      Remarks = "Returns a specific channel for a team",
      SortOrder = 2)]
    public class GetTeamsChannel : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public TeamPipeBind Team;

        [Parameter(Mandatory = false)]
        public string Channel;

        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.Read.All"))
            {
                if (ParameterSpecified(nameof(Team)))
                {
                    var channels = TeamsUtility.GetChannels(AccessToken, Team.GetTeamId());
                    if (ParameterSpecified(nameof(Channel)))
                    {
                        WriteObject(channels.FirstOrDefault(c => c.DisplayName == Channel || c.ID == Channel));
                    }
                    else
                    {
                        WriteObject(channels, true);
                    }
                }
            }
            else
            {
                WriteWarning("The current access token lacks the Group.Read.All permission.");
            }
        }
    }
}
