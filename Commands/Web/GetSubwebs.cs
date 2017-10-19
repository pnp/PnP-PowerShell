using System.Management.Automation;
using Microsoft.SharePoint.Client;
using web = Microsoft.SharePoint.Client.Web;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "PnPSubWebs")]
    [CmdletHelp("Returns the subwebs of the current web", 
        Category = CmdletHelpCategory.Webs,
        OutputType = typeof(List<web>),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.web.aspx")]
    [CmdletExample(
        Code = @"PS:> Get-PnPSubWebs",
        Remarks = "This will return all sub webs for the current web",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSubWebs -recurse",
        Remarks = "This will return all sub webs for the current web and it sub webs",
        SortOrder = 2)]
    public class GetSubWebs : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "The guid of the web or web object")]
        public WebPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "include subweb of the subwebs")]
        public SwitchParameter Recurse;

        protected override void ExecuteCmdlet()
        {
            var webs = SelectedWeb.Context.LoadQuery(SelectedWeb.Webs);
            SelectedWeb.Context.ExecuteQueryRetry();
            if (!Recurse)
            {
                WriteObject(webs, true);
            }
            else
            {
                var subwebs = new List<web>();
                subwebs.AddRange(webs);
                foreach (var subweb in webs)
                {
                    subwebs.AddRange(GetSubWebsInternal(subweb));
                }
                WriteObject(subwebs, true);
            }
        }

        private List<web> GetSubWebsInternal(web subweb)
        {
            var subwebs = new List<web>();
            var webs = subweb.Context.LoadQuery(subweb.Webs);
            subweb.Context.ExecuteQueryRetry();
            subwebs.AddRange(webs);
            foreach (var sw in webs)
            {
                subwebs.AddRange(GetSubWebsInternal(sw));
            }
            return subwebs;
        }
    }
}
