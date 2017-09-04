using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "PnPSubWebs")]
    [CmdletHelp("Returns the subwebs of the current web", 
        Category = CmdletHelpCategory.Webs,
        OutputType = typeof(WebCollection),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.web.aspx")]
    public class GetSubWebs : PnPWebRetrievalsCmdlet<WebCollection>
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public WebPipeBind Identity;

        [Parameter(Mandatory = false)]
        public SwitchParameter Recurse;

        protected override void ExecuteCmdlet()
        {
            DefaultRetrievalExpressions = new Expression<Func<WebCollection, object>>[] { wc => wc.Include(w => w.Id, w => w.Url, w => w.Title, w => w.ServerRelativeUrl) };

            SelectedWeb.Webs.EnsureProperties(RetrievalExpressions);
            if (!Recurse)
            {
                WriteObject(SelectedWeb.Webs, true);
            }
            else
            {
                var subwebs = new List<Web>();
                subwebs.AddRange(SelectedWeb.Webs);
                foreach (var subweb in SelectedWeb.Webs)
                {
                    subwebs.AddRange(GetSubWebsInternal(subweb));
                }
                WriteObject(subwebs, true);
            }
        }

        private List<Web> GetSubWebsInternal(Web subweb)
        {
            var subwebs = new List<Web>();
            subweb.Webs.EnsureProperties(RetrievalExpressions);
            subwebs.AddRange(subweb.Webs);
            foreach (var sw in subweb.Webs)
            {
                subwebs.AddRange(GetSubWebsInternal(sw));
            }
            return subwebs;
        }
    }
}
