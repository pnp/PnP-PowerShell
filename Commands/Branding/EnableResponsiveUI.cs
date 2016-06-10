using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Enums;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsLifecycle.Enable, "SPOResponsiveUI")]
    [CmdletHelp("Enables the PnP Responsive UI implementation on a classic SharePoint Web", Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code="PS:> Enable-SPOResponsiveUI",
        SortOrder = 1,
        Remarks="Will upload a CSS file, a JavaScript file and adds a custom action to the current web, enabling the responsive UI on that web. The CSS and JavaScript files are located in the style library, in a folder called SP.Responsive.UI.")]

    public class EnableResponsiveUI : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "A full URL pointing to an infrastructure site. If specified, it will add a custom action pointing to the responsive UI JS code in that site.")]
        public string InfrastructureSiteUrl;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnableResponsiveUI(InfrastructureSiteUrl);
        }
    }
}
