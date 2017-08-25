using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Pages;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    [Cmdlet(VerbsCommon.Add, "PnPClientSideWebPart")]
    [CmdletHelp("Adds a Client-Side Component to a page",
      Category = CmdletHelpCategory.ModernPages)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSideWebPart -Page 'OurNewPage' -Component 'HelloWorld'",
        Remarks = "Adds a Client-Side component 'HelloWorld' to the page called 'OurNewPage'",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPClientSideWebPart  -Page 'OurNewPage' -Component 'HelloWorld' -Zone 1 -Section 2",
        Remarks = "Adds a Client-Side component 'HelloWorld' to the page called 'OurNewPage' in zone 1 and section 2",
        SortOrder = 2)]
    public class AddClientSideWebPart : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page or the page in-memory instance.")]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = false, HelpMessage = "Defines a default WebPart type to insert. This takes precedence on the Component argument.")]
        public DefaultClientSideWebParts? DefaultWebPartType;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the component instance or Id to add.")]
        public ClientSideComponentPipeBind Component;
        
        [Parameter(Mandatory = false, HelpMessage = @"The properties of the WebPart")]
        public GenericPropertiesPipeBind WebPartProperties;

        [Parameter(Mandatory = false, HelpMessage = "Sets the order of the WebPart control. (Default = 1)")]
        public int Order = 1;

        [Parameter(Mandatory = false, HelpMessage = "Sets the section where to insert the WebPart control.")]
        public int? Section = null;

        [Parameter(Mandatory = false, HelpMessage = "Sets the column where to insert the WebPart control.")]
        public int? Column = null;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage(ClientContext);
            // If the client side page object cannot be found
            if (clientSidePage == null)
                throw new Exception($"Page {Page} cannot be found.");

            // If not enough arguments to add a webpart
            if (Component == null && !DefaultWebPartType.HasValue)
                throw new Exception("Insufficient arguments to add a WebPart");

            if (Component != null && DefaultWebPartType.HasValue)
                throw new Exception("Inconsistent arguments. cannot use Client Component and Default WebPart type at the same type");

            CanvasControl control = null;
            if (DefaultWebPartType.HasValue)
            {
                var webPart = clientSidePage.InstantiateDefaultWebPart(DefaultWebPartType.Value);
                if (WebPartProperties != null)
                {
                    if (WebPartProperties.Properties != null)
                    {
                        // Set all the WebPart properties
                        foreach (var propertyKey in WebPartProperties.Properties)
                            webPart.Properties[propertyKey] = JObject.Parse(WebPartProperties.Properties[propertyKey].ToString());
                    }
                    else if (!string.IsNullOrEmpty(WebPartProperties.Json))
                    {
                        webPart.PropertiesJson = WebPartProperties.Json;
                    }
                }
                control = webPart;
            }
            else
            // If a Component info is specified
            if (Component != null)
            {
                control = new ClientSideWebPart(Component.GetComponent(clientSidePage));
            }

            if (Section != null)
            {
                if (Column != null)
                {
                    clientSidePage.AddControl(control,
                                clientSidePage.Sections[Section.Value].Columns[Column.Value], Order);
                }
                else
                {
                    clientSidePage.AddControl(control, clientSidePage.Sections[Section.Value], Order);
                }
            }
            else
            {
                clientSidePage.AddControl(control, Order);
            }

            clientSidePage.Save();
        }
    }
}
