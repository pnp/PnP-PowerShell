#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "PnPSiteDesign", SupportsShouldProcess = true)]
    [CmdletHelp(@"Creates a new Site Design on the current tenant.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Add-PnPSiteDesign",
        Remarks = "Adds a new Site Design",
        SortOrder = 1)]
    public class AddSiteDesign : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The title of the site design")]
        public string Title;

        [Parameter(Mandatory = true, HelpMessage = "An array of guids of site scripts")]
        public GuidPipeBind[] SiteScriptIds;

        [Parameter(Mandatory = false, HelpMessage = "The description of the site design")]
        public string Description;     

        [Parameter(Mandatory = false, HelpMessage = "Specifies if the site design is a default site design")]
        public SwitchParameter IsDefault;

        [Parameter(Mandatory = false, HelpMessage = "Sets the text for the preview image")]
        public string PreviewImageAltText;

        [Parameter(Mandatory = false, HelpMessage = "Sets the url to the preview image")]
        public string PreviewImageUrl;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the webtemplate")]
        public string WebTemplate;


        protected override void ExecuteCmdlet()
        {
            TenantSiteDesignCreationInfo siteDesignInfo = new TenantSiteDesignCreationInfo
            {
                Title = Title,
                SiteScriptIds = SiteScriptIds.Select(t => t.Id).ToArray(),
                Description = Description,
                IsDefault = IsDefault,
                PreviewImageAltText = PreviewImageAltText,
                PreviewImageUrl = PreviewImageUrl,
                WebTemplate = WebTemplate
            };

            Tenant.CreateSiteDesign(siteDesignInfo);
            ClientContext.ExecuteQueryRetry();
        }
    }
}         
#endif