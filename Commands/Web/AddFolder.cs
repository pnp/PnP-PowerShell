using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOFolder")]
    [CmdletHelp("Creates a folder within a parent folder",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:> Add-SPOFolder -Name NewFolder -Folder _catalogs/masterpage/newfolder",
        SortOrder = 1)]
    public class AddFolder : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The folder name")]
        public string Name = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "The parent folder in the site")]
        public string Folder = string.Empty;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
            
            Folder folder = SelectedWeb.GetFolderByServerRelativeUrl(UrlUtility.Combine(SelectedWeb.ServerRelativeUrl, Folder));
            ClientContext.Load(folder, f => f.ServerRelativeUrl);
            ClientContext.ExecuteQueryRetry();

            folder.CreateFolder(Name);
        }
    }
}
