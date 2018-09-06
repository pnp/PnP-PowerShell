using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Get, "PnPProvisioningSequence", SupportsShouldProcess = true)]
    [CmdletHelp("Returns one ore more provisioning sequence object(s) from a provisioning hierarchy",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Get-PnPProvisioningSequence -Hierarchy $myhierarchy",
       Remarks = "Returns all sequences from the specified hierarchy",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> Get-PnPProvisioningSequence -Hierarchy $myhierarchy -Identity ""mysequence""",
       Remarks = "Returns the specified sequence from the specified hierarchy",
       SortOrder = 2)]
    public class GetProvisioningSequence : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The hierarchy to retrieve the sequence from", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ProvisioningHierarchy Hierarchy;

        [Parameter(Mandatory = false, HelpMessage = "Optional Id of the sequence", ParameterSetName = ParameterAttribute.AllParameterSets, ValueFromPipeline = true)]
        public ProvisioningSequencePipeBind Identity;
        protected override void ProcessRecord()
        {
            if (!MyInvocation.BoundParameters.ContainsKey("Identity"))
            {
                WriteObject(Hierarchy.Sequences, true);
            }
            else
            {
                WriteObject(Identity.GetSequenceFromHierarchy(Hierarchy));
            }
        }
    }
}
