using OfficeDevPnP.Core.Pages;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    [Cmdlet(VerbsCommon.Get, "PnPAvailableClientSideComponents")]
    [CmdletHelp("Gets the available client side components on a particular page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Get-PnPAvailableClientSideComponents $page",
        Remarks = "Gets the list of available client side components on the page $page",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPAvailableClientSideComponents -Identity MyPage.aspx",
        Remarks = "Gets the list of available client side components on the page 'MyPage.aspx'",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPAvailableClientSideComponents -Identity MyPage.aspx -ComponentName ""HelloWorld""",
        Remarks = "Gets the client side component 'HelloWorld' if available on the page 'MyPage.aspx'",
        SortOrder = 3)]
    public class GetAvailableClientSideComponents : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page or the page in-memory instance.")]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the component instance or Id to look for.")]
        public ClientSideComponentPipeBind Component;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage(ClientContext);
            
            if (Component == null)
            {
                var allComponents = clientSidePage.AvailableClientSideComponents().ToArray();
                WriteObject(allComponents, true);
            }
            else
            {
                WriteObject(Component.GetComponent(clientSidePage));
            }
        }
    }
}
