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
        Code = @"PS:> Get-PnPWorkflowInstance -List ""My Library"" -ListItem $ListItem",
        Remarks = @"Retrieves workflow instances running against the provided item on list ""My Library""",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPWorkflowInstance -List ""My Library"" -ListItem 2",
        Remarks = @"Retrieves workflow instances running against the provided item with 2 in the list ""My Library""",
        SortOrder = 2)]

    public class GetWorkflowInstance : PnPWebCmdlet
    {
        private const string ParameterSet_BYLISTITEM = "By List and ListItem";
        private const string ParameterSet_BYSUBSCRIPTION = "By WorkflowSubscription";

        protected override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet_BYLISTITEM:
                    ExecuteCmdletByListItem();
                    break;
                case ParameterSet_BYSUBSCRIPTION:
                    ExecuteCmdletBySubscription();
                    break;
                default:
                    throw new NotImplementedException($"{nameof(ParameterSetName)}: {ParameterSetName}");
            }
        }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_BYLISTITEM, HelpMessage = "The List for which workflow instances should be retrieved", Position = 0)]
        public ListPipeBind List;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_BYLISTITEM, HelpMessage = "The List Item for which workflow instances should be retrieved", Position = 1)]
        public ListItemPipeBind ListItem;

        private void ExecuteCmdletByListItem()
        {
            List list = null;
            ListItem listitem = null;

            if (List != null)
            {
                list = List.GetList(SelectedWeb);
                if (list == null)
                {
                    throw new PSArgumentException($"No list found with id, title or url '{List}'", "Identity");
                }
            }
            else
            {
                throw new PSArgumentException("List required");
            }

            if (ListItem != null)
            {
                listitem = ListItem.GetListItem(list);
                if (listitem == null)
                {
                    throw new PSArgumentException($"No list item found with id, or title '{ListItem}'", "Identity");
                }
            }
            else
            {
                throw new PSArgumentException("List Item required");
            }

            var workflowServicesManager = new Microsoft.SharePoint.Client.WorkflowServices.WorkflowServicesManager(ClientContext, SelectedWeb);
            var workflowInstanceService = workflowServicesManager.GetWorkflowInstanceService();
            var workflows = workflowInstanceService.EnumerateInstancesForListItem(list.Id, listitem.Id);
            ClientContext.Load(workflows);
            ClientContext.ExecuteQueryRetry();
            WriteObject(workflows, true);
        }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_BYSUBSCRIPTION, HelpMessage = "The workflow subscription for which workflow instances should be retrieved", Position = 0, ValueFromPipeline = true)]
        public WorkflowSubscriptionPipeBind WorkflowSubscription;

        private void ExecuteCmdletBySubscription()
        {
            var workflowSubscription = WorkflowSubscription.Subscription;
            if (workflowSubscription == null)
            {
                throw new PSArgumentException($"No workflow subscription found for '{WorkflowSubscription}'", nameof(WorkflowSubscription));
            }

            var workflows = workflowSubscription.GetInstances();
            WriteObject(workflows, true);
        }
    }
}
