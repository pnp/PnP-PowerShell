using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Taxonomy
{
    [Cmdlet(VerbsCommon.Get, "SPOTaxonomyItem", SupportsShouldProcess = true)]
    [CmdletHelp(@"Returns a taxonomy item", 
        Category = CmdletHelpCategory.Taxonomy)]
    public class GetTaxonomyItem : SPOCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The path, delimited by | of the taxonomy item to retrieve, alike GROUPLABEL|TERMSETLABEL|TERMLABEL")]
        [Alias("Term")]
        public string TermPath;

        protected override void ExecuteCmdlet()
        {
            WriteObject(ClientContext.Site.GetTaxonomyItemByPath(TermPath));
        }

    }
}
