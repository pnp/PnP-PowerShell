#if !ONPREMISES

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Management.Automation;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Webhooks
{
    [Cmdlet(VerbsCommon.Get, "PnPWebhookSubscriptions")]
    [CmdletHelp("Gets all the Webhook subscriptions of the resource",
        Category = CmdletHelpCategory.Webhooks,
        SupportedPlatform = CmdletSupportedPlatform.Online,
        OutputType = typeof(WebhookSubscription))]
    [CmdletExample(
        Code = "PS:> Get-PnPWebhookSubscriptions -List MyList",
        Remarks = "Gets all Webhook subscriptions of the list MyList",
        SortOrder = 1)]
    [CmdletExample(
        Code = "PS:> Get-PnPList | Get-PnPWebhookSubscriptions",
        Remarks = "Gets all Webhook subscriptions of the all the lists",
        SortOrder = 2)]
    public class GetWebhookSubscriptions : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The list object or name to get the Webhook subscriptions from")]
        public ListPipeBind List;

        protected override void ExecuteCmdlet()
        {
            // NOTE: Currently only supports List Webhooks
            if (ParameterSpecified(nameof(List)))
            {
                // Ensure we didn't get piped in a null, i.e. when running Get-PnPList -Identity "ThisListDoesNotExist" | Get-PnPWebhookSubscriptions
                if(List == null)
                {
                    throw new PSArgumentNullException(nameof(List));
                }

                // Get the list from the currently selected web
                List list = List.GetList(SelectedWeb);
                if (list != null)
                {
                    // Get all the webhook subscriptions for the specified list
                    WriteObject(list.GetWebhookSubscriptions());
                }
                else
                {
                    throw new PSArgumentOutOfRangeException(nameof(List), List.ToString(), string.Format(Resources.ListNotFound, List.ToString()));
                }
            }
            else
            {
                throw new PSNotImplementedException(Resources.WebhooksOnlySupportsLists);
            }
        }
    }
}

#endif