using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOAuditing")]
    [CmdletHelp("Get the Auditing setting of a site",
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> Get-SPOAuditing",
        Remarks = "Gets the auditing settings of the current site",
        SortOrder = 1)]
    public class GetAuditing : SPOCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var audit = ClientContext.Site.Audit;
            ClientContext.Load(audit);
            ClientContext.ExecuteQueryRetry();
            WriteObject(audit);
        }
    }
}
