using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.New, "PnPSiteTemplate", SupportsShouldProcess = true)]
    [Alias("New-PnPProvisioningTemplate")]
    [CmdletHelp("Creates a new site template object",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> $template = New-PnPSiteTemplate",
       Remarks = "Creates a new instance of a site template object.",
       SortOrder = 1)]
    public class NewSiteTemplate : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var result = new ProvisioningTemplate();
            WriteObject(result);
        }
    }
}
