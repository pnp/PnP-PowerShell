#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Set, "PnPFooter")]
    [CmdletHelp("Configures the footer of the current web",
        DetailedDescription = "Allows the footer to be enabled or disabled and fine tuned in the current web. For modifying the navigation links shown in the footer, use Add-PnPNavigationNode -Location Footer.",
        Category = CmdletHelpCategory.Branding,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPFooter -Enabled:$true",
        Remarks = "Enables the footer to be shown on the current web",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPFooter -Enabled:$true -Layout Extended -BackgroundTheme Neutral",
        Remarks = "Enables the footer to be shown on the current web with the extended layout using a neutral background",
        SortOrder = 2)]
    public class SetFooter : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Indicates if the footer should be shown on the current web ($true) or if it should be hidden ($false)")]
        public SwitchParameter Enabled;

        [Parameter(Mandatory = false, HelpMessage = "Defines how the footer should look like")]
        public FooterLayoutType Layout;

        [Parameter(Mandatory = false, HelpMessage = "Defines the background emphasis of the content in the footer")]
        public FooterVariantThemeType BackgroundTheme;

        protected override void ExecuteCmdlet()
        {
            bool isDirty = false;

            if (ParameterSpecified(nameof(Enabled)))
            {
                SelectedWeb.FooterEnabled = Enabled.ToBool();
                isDirty = true;
            }

            if (ParameterSpecified(nameof(Layout)))
            {
                SelectedWeb.FooterLayout = Layout;
                isDirty = true;
            }

            if (ParameterSpecified(nameof(BackgroundTheme)))
            {
                SelectedWeb.FooterEmphasis = BackgroundTheme;
                isDirty = true;
            }
            
            if (isDirty)
            {
                SelectedWeb.Update();
                ClientContext.ExecuteQueryRetry();
            }
        }
    }
}
#endif