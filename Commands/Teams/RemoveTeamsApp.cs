#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Model.Teams;
using SharePointPnP.PowerShell.Commands.Utilities;
using SharePointPnP.PowerShell.Commands.Utilities.REST;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPTeamsApp")]
    [CmdletHelp("Removes an app from the Teams AppCatalog.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Remove-PnPTeamsApp -Identity ac139d8b-fa2b-4ffe-88b3-f0b30158b58b",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Remove-PnPTeamsApp -Identity \"My Teams App\"",
       Remarks = "Adds a new channel to the specified Teams instance",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -Team MyTeam -DisplayName \"My Channel\" -Private",
       Remarks = "Adds a new private channel to the specified Teams instance",
       SortOrder = 3)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.AppCatalog_ReadWrite_All)]
    public class RemoveTeamsApp : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The id, externalid or display name of the app.")]
        public TeamsAppPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            var app = Identity.GetApp(HttpClient, AccessToken);
            if (app == null)
            {
                throw new PSArgumentException("App not found");
            }
            if (Force || ShouldContinue($"Do you want to remove {app.DisplayName}?", Properties.Resources.Confirm))
            {
                var response = TeamsUtility.DeleteApp(HttpClient, AccessToken, app.Id);
                if (!response.IsSuccessStatusCode)
                {
                    if (GraphHelper.TryGetGraphException(response, out GraphException ex))
                    {
                        if (ex.Error != null)
                        {
                            throw new PSInvalidOperationException(ex.Error.Message);
                        }
                    }
                    else
                    {
                        throw new PSInvalidOperationException("Removing app failed");
                    }
                }
                else
                {
                    WriteObject("App removed");
                }
            }
        }
    }
}
#endif