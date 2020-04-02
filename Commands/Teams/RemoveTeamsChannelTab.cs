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
      Code = "PS:> Remove-PnPTeamsChannelTab -Team 8fa4ba64-de77-42b4-8985-6bce49f173e6 -Channel  ",
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
    public class RemoveTeamsChannelTab : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public TeamPipeBind Team;

        [Parameter(Mandatory = true)]
        public string Channel;

        [Parameter(Mandatory = true)]
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
