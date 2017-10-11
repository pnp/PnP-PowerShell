#if !ONPREMISES
using OfficeDevPnP.Core.ALM;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Apps
{
    [Cmdlet(VerbsCommon.Add, "PnPApp")]
    [CmdletHelp("Add/uploads an available app to the app catalog",
        Category = CmdletHelpCategory.Apps, SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputType = typeof(AppMetadata))]
    [CmdletExample(Code = @"PS:> Add-PnPApp -Path ./myapp.sppkg", Remarks = @"This will upload the specified app package to the app catalog", SortOrder = 1)]
    public class AddApp : PnPCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "Specifies the Id or an actual app metadata instance")]
        public string Path;

        protected override void ExecuteCmdlet()
        {
            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }

            var fileInfo = new System.IO.FileInfo(Path);

            var bytes = System.IO.File.ReadAllBytes(Path);

            var manager = new AppManager(ClientContext);

            var result = manager.Add(bytes, fileInfo.Name);

            WriteObject(result);
        }
    }
}
#endif