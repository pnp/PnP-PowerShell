#if !ONPREMISES
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPORequestAccessEmails")]
    [CmdletHelp("Returns the request access e-mail addresses",
        Category = CmdletHelpCategory.Webs,
        OutputType = typeof(List<string>))]
    [CmdletExample(
       Code = @"PS:> Get-SPORequestAccessEmails",
       Remarks = "This will return all the request access e-mail addresses for the current web",
       SortOrder = 1)]
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