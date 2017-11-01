using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client.Workflow;
using Microsoft.SharePoint.Client.WorkflowServices;

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

        [Parameter(Mandatory = false, HelpMessage = "Force.  Use TerminateWorkflow instead of Cancel Workflow")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {

            WorkflowServicesManager workflowServicesManager = new WorkflowServicesManager(ClientContext, SelectedWeb);
            InteropService interopService = workflowServicesManager.GetWorkflowInteropService();
            WorkflowInstanceService instanceService = workflowServicesManager.GetWorkflowInstanceService();

            if (Identity.Instance != null)
            {
                WriteVerbose("Instance object set");
                WriteVerbose("Cancelling workflow  ID: " + Identity.Instance.Id);
                if(Force)
                {
                    instanceService.TerminateWorkflow(Identity.Instance);
                }
                else
                {
                    Identity.Instance.CancelWorkFlow();
                }
                ClientContext.ExecuteQuery();
            }
            else if (Identity.Id != Guid.Empty)
            {
                WriteVerbose("Instance object not set.  Looking up site workflows by GUID: " + Identity.Id);
                var allinstances = SelectedWeb.GetWorkflowInstances();
                foreach (var instance in allinstances.Where(instance => instance.Id == Identity.Id))
                {
                    WriteVerbose("Cancelling workflow  ID: " + Identity.Instance.Id);
                    if (Force)
                    {
                        instanceService.TerminateWorkflow(instance);
                    }
                    else
                    {
                        instance.CancelWorkFlow();
                    }
                    ClientContext.ExecuteQuery();
                    break;
                }
            }
        }
    }
}
