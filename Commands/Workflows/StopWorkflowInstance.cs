using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Workflows
{
    [Cmdlet(VerbsLifecycle.Stop, "PnPWorkflowInstance")]
    [CmdletHelp("Stops a workflow instance",
        Category = CmdletHelpCategory.Workflows)]
    [CmdletExample(
        Code = @"Stop-PnPWorkflowInstance -identity $wfInstance", 
        Remarks = "Stops the workflow Instance, this can be the Guid of the instance or the instance itself.",
        SortOrder = 1)]
    public class StopWorkflowInstance : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The instance to stop", Position = 0)]
        public WorkflowInstancePipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            if (Identity.Instance != null)
            {
                Identity.Instance.CancelWorkFlow();
            }
            else if (Identity.Id != Guid.Empty)
            {
                var allinstances = SelectedWeb.GetWorkflowInstances();
                foreach (var instance in allinstances.Where(instance => instance.Id == Identity.Id))
                {
                    instance.CancelWorkFlow();
                    break;
                }
            }
        }
    }


}
