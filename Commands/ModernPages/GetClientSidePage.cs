#if !ONPREMISES

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
    [Cmdlet(VerbsCommon.Get, "PnPClientSidePage")]
    [CmdletHelp("Gets a Client-Side Page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage $page",
        Remarks = "Gets a new Modern Page (Client-Side) from the in-memory page instance",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage -Identity MyPage.aspx",
        Remarks = "Gets the Modern Page (Client-Side) called 'MyPage.aspx' in the current SharePoint site",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage MyPage",
        Remarks = "Gets the Modern Page (Client-Side) called 'MyPage.aspx' in the current SharePoint site",
        SortOrder = 2)]
    public class GetClientSidePage : PnPModernPageCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Identity.GetPage(ClientContext);
            if (clientSidePage == null)
                throw new Exception($"Page {Identity?.Name} does not exist");

            WriteObject(clientSidePage);
        }
    }
}
#endif