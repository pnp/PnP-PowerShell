using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client.Workflow;
using Microsoft.SharePoint.Client.WorkflowServices;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands.Workflows
{
    [Cmdlet(VerbsLifecycle.Start, "PnPWorkflowInstance")]
    [CmdletHelp("Starts a workflow instance on a list item",
        Category = CmdletHelpCategory.Workflows)]
    [CmdletExample(
        Code = @"Start-PnPWorkflowInstance -Name 'WorkflowName' ", 
        Remarks = "Stops the workflow Instance, this can be the Guid of the instance or the instance itself.",
        SortOrder = 1)]
    public class StartWorkflowInstance : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The workflow subscription to start", Position = 0)]
        public WorkflowSubscriptionPipeBind Subscription;

        [Parameter(Mandatory = true, HelpMessage = "The list item to start the workflow against", Position = 1)]
        public int ListItemID;

    

        protected override void ExecuteCmdlet()
        {

            WorkflowServicesManager workflowServicesManager = new WorkflowServicesManager(ClientContext, SelectedWeb);
            WorkflowInstanceService instanceService = workflowServicesManager.GetWorkflowInstanceService();

            if (Subscription.Subscription != null)
            {
                var inputParameters = new Dictionary<string, object>();
                instanceService.StartWorkflowOnListItem(Subscription.Subscription, ListItemID, inputParameters);
                ClientContext.ExecuteQuery();
            }
        }
    }
}
