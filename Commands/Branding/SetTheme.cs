using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using Newtonsoft.Json;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOTheme")]
    [CmdletHelp("Sets the theme of the current web.",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code = @"PS:> Set-SPOTheme -ColorPaletteUrl /_catalogs/theme/15/company.spcolor",
        SortOrder = 1)]
    public class SetTheme : SPOWebCmdlet
    {
        private const string PROPBAGKEY = "_PnP_ProvisioningTemplateComposedLookInfo";

        [Parameter(Mandatory = false)]
        public string ColorPaletteUrl = null;

        [Parameter(Mandatory = false)]
        public string FontSchemeUrl = null;

        [Parameter(Mandatory = false)]
        public string BackgroundImageUrl = null;

        [Parameter(Mandatory = false)]
        public SwitchParameter ShareGenerated = false;

        protected override void ExecuteCmdlet()
        {

            SelectedWeb.ApplyTheme(ColorPaletteUrl, FontSchemeUrl, BackgroundImageUrl, ShareGenerated);

            ClientContext.ExecuteQueryRetry();

            var composedLook = new ComposedLook();
            // Set the corresponding property bag value which is used by the provisioning engine
            if (SelectedWeb.PropertyBagContainsKey(PROPBAGKEY))
            {
                composedLook = JsonConvert.DeserializeObject<ComposedLook>(SelectedWeb.GetPropertyBagValueString(PROPBAGKEY, ""));

            }
            else
            {
                composedLook = new ComposedLook();
                composedLook.BackgroundFile = "";
                SelectedWeb.EnsureProperty(w => w.AlternateCssUrl);
                composedLook.AlternateCSS = SelectedWeb.AlternateCssUrl;
                composedLook.ColorFile = "";
                SelectedWeb.EnsureProperty(w => w.MasterUrl);
                composedLook.MasterPage = SelectedWeb.MasterUrl;
                composedLook.FontFile = "";
                SelectedWeb.EnsureProperty(w => w.SiteLogoUrl);
                composedLook.SiteLogo = SelectedWeb.SiteLogoUrl;
            }

            composedLook.Name = composedLook.Name ?? "Custom by PnP PowerShell";
            composedLook.ColorFile = ColorPaletteUrl ?? composedLook.ColorFile;
            composedLook.FontFile = FontSchemeUrl ?? composedLook.FontFile;
            composedLook.BackgroundFile = BackgroundImageUrl ?? composedLook.BackgroundFile;
            var composedLookJson = JsonConvert.SerializeObject(composedLook);

            SelectedWeb.SetPropertyBagValue(PROPBAGKEY, composedLookJson);
        }
    }
}
