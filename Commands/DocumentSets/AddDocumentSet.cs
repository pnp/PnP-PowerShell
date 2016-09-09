using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.DocumentSet;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.DocumentSets
{
    [Cmdlet(VerbsCommon.Add, "SPODocumentSet")]
    [CmdletHelp("Creates a new document set in a library.",
      Category = CmdletHelpCategory.DocumentSets)]
    [CmdletExample(
      Code = @"PS:> Add-SPODocumentSet -List ""Documents"" -ContentType ""Test Document Set"" -Name ""Test""",
      Remarks = "This will add a new document set based upon the 'Test Document Set' content type to a list called 'Documents'. The document set will be named 'Test'",
      SortOrder = 1)]
    public class AddDocumentSet : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        public ListPipeBind List;

        [Parameter(Mandatory = true)] public string Name;

        [Parameter(Mandatory = true)] public ContentTypePipeBind ContentType;
        protected override void ExecuteCmdlet()
        {
            var list = List.GetList(SelectedWeb);
            list.EnsureProperty(l => l.RootFolder);

            var result = DocumentSet.Create(ClientContext, list.RootFolder, Name, ContentType.GetContentType(SelectedWeb).Id);

            ClientContext.ExecuteQueryRetry();

            WriteObject(result.Value);
        }
    }
}
