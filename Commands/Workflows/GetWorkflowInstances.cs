using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client.WorkflowServices;

namespace SharePointPnP.PowerShell.Commands.Workflows
{
    [Cmdlet(VerbsCommon.Get, "PnPWorkflowInstance")]
    [CmdletHelp("Get workflow instances",
        "Gets all workflow instances",
        Category = CmdletHelpCategory.Workflows)]
    [CmdletExample(
        Code = @"Get-PnPWorkflowInstance -Item $SPListItem",
        Remarks = "Retreives workflow instances running against the provided item",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"Get-PnPWorkflowInstance -Item $SPListItem",
        Remarks = "Retreives workflow instances running against the provided item",
        SortOrder = 2)]

    public class GetWorkflowInstance : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The SPList for which workflow instances should be retreived", Position = 0)]
        public List List;

        [Parameter(Mandatory = true, HelpMessage = "The SPListItem for which workflow instances should be retreived", Position = 1) ]
        public ListItem ListItem;

        protected override void ExecuteCmdlet()
        {
            if (ListItem != null)
            {
                var workflowServicesManager = new Microsoft.SharePoint.Client.WorkflowServices.WorkflowServicesManager(ClientContext, SelectedWeb);
                var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();
                var Workflows = workflowInstanceService.EnumerateInstancesForListItem(List.Id, ListItem.Id);
                ClientContext.Load(Workflows);
                ClientContext.ExecuteQueryRetry();
                foreach(WorkflowInstance wf in Workflows)
                {
                    WriteObject(new WorkflowInstancePipeBind(wf)); 
                }
            }
        }
    }


}
