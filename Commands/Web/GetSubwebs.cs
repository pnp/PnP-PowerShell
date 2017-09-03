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
        //    else
        //    {
        //        var subwebs = new List<web>();
        //        subwebs.AddRange(webs);
        //        foreach (var subweb in webs)
        //        {
        //            subwebs.AddRange(GetSubWebsInternal(subweb));
        //        }
        //        WriteObject(subwebs, true);
        //    }
        }

        //private List<web> GetSubWebsInternal(web subweb)
        //{
        //    var subwebs = new List<web>();
        //    var webs = subweb.Context.LoadQuery(subweb.Webs);
        //    subweb.Context.ExecuteQueryRetry();
        //    subwebs.AddRange(webs);
        //    foreach (var sw in webs)
        //    {
        //        subwebs.AddRange(GetSubWebsInternal(sw));
        //    }
        //    return subwebs;
        //}
    }
}
