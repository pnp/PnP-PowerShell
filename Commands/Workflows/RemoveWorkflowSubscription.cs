using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Workflows
{
    [Cmdlet(VerbsCommon.Remove, "PnPWorkflowSubscription")]
    [CmdletHelp("Remove workflow subscription",
        "Removes a previously registered workflow subscription",
        Category = CmdletHelpCategory.Workflows)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPWorkflowSubscription -identity $wfSub", 
        Remarks = "Removes the workflowsubscription, retrieved by Get-PnPWorkflowSubscription.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPWorkflowSubscription -Name MyWorkflow | Remove-PnPWorkflowSubscription", 
        Remarks = "Get the workflowSubscription MyWorkFlow and remove it.",
        SortOrder = 2)]
    public class RemoveWorkflowSubscription : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The subscription to remove", Position = 0)]
        public WorkflowSubscriptionPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var identity = Identity.GetWorkflowSubscription(SelectedWeb)
                ?? throw new PSArgumentException($"No workflow subscription found for '{Identity}'", nameof(Identity));
            identity.Delete();
        }
    }

}
