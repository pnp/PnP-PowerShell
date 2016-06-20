using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Enums;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsLifecycle.Disable, "SPOResponsiveUI")]
    [CmdletHelp("Disables the PnP Responsive UI implementation on a classic SharePoint Web", Category = CmdletHelpCategory.Branding)]
    [CmdletExample(Code = "PS:> Disable-SPOResponsiveUI",
    Remarks = @"If previous enabled, will remove the PnP Responsive UI from a site.",
    SortOrder = 1)]
    public class DisableResponsiveUI : SPOWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            SelectedWeb.DisableReponsiveUI();
        }
    }
}
