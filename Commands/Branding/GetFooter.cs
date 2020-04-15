#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Get, "PnPFooter")]
    [CmdletHelp("Gets the configuration regarding the footer of the current web",
        DetailedDescription = "Allows the current configuration of the footer in the current web to be retrieved. The footer currently only works on Modern Communication sites.",
        Category = CmdletHelpCategory.Branding,
        SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputType = typeof(Model.Footer))]
    [CmdletExample(
        Code = @"PS:> Get-PnPFooter",
        Remarks = "Returns the current footer configuration of the current web",
        SortOrder = 1)]
    public class GettFooter : PnPWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperties(w => w.FooterEnabled);

            var webFooterModel = new Model.Footer
            {
                IsEnabled = SelectedWeb.FooterEnabled
            };
            WriteObject(webFooterModel);
        }
    }
}
#endif