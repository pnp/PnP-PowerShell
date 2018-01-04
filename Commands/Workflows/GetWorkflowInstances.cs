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
        Remarks = "Retrieves workflow instances running against the provided item",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"Get-PnPWorkflowInstance -Item $SPListItem",
        Remarks = "Retrieves workflow instances running against the provided item",
        SortOrder = 2)]

    public class GetWorkflowInstance : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The List for which workflow instances should be retrieved", Position = 0)]
        public ListPipeBind ListIdentity;

        [Parameter(Mandatory = true, HelpMessage = "The List Item for which workflow instances should be retrieved", Position = 1) ]
        public ListItemPipeBind ListItemIdentity;

        protected override void ExecuteCmdlet()
        {
            List list = null;
            ListItem listitem = null;

            if (ListIdentity != null)
            {
                list = ListIdentity.GetList(SelectedWeb);
                if (list == null)
                {
                    throw new PSArgumentException($"No list found with id, title or url '{ListIdentity}'", "Identity");
                }
            }
            else
            {
                throw new PSArgumentException("ListIdentity required");
            }

            if (ListItemIdentity != null)
            {
                listitem = ListItemIdentity.GetListItem(list);
                if (listitem == null)
                {
                    throw new PSArgumentException($"No list item found with id, or title '{ListItemIdentity}'", "Identity");
                }
            }
            else
            {
                throw new PSArgumentException("ListItemIdentity required");
            }

            var workflowServicesManager = new Microsoft.SharePoint.Client.WorkflowServices.WorkflowServicesManager(ClientContext, SelectedWeb);
            var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();
            var Workflows = workflowInstanceService.EnumerateInstancesForListItem(list.Id, listitem.Id);
            ClientContext.Load(Workflows);
            ClientContext.ExecuteQueryRetry();
            foreach(WorkflowInstance wf in Workflows)
            {
                WriteObject(new WorkflowInstancePipeBind(wf)); 
            }
            
        }
    }


}
