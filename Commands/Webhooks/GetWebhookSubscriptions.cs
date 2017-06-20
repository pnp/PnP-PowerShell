#if !ONPREMISES

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Webhooks
{
    [Cmdlet(VerbsCommon.Get, "PnPWebhookSubscriptions")]
    [CmdletHelp("Gets all the Webhook subscriptions of the resource",
        Category = CmdletHelpCategory.Webhooks,
        OutputType = typeof(WebhookSubscription))]
    [CmdletExample(
        Code = "PS:> Get-PnPWebhookSubscriptions -List MyList",
        Remarks = "Gets all Webhook subscriptions of the list MyList",
        SortOrder = 1)]
    public class GetWebhookSubscriptions : PnPWebCmdlet
    {
        public const int DefaultValidityInMonths = 6;

        [Parameter(Mandatory = false, HelpMessage = "The list object or name where the Webhook subscription will be added")]
        public ListPipeBind List;

        protected override void ExecuteCmdlet()
        {
            // NOTE: Currently only supports List Webhooks
            if (MyInvocation.BoundParameters.ContainsKey("List"))
            {
                // Get the list from the currently selected web
                List list = List.GetList(SelectedWeb);
                // Ensure we have list Id (TODO Should be changed in the Core extension method)
                list.EnsureProperty(l => l.Id);

                // Get all the webhook subscriptions for the specified list
                WriteObject(list.GetWebhookSubscriptions());
            }
            else
            {
                throw new PSNotImplementedException("This Cmdlet only supports List Webhooks currently");
            }
        }

    }
}

#endif