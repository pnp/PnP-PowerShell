#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPORequestAccessEmails")]
    [CmdletHelp("Returns the request access e-mail addresses",
        Category = CmdletHelpCategory.Webs)]
    public class GetRequestAccessEmails : SPOWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var emails = SelectedWeb.GetRequestAccessEmails();
            WriteObject(emails, true);
        }
    }
}
#endif