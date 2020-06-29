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
    [Cmdlet(VerbsCommon.Get, "PnPTeamsApp")]
    [CmdletHelp("Gets one Microsoft Teams App or a list of all apps.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsApp",
       Remarks = "Retrieves all the Microsoft Teams Apps",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTeam -GroupId $groupId",
       Remarks = "Retrieves a specific Microsoft Teams instance",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPTeamsTeam -Visibility Public",
       Remarks = "Retrieves all Microsoft Teams instances which are public visible",
       SortOrder = 2)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Directory_ReadWrite_All | MicrosoftGraphApiPermission.AppCatalog_Read_All)]
    public class GetTeamsApp: PnPGraphCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Specify the name, id or external id of the app.")]
        public TeamsAppPipeBind Identity;
        
        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Identity)))
            {
                var apps = TeamsUtility.GetApps(AccessToken, HttpClient);
                if (Identity.Id != Guid.Empty)
                {
                    WriteObject(apps.FirstOrDefault(a => a.Id == Identity.Id.ToString() || a.ExternalId == a.Id.ToString()));
                }
                else
                {
                    WriteObject(apps.FirstOrDefault(a => a.DisplayName.Equals(Identity.StringValue, StringComparison.OrdinalIgnoreCase)));
                }
            }
            else
            {
                WriteObject(TeamsUtility.GetApps(AccessToken, HttpClient), true);
            }
        }
    }
}
