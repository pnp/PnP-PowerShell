#if !ONPREMISES

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Pages;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    [Cmdlet(VerbsCommon.New, "PnPClientSidePage")]
    [CmdletHelp("Creates a new Client-Side Page object",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> New-PnPClientSidePage",
        Remarks = "Creates a new Modern Page (Client-Side) in-memory instance",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> New-PnPClientSidePage MyPage.aspx",
        Remarks = "Creates a new Modern Page (Client-Side) in-memory instance with a name MyPage.aspx",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> New-PnPClientSidePage -Name MyPage.aspx",
        Remarks = "Creates a new Modern Page (Client-Side) in-memory instance with a name MyPage.aspx",
        SortOrder = 3)]
    public class NewClientSidePage : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, HelpMessage = "Sets the name of the page once it is saved.")]
        public string Name = null;

        protected override void ExecuteCmdlet()
        {
            ClientSidePage clientSidePage = SelectedWeb.AddClientSidePage(
                ModernPagesUtilities.EnsurePageName(Name), false);
            WriteObject(clientSidePage);
        }
    }
}
#endif