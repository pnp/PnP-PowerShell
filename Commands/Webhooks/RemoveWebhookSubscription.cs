#if !ONPREMISES

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Webhooks
{
    [Cmdlet(VerbsCommon.Remove, "PnPWebhookSubscription")]
    [CmdletHelp("Removes a Webhook subscription from the resource",
        Category = CmdletHelpCategory.Webhooks,
        OutputType = typeof(WebhookSubscription))]
    [CmdletExample(
        Code = "PS:> Remove-PnPWebhookSubscription -List MyList -Identity ea1533a8-ff03-415b-a7b6-517ee50db8b6",
        Remarks = "Removes the Webhook subscription with the specified id from the list MyList",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> $subscriptions = Get-PnPWebhookSubscriptions -List MyList
PS:> Remove-PnPWebhookSubscription -List MyList -Identity $subscriptions[0]",
        Remarks = "Removes the first Webhook subscription from the list MyList",
        SortOrder = 2)]
    public class RemoveWebhookSubscription : PnPWebCmdlet
    {
        public const int DefaultValidityInMonths = 6;

        [Parameter(Mandatory = false, HelpMessage = "The list object or name where the Webhook subscription will be added")]
        public ListPipeBind List;

        [Parameter(Mandatory = true, HelpMessage = "The identity of the Webhook subscription to remove")]
        public WebhookSubscriptionPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            // NOTE: Currently only supports List Webhooks
            if (MyInvocation.BoundParameters.ContainsKey("List"))
            {
                // Get the list from the currently selected web
                List list = List.GetList(SelectedWeb);
                // Ensure we have list Id (TODO Should be changed in the Core extension method)
                list.EnsureProperty(l => l.Id);

                // Remove the Webhook subscription for the specified Id
                list.RemoveWebhookSubscription(Identity.Subscription);
            }
            else
            {
                throw new PSNotImplementedException("This Cmdlet only supports List Webhooks currently");
            }
        }

    }
}

#endif