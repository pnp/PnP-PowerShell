using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Branding
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
