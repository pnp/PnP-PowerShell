using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet("Set", "SPOFileCheckedOut")]
    [CmdletHelp("Checks out a file",
        Category = CmdletHelpCategory.Files)]
    public class SetFileCheckedOut : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true)]
        public string Url = string.Empty;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.CheckOutFile(Url);
        }
    }
}
