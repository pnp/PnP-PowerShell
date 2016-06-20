#if !ONPREMISES
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPORequestAccessEmails")]
    [CmdletHelp("Sets Request Access Emails on a web",
       Category = CmdletHelpCategory.Webs)]
    public class SetRequestAccessEmails : SPOWebCmdlet
    {
        [Parameter(Mandatory = false)]
        public List<string> Emails;
        
        protected override void ExecuteCmdlet()
        {
            if (Emails != null && Emails.Count > 0)
            {
                SelectedWeb.EnsureProperty(w => w.HasUniqueRoleAssignments);

                // Can only set the Request Access Emails if the web has unique permissions
                if (SelectedWeb.HasUniqueRoleAssignments)
                {
                    SelectedWeb.EnableRequestAccess(Emails);
                }                
            }
        }
    }
}
#endif
