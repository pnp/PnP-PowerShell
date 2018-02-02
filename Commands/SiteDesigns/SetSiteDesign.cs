#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Enums;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "PnPSiteDesign", SupportsShouldProcess = true)]
    [CmdletHelp(@"Updates a Site Design on the current tenant.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSiteDesign -Identity 046e2e76-67ba-46ca-a5f6-8eb418a7821e -Title ""My Updated Company Design""",
        Remarks = "Updates an existing Site Design and sets a new title.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> $design = Get-PnPSiteDesign -Identity 046e2e76-67ba-46ca-a5f6-8eb418a7821e
PS:> Set-PnPSiteDesign -Identity $design -Title ""My Updated Company Design""",
        Remarks = "Updates an existing Site Design and sets a new title.",
        SortOrder = 2)]
    public class SetSiteDesign : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The guid or an object representing the site design")]
        public TenantSiteDesignPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "The title of the site design")]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "An array of guids of site scripts")]
        public GuidPipeBind[] SiteScriptIds;

        [Parameter(Mandatory = false, HelpMessage = "The description of the site design")]
        public string Description;     

        [Parameter(Mandatory = false, HelpMessage = "Specifies if the site design is a default site design")]
        public SwitchParameter IsDefault;

        [Parameter(Mandatory = false, HelpMessage = "Sets the text for the preview image")]
        public string PreviewImageAltText;

        [Parameter(Mandatory = false, HelpMessage = "Sets the url to the preview image")]
        public string PreviewImageUrl;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the type of site to which this design applies")]
        public SiteWebTemplate WebTemplate;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the version of the design")]
        public int Version;


        protected override void ExecuteCmdlet()
        {
            var design = Tenant.GetSiteDesign(ClientContext, Identity.Id);
            ClientContext.Load(design);
            ClientContext.ExecuteQueryRetry();
            if (design != null)
            {
                var isDirty = false;
                if (MyInvocation.BoundParameters.ContainsKey("Title"))
                {
                    design.Title = Title;
                    isDirty = true;
                }
                if (MyInvocation.BoundParameters.ContainsKey("Description"))
                {
                    design.Description = Description;
                    isDirty = true;
                }
                if (MyInvocation.BoundParameters.ContainsKey("IsDefault"))
                {
                    design.IsDefault = IsDefault;
                    isDirty = true;
                }
                if (MyInvocation.BoundParameters.ContainsKey("PreviewImageAltText"))
                {
                    design.PreviewImageAltText = PreviewImageAltText;
                    isDirty = true;
                }
                if (MyInvocation.BoundParameters.ContainsKey("PreviewImageUrl"))
                {
                    design.PreviewImageUrl = PreviewImageUrl;
                    isDirty = true;
                }
                if(MyInvocation.BoundParameters.ContainsKey("WebTemplate"))
                {
                    design.WebTemplate = ((int)WebTemplate).ToString();
                    isDirty = true;
                }
                if(MyInvocation.BoundParameters.ContainsKey("Version"))
                {
                    design.Version = Version;
                    isDirty = true;
                }
                if(MyInvocation.BoundParameters.ContainsKey("SiteScriptIds"))
                {
                    design.SiteScriptIds = SiteScriptIds.Select(t => t.Id).ToArray();
                    isDirty = true;
                }
                if (isDirty)
                {
                    Tenant.UpdateSiteDesign(design);
                    ClientContext.ExecuteQueryRetry();
                    WriteObject(design);
                }
                WriteObject(design);
            } else
            {
                WriteError(new ErrorRecord(new ItemNotFoundException(), "SITEDESIGNNOTFOUND", ErrorCategory.ObjectNotFound, Identity));
            }
            
        }
    }
}         
#endif