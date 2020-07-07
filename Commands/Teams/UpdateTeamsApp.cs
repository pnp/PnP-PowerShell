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
    [Cmdlet(VerbsData.Update, "PnPTeamsApp")]
    [CmdletHelp("Updates an existing app in the Teams App Catalog.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Update-PnPTeamsApp -Identity 4efdf392-8225-4763-9e7f-4edeb7f721aa -Path c:\\myapp.zip",
       Remarks = "Updates the specified app in the teams app catalog with the contents of the referenced zip file.",
       SortOrder = 1)]
    [CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission.Group_ReadWrite_All)]
    public class UpdateTeamsApp : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public TeamsAppPipeBind Identity;

        [Parameter(Mandatory = true, HelpMessage = "The path pointing to the packaged/zip file containing the app")]
        public string Path;

        protected override void ExecuteCmdlet()
        {
            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }

            if (System.IO.File.Exists(Path))
            {
                var app = Identity.GetApp(HttpClient, AccessToken);
                if (app != null)
                {

                    var bytes = System.IO.File.ReadAllBytes(Path);
                    var response = TeamsUtility.UpdateApp(HttpClient, AccessToken, bytes, app.Id);
                    if (!response.IsSuccessStatusCode)
                    {
                        if (GraphHelper.TryGetGraphException(response, out GraphException ex))
                        {
                            throw new PSInvalidOperationException(ex.Error.Message);
                        }
                        else
                        {
                            throw new PSInvalidOperationException("Update app failed");
                        }
                    }
                    else
                    {
                        WriteObject("App updated");
                    }
                }
                else
                {
                    throw new PSArgumentException("App not found");
                }
            }
            else
            {
                throw new PSArgumentException("File not found");
            }
        }
    }
}
#endif