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
    [Cmdlet(VerbsCommon.Add, "PnPClientSidePage")]
    [CmdletHelp("Adds a Client-Side Page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSidePage -PageName 'OurNewPage'",
        Remarks = "Creates a new Modern Page (Client-Side) called 'OurNewPage'",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSidePage",
        Remarks = "Creates a new Modern Page (Client-Side) in-memory instance that need to be explicitly saved to be persisted in SharePoint",
        SortOrder = 2)]
    public class AddClientSidePage : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page or the page in-memory instance.")]
        public ClientSidePagePipeBind Identity;

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
           
            ClientSidePage clientSidePage = null;
            if (Identity != null)
            {
                clientSidePage = Identity.GetPage(ClientContext);
                // If the page already exists
                if (clientSidePage != null)
                    throw new Exception($"Page {Identity} already exists...");

            }

            // We need to have the page name, if not found, raise an error
            string name = ModernPagesUtilities.EnsurePageName(Name ?? Identity?.Name);

            // Create a page that persists immediately
            clientSidePage = SelectedWeb.AddClientSidePage(name);
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