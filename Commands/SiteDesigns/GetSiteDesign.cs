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
    [Cmdlet(VerbsCommon.Get, "PnPSiteDesign", SupportsShouldProcess = true)]
    [CmdletHelp(@"Retrieve Site Designs that have been registered on the current tenant.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteDesign",
        Remarks = "Returns all registered site designs",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteDesign -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd",
        Remarks = "Returns a specific registered site designs",
        SortOrder = 2)]
    public class GetSiteDesign : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true, HelpMessage = "If specified will retrieve the specified site design")]
        public TenantSiteDesignPipeBind Identity;

        protected override void ExecuteCmdlet()
        {

            var designs = Tenant.GetSiteDesigns();
            ClientContext.Load(designs);
            ClientContext.ExecuteQueryRetry();
            if (MyInvocation.BoundParameters.ContainsKey("Identity"))
            {
                var design = designs.FirstOrDefault(t => t.Id == Identity.Id);
                WriteObject(design);
            }
            else
            {
                WriteObject(designs.ToList(), true);
            }
        }
    }
}         
#endif