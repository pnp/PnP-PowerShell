#if !ONPREMISES
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Add, "PnPProvisioningTemplate", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning template object to a provisioning hierarchy",
        Category = CmdletHelpCategory.Provisioning, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningTemplate -Hierarchy $myhierarchy -Template $mytemplate",
       Remarks = "Adds an existing sequence object to an existing hierarchy object",
       SortOrder = 1)]
    public class AddProvisioningTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The template to add to the hierarchy")]
        public ProvisioningTemplate Template;

        [Parameter(Mandatory = true, HelpMessage = "The hierarchy to add the template to", ValueFromPipeline = true)]
        public ProvisioningHierarchy Hierarchy;

        protected override void ProcessRecord()
        {
            if(Hierarchy.Templates.FirstOrDefault(t => t.Id == Template.Id) == null)
            {
                Hierarchy.Templates.Add(Template);
            } else { 
                WriteError(new ErrorRecord(new Exception($"Template with ID {Template.Id} already exists in hierarchy"), "DUPLICATETEMPLATE", ErrorCategory.InvalidData, Template));
            }
        }
    }
}
#endif