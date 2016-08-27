using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.New, "SPOProvisioningTemplate", SupportsShouldProcess = true)]
    [CmdletHelp("Creates a new provisioning template object",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
       Code = @"PS:> $template = New-SPOProvisioningTemplate",
       Remarks = "Creates a new instance of a provisioning template object.",
       SortOrder = 1)]
    public class NewProvisioningTemplate : SPOWebCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = new ProvisioningTemplate();
            WriteObject(result);
        }
    }
}
