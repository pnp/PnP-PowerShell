#if !ONPREMISES
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Add, "PnPProvisioningSequence", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning sequence object to a provisioning hierarchy",
        Category = CmdletHelpCategory.Provisioning, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningSequence -Hierarchy $myhierarchy -Sequence $mysequence",
       Remarks = "Adds an existing sequence object to an existing hierarchy object",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> New-PnPProvisioningSequence -Id ""MySequence"" | Add-PnPProvisioningSequence -Hierarchy $hierarchy",
       Remarks = "Creates a new instance of a provisioning sequence object and sets the Id to the value specified, then the sequence is added to an existing hierarchy object",
       SortOrder = 2)]
    public class AddProvisioningSequence : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The hierarchy to add the sequence to", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ProvisioningHierarchy Hierarchy;

        [Parameter(Mandatory = true, HelpMessage = "Optional Id of the sequence", ParameterSetName = ParameterAttribute.AllParameterSets, ValueFromPipeline = true)]
        public ProvisioningSequence Sequence;

        protected override void ProcessRecord()
        {
            if (Hierarchy.Sequences.FirstOrDefault(s => s.ID == Sequence.ID) == null)
            {
                Hierarchy.Sequences.Add(Sequence);
                WriteObject(Hierarchy);
            }
            else
            {
                WriteError(new ErrorRecord(new Exception($"Sequence with ID {Sequence.ID} already exists in hierarchy"), "DUPLICATESEQUENCEID", ErrorCategory.InvalidData, Sequence));
            }
        }
    }
}
#endif