#if !ONPREMISES
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.New, "PnPProvisioningSequence", SupportsShouldProcess = true)]
    [CmdletHelp("Creates a new provisioning sequence object",
        Category = CmdletHelpCategory.Provisioning, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> $sequence = New-PnPProvisioningSequence",
       Remarks = "Creates a new instance of a provisioning sequence object.",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> $sequence = New-PnPProvisioningSequence -Id ""MySequence""",
       Remarks = "Creates a new instance of a provisioning sequence object and sets the Id to the value specified.",
       SortOrder = 2)]
    public class NewProvisioningSequence : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Optional Id of the sequence", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string Id;
        protected override void ProcessRecord()
        {
            var result = new ProvisioningSequence();
            if (this.MyInvocation.BoundParameters.ContainsKey("Id"))
            {
                result.ID = Id;
            } else
            {
                result.ID = $"sequence-{Guid.NewGuid()}";
            }
            WriteObject(result);
        }
    }
}
#endif