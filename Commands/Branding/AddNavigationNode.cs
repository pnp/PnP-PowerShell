using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.Commands.Enums;
using System;
using System.Management.Automation;
using OfficeDevPnP.Core.Enums;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPONavigationNode")]
    [CmdletHelp("Adds a menu item to either the quicklaunch or top navigation", Category = "Branding")]
    public class AddNavigationNode : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The location of the node to add. Either TopNavigationBar, QuickLaunch or SearchNav")]
        public NavigationType Location;

        [Parameter(Mandatory = true, HelpMessage = "The title of the node to add")]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "The url to navigate to when clicking the new menu item.")]
        public string Url;

        [Parameter(Mandatory = false, HelpMessage = "Optionally value of a header entry to add the menu item to.")]
        public string Header;

        protected override void ExecuteCmdlet()
        {
            if (Url == null)
            {
                ClientContext.Load(SelectedWeb, w => w.Url);
                ClientContext.ExecuteQueryRetry();
                Url = SelectedWeb.Url;
            }
            SelectedWeb.AddNavigationNode(Title, new Uri(Url), Header, Location);
        }

    }


}
