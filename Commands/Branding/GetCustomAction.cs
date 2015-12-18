using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using OfficeDevPnP.PowerShell.Commands.Enums;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOCustomAction")]
    [CmdletHelp("Returns all or a specific custom action(s)", 
        Category = CmdletHelpCategory.Branding)]
    public class GetCustomAction : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Identity of the CustomAction to return. Omit to return all CustomActions.")]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Scope of the CustomAction, either Web, Site or All to return both")]
        public CustomActionScope Scope = CustomActionScope.Web;

        protected override void ExecuteCmdlet()
        {
            List<UserCustomAction> actions = new List<UserCustomAction>();

            if (Scope == CustomActionScope.All || Scope == CustomActionScope.Web)
            {
                actions.AddRange(SelectedWeb.GetCustomActions());
            }
            if (Scope == CustomActionScope.All || Scope == CustomActionScope.Site)
            {
                actions.AddRange(ClientContext.Site.GetCustomActions());
            }

            if (Identity != null)
            {
                var foundAction = actions.FirstOrDefault(x => x.Id == Identity.Id);
                WriteObject(foundAction, true);
            }
            else
            {
                WriteObject(actions,true);
            }
        }
    }
}
