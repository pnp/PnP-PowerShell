#if !ONPREMISES

using Microsoft.SharePoint.Client;
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
    [Cmdlet(VerbsCommon.Set, "PnPClientSidePage")]
    [CmdletHelp("Sets parameters of a Client-Side Page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Set-PnPClientSidePage -Identity 'MyPage' -LayoutType Home",
        Remarks = "Updates the properties of the Modern Page (Client-Side) called 'OurNewPage'",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSidePage",
        Remarks = "Creates a new Modern Page (Client-Side) in-memory instance that need to be explicitly saved to be persisted in SharePoint",
        SortOrder = 2)]
    public class SetClientSidePage : PnPModernPageCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Spcifies the chosen name of the page.")]
        public string Name = null;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the layout type of the page.")]
        public ClientSidePageLayoutType LayoutType = ClientSidePageLayoutType.Article;

        [Parameter(Mandatory = false, HelpMessage = "Allows to promote the page for a specific purpose (HomePage | NewsPage)")]
        public EPagePromoteType PromoteAs = EPagePromoteType.None;

        [Parameter(Mandatory = false, HelpMessage = "Enables or Disables the comments on the page")]
        public bool? CommentsEnabled = null;

        [Parameter(Mandatory = false, HelpMessage = "Publishes the page once it is saved.")]
        public SwitchParameter Publish;

        [Parameter(Mandatory = false, HelpMessage = "Sets the message for publishing the page.")]
        public string PublishMessage = string.Empty;

        protected override void ExecuteCmdlet()
        {
            ClientSidePage clientSidePage = Identity?.GetPage(ClientContext);

            if (clientSidePage == null)
                // If the client side page object cannot be found
                throw new Exception($"Page {Identity?.Name} cannot be found.");

            // We need to have the page name, if not found, raise an error
            string name = ModernPagesUtilities.EnsurePageName(Name ?? Identity?.Name, false);
            if (name == null)
                throw new Exception("Insufficient arguments to add a client side page");

            clientSidePage.LayoutType = LayoutType;
            clientSidePage.Save(name);

            // If a specific promote type is specified, promote the page as Home or Article or ...
            switch (PromoteAs)
            {
                case EPagePromoteType.HomePage:
                    clientSidePage.PromoteAsHomePage();
                    break;
                case EPagePromoteType.NewsArticle:
                    clientSidePage.PromoteAsNewsArticle();
                    break;
                case EPagePromoteType.None:
                default:
                    break;
            }

            if (CommentsEnabled.HasValue)
            {
                if (CommentsEnabled.Value)
                {
                    clientSidePage.EnableComments();
                }
                else
                {
                    clientSidePage.DisableComments();
                }
            }

            if (Publish)
            {
                clientSidePage.Publish(PublishMessage);
            }

            WriteObject(clientSidePage);
        }
    }
}
#endif