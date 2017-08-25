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
    [Cmdlet(VerbsCommon.Add, "PnPClientSideText")]
    [CmdletHelp("Adds a Client-Side Page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSideText -Page 'OurNewPage' -Text 'Hello World!'",
        Remarks = "Adds the text 'Hello World!' on the Modern Page 'OurNewPage'",
        SortOrder = 1)]
    public class AddClientSideText : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page or the page in-memory instance.")]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = true, HelpMessage = "Specifies the text to display in the text area.")]
        public string Text;

        [Parameter(Mandatory = false, HelpMessage = "Sets the order of the text control. (Default = 1)")]
        public int Order = 1;

        [Parameter(Mandatory = false, HelpMessage = "Sets the section where to insert the text control.")]
        public int? Section = null;

        [Parameter(Mandatory = false, HelpMessage = "Sets the column where to insert the text control.")]
        public int? Column = null;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage(ClientContext);

            if (clientSidePage == null)
                // If the client side page object cannot be found
                throw new Exception($"Page {Page} cannot be found.");

            var text = new ClientSideText() { Text = Text };
            if (Section != null)
            {
                if (Column != null)
                {
                    clientSidePage.AddControl(text,
                    clientSidePage.Sections[Section.Value].Columns[Column.Value], Order);
                }
                else
                {
                    clientSidePage.AddControl(text, clientSidePage.Sections[Section.Value], Order);
                }
            }
            else
            {
                clientSidePage.AddControl(text, Order);
            }

            // Save the page
            clientSidePage.Save();
        }
    }
}
