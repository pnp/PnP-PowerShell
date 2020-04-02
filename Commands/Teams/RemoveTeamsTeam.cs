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
    [Cmdlet(VerbsCommon.Remove, "PnPTeamsTeam")]
    [CmdletHelp("Removes a Microsoft Teams Team",
       Category = CmdletHelpCategory.Teams,
       SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
      Code = "PS:> Remove-PnPTeamsTeam -Id 8fa4ba64-de77-42b4-8985-6bce49f173e6",
      Remarks = "Removes the team with the id specified after a confirmation question",
      SortOrder = 1)]
    public class RemoveTeamsTeam : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public GuidPipeBind Id;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All"))
            {
                if (Force || ShouldContinue("Removing the team will remove all channels, chats, files and the Office 365 group.", Properties.Resources.Confirm))
                {
                    TeamsUtility.DeleteTeam(AccessToken, Id.Id.ToString());
                }
            }
            else
            {
                WriteWarning("The current access token lacks the Group.ReadWrite.All permission scope");
            }

        }
    }
}
