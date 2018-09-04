using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Add, "PnPProvisioningSite", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning sequence object to a provisioning hierarchy",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningSequence -Hierarchy $myhierarchy -Sequence $mysequence",
       Remarks = "Adds an existing sequence object to an existing hierarchy object",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> New-PnPProvisioningSequence -Id ""MySequence"" | Add-PnPProvisioningSequence -Hierarchy $hierarchy",
       Remarks = "Creates a new instance of a provisioning sequence object and sets the Id to the value specified, then the sequence is added to an existing hierarchy object",
       SortOrder = 2)]
    public class AddProvisioningSite : PnPCmdlet
    {
        [Parameter(Mandatory = true)]
        public ProvisioningSitePipeBind Site;

        [Parameter(Mandatory = true, HelpMessage = "The sequence to add the site to", ValueFromPipeline = true)]
        public ProvisioningSequence Sequence;

        protected override void ExecuteCmdlet()
        {
            Sequence.SiteCollections.Add(Site.Site);
            WriteObject(Sequence);
        }
    }
}
