using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "PnPWeb")]
    [CmdletHelp("Sets properties on a web", DetailedDescription = "Sets properties on a web",
        Category = CmdletHelpCategory.Webs)]
    public class SetWeb : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Sets the logo of the web to the current url. If you want to set the logo to a modern team site, use Set-PnPSite -LogoFilePath.")]
        public string SiteLogoUrl;

        [Parameter(Mandatory = false)]
        public string AlternateCssUrl;

        [Parameter(Mandatory = false)]
        public string Title;

        [Parameter(Mandatory = false)]
        public string Description;

        [Parameter(Mandatory = false)]
        public string MasterUrl;

        [Parameter(Mandatory = false)]
        public string CustomMasterUrl;

#if !ONPREMISES
        [Parameter(Mandatory = false)]
        public HeaderLayoutType HeaderLayout = HeaderLayoutType.Standard;

        [Parameter(Mandatory = false)]
        public SPVariantThemeType HeaderEmphasis = SPVariantThemeType.None;

#endif

        protected override void ExecuteCmdlet()
        {
            var dirty = false;

            foreach (var key in MyInvocation.BoundParameters.Keys)
            {
                switch (key)
                {
                    case nameof(SiteLogoUrl):
                        SelectedWeb.SiteLogoUrl = SiteLogoUrl;
                        dirty = true;
                        break;

                    case nameof(AlternateCssUrl):
                        SelectedWeb.AlternateCssUrl = AlternateCssUrl;
                        dirty = true;
                        break;

                    case nameof(Title):
                        SelectedWeb.Title = Title;
                        dirty = true;
                        break;

                    case nameof(Description):
                        SelectedWeb.Description = Description;
                        dirty = true;
                        break;

                    case nameof(MasterUrl):
                        SelectedWeb.MasterUrl = MasterUrl;
                        dirty = true;
                        break;

                    case nameof(CustomMasterUrl):
                        SelectedWeb.CustomMasterUrl = CustomMasterUrl;
                        dirty = true;
                        break;
#if !ONPREMISES
                    case nameof(HeaderLayout):
                        SelectedWeb.HeaderLayout = HeaderLayout;
                        dirty = true;
                        break;

                    case nameof(HeaderEmphasis):
                        SelectedWeb.HeaderEmphasis = HeaderEmphasis;
                        dirty = true;
                        break;
#endif
                }
            }

            if (dirty)
            {
                SelectedWeb.Update();
                ClientContext.ExecuteQueryRetry();
            }
        }
    }

}
