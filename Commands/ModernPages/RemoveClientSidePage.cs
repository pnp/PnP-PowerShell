using OfficeDevPnP.Core.Pages;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    [Cmdlet(VerbsCommon.Remove, "PnPClientSidePage")]
    [CmdletHelp("Removes a Client-Side Page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPClientSidePage $page",
        Remarks = "Removes the specified Modern Page (Client-Side).",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPClientSidePage -Identity MyPage",
        Remarks = "Removes the Modern Page (Client-Side) called 'MyPage.aspx'",
        SortOrder = 2)]
    public class RemoveClientSidePage : PnPModernPageCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue(Resources.RemoveClientSidePage, Resources.Confirm))
            {
                var clientSidePage = Identity.GetPage(ClientContext);
                if (clientSidePage == null)
                    throw new Exception($"Page {Identity?.Name} does not exist");

                clientSidePage.Delete();
            }
        }
    }
}
