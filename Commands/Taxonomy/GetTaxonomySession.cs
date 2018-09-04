using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Taxonomy
{
    [Cmdlet(VerbsCommon.Get, "PnPTaxonomySession")]
    [CmdletHelp("Returns a taxonomy session",
        Category = CmdletHelpCategory.Taxonomy,
        OutputType = typeof(TaxonomySession),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.taxonomysession.aspx")]
    public class GetTaxonomySession : PnPWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var session = ClientContext.Site.GetTaxonomySession();
            ClientContext.Load(session.TermStores);
            ClientContext.ExecuteQueryRetry();
            WriteObject(session);
        }

    }
}
