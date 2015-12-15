using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Enums;
using System;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOJavaScriptLink")]
    [CmdletHelp("Adds a link to a JavaScript file to a web or sitecollection",
        Category = CmdletHelpCategory.Branding)]
    public class AddJavaScriptLink : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Name under which to register the JavaScriptLink")]
        [Alias("Key")]
        public string Name = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "URL to the JavaScript file to inject")]
        public string[] Url = null;

        [Parameter(Mandatory = false, HelpMessage = "Sequence of this JavaScript being injected. Use when you have a specific sequence with which to have JavaScript files being added to the page. I.e. jQuery library first and then jQueryUI.")]
        public int Sequence = 0;

        [Parameter(Mandatory = false)]
        [Obsolete("Use Scope")]
        [Alias("AddToSite")]
        public SwitchParameter SiteScoped;

        [Parameter(Mandatory = false, HelpMessage = "Defines if this JavaScript file will be injected to every page within the current site collection or web. Default is web.")]
        public CustomActionScope Scope = CustomActionScope.Web;

        protected override void ExecuteCmdlet()
        {
            // Following code to handle desprecated parameter
            CustomActionScope setScope;

            if (MyInvocation.BoundParameters.ContainsKey("SiteScoped"))
            {
                setScope = CustomActionScope.Site;
            }
            else
            {
                setScope = Scope;
            }

            if (setScope == CustomActionScope.Web)
            {
                SelectedWeb.AddJsLink(Name, Url, Sequence);
            }
            else
            {
                var site = ClientContext.Site;
                site.AddJsLink(Name, Url, Sequence);
            }
        }
    }
}
