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
        [Parameter(Mandatory = false, HelpMessage = "Sets the logo of the web to the current url. If you want to set the logo to a modern team site, use Set-PnPSite -SiteLogoPath")]
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

        protected override void ExecuteCmdlet()
        {
            var dirty = false;

            foreach (var key in MyInvocation.BoundParameters.Keys)
            {
                switch (key)
                {
                    case "SiteLogoUrl":
                        SelectedWeb.SiteLogoUrl = SiteLogoUrl;
                        dirty = true;
                        break;

                    case "AlternateCssUrl":
                        SelectedWeb.AlternateCssUrl = AlternateCssUrl;
                        dirty = true;
                        break;

                    case "Title":
                        SelectedWeb.Title = Title;
                        dirty = true;
                        break;

                    case "Description":
                        SelectedWeb.Description = Description;
                        dirty = true;
                        break;

                    case "MasterUrl":
                        SelectedWeb.MasterUrl = MasterUrl;
                        dirty = true;
                        break;

                    case "CustomMasterUrl":
                        SelectedWeb.CustomMasterUrl = CustomMasterUrl;
                        dirty = true;
                        break;
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
