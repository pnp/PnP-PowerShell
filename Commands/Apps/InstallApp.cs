#if !ONPREMISES
using OfficeDevPnP.Core.ALM;
using OfficeDevPnP.Core.Enums;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsLifecycle.Install, "PnPApp")]
    [CmdletHelp("Installs an available app from the app catalog",
        Category = CmdletHelpCategory.Apps, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Install-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe", 
        Remarks = @"This will install an app that is available in the tenant scoped app catalog, specified by the id, to the current site.", 
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Install-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -Scope Site",
        Remarks = @"This will install an app that is available in the site collection scoped app catalog, specified by the id, to the current site.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPAvailableApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe | Install-PnPApp", 
        Remarks = @"This will install the given app from the tenant scoped app catalog into the site.", 
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Get-PnPAvailableApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -Scope Site | Install-PnPApp",
        Remarks = @"This will install the given app from the site collection scoped app catalog into the site.",
        SortOrder = 4)]
    public class InstallApp : PnPCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Specifies the Id or an actual app metadata instance")]
        public AppMetadataPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Defines which app catalog to use. Defaults to Tenant")]
        public AppCatalogScope Scope = AppCatalogScope.Tenant;

        protected override void ExecuteCmdlet()
        {
            var manager = new AppManager(ClientContext);

            manager.Install(Identity.Id, Scope);
        }
    }
}
#endif