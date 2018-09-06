using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Get, "PnPProvisioningSite", SupportsShouldProcess = true)]
    [CmdletHelp("Returns one ore more provisioning sequence object(s) from a provisioning hierarchy",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Get-PnPProvisioningSite -Sequence $mysequence",
       Remarks = "Returns all sites from the specified sequence",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> Get-PnPProvisioningSite -Sequence $mysequence -Identity 8058ea99-af7b-4bb7-b12a-78f93398041e",
       Remarks = "Returns the specified site from the specified sequence",
       SortOrder = 2)]
    public class GetProvisioningSite : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The sequence to retrieve the site from", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ProvisioningSequence Sequence;

        [Parameter(Mandatory = false, HelpMessage = "Optional Id of the site", ParameterSetName = ParameterAttribute.AllParameterSets, ValueFromPipeline = true)]
        public ProvisioningSitePipeBind Identity;
        protected override void ProcessRecord()
        {
            if (!MyInvocation.BoundParameters.ContainsKey("Identity"))
            {
                WriteObject(Sequence.SiteCollections, true);
            }
            else
            {
                WriteObject(Identity.GetSiteFromSequence(Sequence));
            }
        }
    }
}
