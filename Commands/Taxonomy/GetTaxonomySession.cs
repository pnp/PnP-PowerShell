using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Taxonomy
{
    [Cmdlet(VerbsCommon.Get, "SPOTaxonomySession")]
    [CmdletHelp("Returns a taxonomy session",
        Category = CmdletHelpCategory.Taxonomy)]
    public class GetTaxonomySession : SPOWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            WriteObject(ClientContext.Site.GetTaxonomySession());
        }

    }
}
