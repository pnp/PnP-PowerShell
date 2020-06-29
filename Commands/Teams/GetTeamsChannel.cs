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
    [CmdletHelp("Gets the channels for a specified Team.",
       Category = CmdletHelpCategory.Teams,
       SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
      Code = "PS:> Get-PnPTeamsChannel -GroupId a6c1e0d7-f579-4993-81ab-4b666f8edea8",
      Remarks = "Retrieves all channels for the specified team",
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
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_Read_All)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class GetTeamsChannel : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public GuidPipeBind GroupId;

        protected override void ExecuteCmdlet()
        {
            WriteObject(TeamsUtility.GetChannels(AccessToken, HttpClient, GroupId.Id.ToString()));
        }
    }
}
