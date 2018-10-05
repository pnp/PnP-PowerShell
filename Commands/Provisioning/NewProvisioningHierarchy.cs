#if !ONPREMISES
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.New, "PnPProvisioningHierarchy", SupportsShouldProcess = true)]
    [CmdletHelp("Creates a new provisioning hierarchy object",
        Category = CmdletHelpCategory.Provisioning, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> $hierarchy = New-PnPProvisioningHierarchy",
       Remarks = "Creates a new instance of a provisioning hierarchy object.",
       SortOrder = 1)]
    public class NewProvisioningHierarchy : PSCmdlet
    {
        [Parameter(Mandatory = false)]
        public string Author;

        [Parameter(Mandatory = false)]
        public string Description;

        [Parameter(Mandatory = false)]
        public string DisplayName;

        [Parameter(Mandatory = false)]
        public string Generator;

        protected override void ProcessRecord()
        {
            var result = new ProvisioningHierarchy();
            result.Author = Author;
            result.Description = Description;
            result.DisplayName = DisplayName;
            result.Generator = Generator;
            WriteObject(result);
        }
    }
}
#endif