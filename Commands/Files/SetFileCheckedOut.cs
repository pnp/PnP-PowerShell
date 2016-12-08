using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet("Set", "PnPFileCheckedOut")]
    [CmdletAlias("Set-SPOFileCheckedOut")]
    [CmdletHelp("Checks out a file",
        Category = CmdletHelpCategory.Files)]
    [CmdletExample(
        Code = @"Set-PnPFileCheckedOut -Url /sites/testsite/subsite/Pages/default.aspx",
        Remarks = @"Checks out a file supplied with a server relative Url",
        SortOrder = 1)]   
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
