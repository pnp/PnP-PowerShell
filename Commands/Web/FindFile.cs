using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Find, "SPOFile")]
    [CmdletHelp("Finds a file in the virtual file system of the web.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:> Find-SPOFile -Match *.master", 
        Remarks = "Will return all masterpages located in the current web.",
        SortOrder = 1)]
    public class FindFile : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Wildcard query", ValueFromPipeline = true)]
        public string Match = string.Empty;

        protected override void ExecuteCmdlet()
        {
            WriteObject(SelectedWeb.FindFiles(Match));
        }
    }
}
