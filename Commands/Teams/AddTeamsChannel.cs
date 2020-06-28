using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Add, "PnPTeamsChannel")]
    [CmdletHelp("Adds a channel to an existing Microsoft Teams instance.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -GroupId 4efdf392-8225-4763-9e7f-4edeb7f721aa -DisplayName \"My Channel\"",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 1)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class AddTeamsChannel : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public string GroupId;

        [Parameter(Mandatory = true)]
        public string DisplayName;

        [Parameter(Mandatory = false)]
        public string Description;

        protected override void ExecuteCmdlet()
        {
            WriteObject(TeamsUtility.AddChannel(AccessToken, HttpClient, GroupId, DisplayName, Description));
        }
    }
}
