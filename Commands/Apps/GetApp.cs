#if !ONPREMISES
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using OfficeDevPnP.Core.ALM;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsCommon.Get, "PnPApp")]
    [CmdletHelp("Returns the available apps from the app catalog",
        Category = CmdletHelpCategory.Apps,
        OutputType = typeof(List<AppMetadata>), SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Get-PnPApp", Remarks = @"This will return all available app metadata from the tenant app catalog. It will list the installed version in the current site.", SortOrder = 1)]
    [CmdletExample(Code = @"PS:> Get-PnPApp -Identity 2646ccc3-6a2b-46ef-9273-81411cbbb60f", Remarks = @"This will the specific app metadata from the app catalog.", SortOrder = 2)]
    public class GetApp : PnPCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true, HelpMessage = "Specifies the Id of an app which is available in the app catalog")]
        public GuidPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var manager = new AppManager(ClientContext);

            var apps = manager.GetAvailable();
            if (MyInvocation.BoundParameters.ContainsKey("Identity"))
            {
                var app = apps.FirstOrDefault(a => a.Id == Identity.Id);
                
                if (app != null)
                {
                    WriteObject(app);
                }
                else
                {
                    throw new System.Exception("App not found");
                }
            }
            else
            {
                WriteObject(apps,true);
            }
        }
    }
}
#endif