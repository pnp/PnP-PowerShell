using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.New, "PnPProvisioningHierarchy", SupportsShouldProcess = true)]
    [CmdletHelp("Creates a new provisioning hierarchy object",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> $hierarchy = New-PnPProvisioningHierarchy",
       Remarks = "Creates a new instance of a provisioning hierarchy object.",
       SortOrder = 1)]
    public class NewProvisioningHierarchy : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = new ProvisioningHierarchy();
            WriteObject(result);
        }
    }
}
