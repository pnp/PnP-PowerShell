using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using File = Microsoft.SharePoint.Client.File;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet(VerbsCommon.Get, "PnPFolder")]
    [CmdletHelp("Return a folder object", Category = CmdletHelpCategory.Files,
        DetailedDescription = "Retrieves a folder if it exists. Use Ensure-PnPFolder to create the folder if it does not exist.",
        OutputType = typeof(Folder),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.folder.aspx")]
    [CmdletExample(
        Code = @"PS:> Get-PnPFolder -Url ""Shared Documents""",
        Remarks = "Returns the folder called 'Shared Documents' which is located in the root of the current web",
        SortOrder = 1
        )]
    [CmdletExample(
        Code = @"PS:> Get-PnPFolder -Url ""/sites/demo/Shared Documents""",
        Remarks = "Returns the folder called 'Shared Documents' which is located in the root of the current web",
        SortOrder = 1
        )]
    [CmdletRelatedLink(
        Text = "Ensure-PnPFolder",
        Url = "https://github.com/OfficeDev/PnP-PowerShell/blob/master/Documentation/EnsureSPOFolder.md")]
    public class GetFolder : PnPWebRetrievalsCmdlet<Folder>
    {
        private const string ParameterSet_FOLDERSINLIST = "Folders In List";
        private const string ParameterSet_FOLDERBYURL = "Folder By Url";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Site or server relative URL of the folder to retrieve. In the case of a server relative url, make sure that the url starts with the managed path as the current web.", ParameterSetName = ParameterSet_FOLDERBYURL)]
        [Alias("RelativeUrl")]
        public string Url;

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Site or server relative URL of the folder to retrieve. In the case of a server relative url, make sure that the url starts with the managed path as the current web.", ParameterSetName = ParameterSet_FOLDERSINLIST)]
        public ListPipeBind List;

        protected override void ExecuteCmdlet()
        {
#if !SP2013
            DefaultRetrievalExpressions = new Expression<Func<Folder, object>>[] { f => f.ServerRelativeUrl, f => f.Name, f => f.TimeLastModified, f => f.ItemCount };
#else
            DefaultRetrievalExpressions = new Expression<Func<Folder, object>>[] { f => f.ServerRelativeUrl, f => f.Name, f => f.ItemCount };
#endif
            if (List != null)
            {
                var list = List.GetList(SelectedWeb);
                CamlQuery query = CamlQuery.CreateAllItemsQuery();
                do
                {
                    var listItems = list.GetItems(query);
                    ClientContext.Load(listItems, item => item.Include(i => i.Folder));
                    ClientContext.ExecuteQueryRetry();

                    WriteObject(listItems, true);

                    query.ListItemCollectionPosition = listItems.ListItemCollectionPosition;
                } while (query.ListItemCollectionPosition != null);                
            }
            else
            {
                var webServerRelativeUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
                if (!Url.StartsWith(webServerRelativeUrl, StringComparison.OrdinalIgnoreCase))
                {
                    Url = UrlUtility.Combine(webServerRelativeUrl, Url);
                }
#if ONPREMISES
                var folder = SelectedWeb.GetFolderByServerRelativeUrl(Url);
#else
                var folder = SelectedWeb.GetFolderByServerRelativePath(ResourcePath.FromDecodedUrl(Url));
#endif
                folder.EnsureProperties(RetrievalExpressions);

                WriteObject(folder);
            }
        }
    }
}
