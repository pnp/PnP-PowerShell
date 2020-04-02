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
    [Cmdlet(VerbsCommon.Remove, "PnPTeamsChannelTab")]
    [CmdletHelp("Removes the specified tab from a Microsoft Teams Channel.",
       Category = CmdletHelpCategory.Teams,
       SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
      Code = "PS:> Remove-PnPTeamsChannelTab -Team 8fa4ba64-de77-42b4-8985-6bce49f173e6 -Channel 19:796d063b63e34497aeaf092c8fb9b44e@thread.skype -Tab 5f2c46a9-33de-4ae8-a7d1-5053b1006178",
      Remarks = "Removes the specified tab from a teams channel.",
      SortOrder = 1)]
    public class RemoveTeamsChannelTab : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The id of the team which contains the channel to remove the tab from.")]
        public TeamPipeBind Team;

        [Parameter(Mandatory = true, HelpMessage = "The id of the channel to remove the tab from.")]
        public string Channel;

        [Parameter(Mandatory = true, HelpMessage = "The id of the tab to remove.")]
        public string Tab;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All"))
            {
                if (ParameterSpecified(nameof(Team)))
                {
                    if (Force || ShouldContinue("Remove?", Properties.Resources.Confirm))
                    {
                        TeamsUtility.DeleteTab(AccessToken, Team.GetTeamId(), Channel, Tab);
                    }
                }
            }
            else
            {
                WriteWarning("The current access token lacks the Group.ReadWrite.All permission scope");
            }

        }
    }
}
