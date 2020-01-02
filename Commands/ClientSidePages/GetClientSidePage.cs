#if !SP2013 && !SP2016
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.ClientSidePages
{
    [Cmdlet(VerbsCommon.Get, "PnPClientSidePage")]
    [CmdletHelp("Gets a Client-Side Page",
      Category = CmdletHelpCategory.ClientSidePages, SupportedPlatform = CmdletSupportedPlatform.Online | CmdletSupportedPlatform.SP2019)]
     [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage -Identity ""MyPage.aspx""",
        Remarks = "Gets the Modern Page (Client-Side) named 'MyPage.aspx' in the current SharePoint site",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage ""MyPage""",
        Remarks = "Gets the Modern Page (Client-Side) named 'MyPage.aspx' in the current SharePoint site",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage ""Templates/MyPageTemplate""",
        Remarks = "Gets the Modern Page (Client-Side) named 'MyPageTemplate.aspx' from the templates folder of the Page Library in the current SharePoint site",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSidePage -Identity ""MyPage.aspx"" -Web (Get-PnPWeb -Identity ""Subsite1"")",
        Remarks = "Gets the Modern Page (Client-Side) named 'MyPage.aspx' from the subsite named 'Subsite1'",
        SortOrder = 4)]
    public class GetClientSidePage : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page")]
        public ClientSidePagePipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Identity.GetPage((Microsoft.SharePoint.Client.ClientContext)SelectedWeb.Context);

            if (clientSidePage == null)
                throw new Exception($"Page '{Identity?.Name}' does not exist");

            WriteObject(clientSidePage);
        }
    }
}
#endif