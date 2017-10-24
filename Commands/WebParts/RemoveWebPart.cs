using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.WebParts;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.WebParts
{
    [Cmdlet(VerbsCommon.Remove, "PnPWebPart")]
    [CmdletHelp("Removes a webpart from a page",
        Category = CmdletHelpCategory.WebParts)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPWebPartToWikiPage -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -Identity a2875399-d6ff-43a0-96da-be6ae5875f82",
        Remarks = @"This will remove the webpart as defined by the XML in the listview.webpart file to the specified page in the first row and the first column of the HTML table present on the page",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPWebPartToWikiPage -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -Name MyWebpart",
        Remarks = @"This will remove the webpart as defined by the XML in the listview.webpart file to the specified page in the first row and the first column of the HTML table present on the page",
        SortOrder = 1)]
    public class RemoveWebPart : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ID", HelpMessage = "The Guid of the webpart")]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = true, ParameterSetName = "NAME", HelpMessage = "The name of the webpart")]
        [Alias("Name")]
        public string Title = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = ParameterAttribute.AllParameterSets, HelpMessage = "Full server relative url of the webpart page, e.g. /sites/demo/sitepages/home.aspx")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }


            if (ParameterSetName == "NAME")
            {
                SelectedWeb.DeleteWebPart(ServerRelativePageUrl, Title);
            }
            else
            {
                var wps = SelectedWeb.GetWebParts(ServerRelativePageUrl);
                var wp = from w in wps where w.Id == Identity.Id select w;
                var webPartDefinitions = wp as WebPartDefinition[] ?? wp.ToArray();
                if(webPartDefinitions.Any())
                {
                    webPartDefinitions.FirstOrDefault().DeleteWebPart();
                    ClientContext.ExecuteQueryRetry();
                }
            }
        }
    }
}
