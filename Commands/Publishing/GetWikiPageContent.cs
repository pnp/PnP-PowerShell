using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Publishing
{
    [Cmdlet(VerbsCommon.Get, "SPOWikiPageContent")]
    [CmdletHelp("Gets the contents/source of a wiki page",
        Category = CmdletHelpCategory.Publishing)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWikiPageContent -PageUrl '/sites/demo1/pages/wikipage.aspx'",
        Remarks = "Gets the content of the page '/sites/demo1/pages/wikipage.aspx'",
        SortOrder = 1)]
    public class GetWikiPageContent : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Position=0, HelpMessage = "The server relative URL for the wiki page")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        protected override void ExecuteCmdlet()
        {
            WriteObject(SelectedWeb.GetWikiPageContent(ServerRelativePageUrl));
        }
    }
}
