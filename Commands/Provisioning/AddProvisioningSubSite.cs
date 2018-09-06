using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Add, "PnPProvisioningSubSite", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning sequence object to a provisioning site object",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningSequence -Hierarchy $myhierarchy -Sequence $mysequence",
       Remarks = "Adds an existing sequence object to an existing hierarchy object",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> New-PnPProvisioningSequence -Id ""MySequence"" | Add-PnPProvisioningSequence -Hierarchy $hierarchy",
       Remarks = "Creates a new instance of a provisioning sequence object and sets the Id to the value specified, then the sequence is added to an existing hierarchy object",
       SortOrder = 2)]
    public class AddProvisioningSubSite : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public TeamNoGroupSubSite SubSite;

        [Parameter(Mandatory = true, HelpMessage = "The sequence to add the site to", ValueFromPipeline = true)]
        public SiteCollection Site;

        protected override void ProcessRecord()
        {
            if (Site.Sites.Cast<TeamNoGroupSubSite>().FirstOrDefault(s => s.Url == SubSite.Url) == null)
            {
                Site.Sites.Add(SubSite);
            } else
            {
                WriteError(new ErrorRecord(new Exception($"Site with URL {SubSite.Url} already exists in sequence"), "DUPLICATEURL", ErrorCategory.InvalidData, SubSite));
            }
        }
    }
}
