#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Set, "PnPFooter")]
    [CmdletHelp("Configures the footer of the current web",
        DetailedDescription = "Allows the footer to be enabled or disabled and fine tuned in the current web",
        Category = CmdletHelpCategory.Branding,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPFooter -Enabled:$true",
        Remarks = "Enabled the footer to be shown on the current web",
        SortOrder = 1)]
    public class SetFooter : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Indicates if the footer should be shown on the current web ($true) or if it should be hidden ($false)", Position = 0)]
        public SwitchParameter Enabled;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.FooterEnabled = Enabled.ToBool();
            SelectedWeb.Update();
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif