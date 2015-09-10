using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using System.Collections.Generic;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOSubWebs")]
    [CmdletHelp("Returns the subwebs", 
        Category = CmdletHelpCategory.Webs)]
    public class GetSubWebs : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public WebPipeBind Identity;

        [Parameter(Mandatory = false)]
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
                var subwebs = new List<Web>();
                subwebs.AddRange(webs);
                foreach (var subweb in webs)
                {
                    subwebs.AddRange(GetSubWebsInternal(subweb));
                }
                WriteObject(subwebs, true);
            }
        }

        private List<Web> GetSubWebsInternal(Web subweb)
        {
            var subwebs = new List<Web>();
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
