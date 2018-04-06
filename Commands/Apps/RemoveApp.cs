#if !ONPREMISES
using OfficeDevPnP.Core.Enums;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsCommon.Remove, "PnPApp")]
    [CmdletHelp("Removes an app from the app catalog", SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.Apps)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe", 
        Remarks = @"This will remove the specified app from the tenant scoped app catalog", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -Scope Site",
        Remarks = @"This will remove the specified app from the site collection scoped app catalog", SortOrder = 2)]
    public class RemoveApp : PnPCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Specifies the Id of the Addin Instance")]
        public AppMetadataPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Defines which app catalog to use. Defaults to Tenant")]
        public AppCatalogScope Scope = AppCatalogScope.Tenant;

        protected override void ExecuteCmdlet()
        {
            var manager = new OfficeDevPnP.Core.ALM.AppManager(ClientContext);

            manager.Remove(Identity.Id, Scope);
        }
    }
}
#endif