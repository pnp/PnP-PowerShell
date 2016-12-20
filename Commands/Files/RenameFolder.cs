using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Utilities;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet(VerbsCommon.Rename, "PnPFolder")]
    [CmdletAlias("Rename-SPOFolder")]
    [CmdletHelp("Renames a folder",
        Category = CmdletHelpCategory.Files)]
    [CmdletExample(
        Code = @"PS:> Rename-PnPFolder -Folder Documents/Reports -TargetName 'Documents/Archived Reports'",
        Remarks = "This will rename the folder Reports in the Documents library to 'Archived Reports'",
        SortOrder = 1)]
    public class RenameFolder : SPOWebCmdlet
    {

        [Parameter(Mandatory = true, HelpMessage = "The folder to rename")]
        public string Folder = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "The new folder name")]
        public string TargetName = string.Empty;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            Folder sourceFolder = SelectedWeb.GetFolderByServerRelativeUrl(UrlUtility.Combine(SelectedWeb.ServerRelativeUrl, Folder));
            ClientContext.Load(sourceFolder, f => f.ServerRelativeUrl);
            ClientContext.ExecuteQueryRetry();

            sourceFolder.MoveTo(UrlUtility.Combine(SelectedWeb.ServerRelativeUrl, TargetName));
            ClientContext.ExecuteQueryRetry();
        }
    }
}
