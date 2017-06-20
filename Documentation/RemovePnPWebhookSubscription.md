# Remove-PnPWebhookSubscription
Removes a Webhook subscription from the resource
## Syntax
```powershell
Remove-PnPWebhookSubscription -Identity <WebhookSubscriptionPipeBind>
                              [-List <ListPipeBind>]
                              [-Web <WebPipeBind>]
```


## Returns
>OfficeDevPnP.Core.Entities.WebhookSubscription

## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|WebhookSubscriptionPipeBind|True|The identity of the Webhook subscription to remove|
|List|ListPipeBind|False|The list object or name where the Webhook subscription will be added|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
## Examples

### Example 1
```powershell
PS:> Remove-PnPWebhookSubscription -List MyList -Identity ea1533a8-ff03-415b-a7b6-517ee50db8b6
```
Removes the Webhook subscription with the specified id from the list MyList

### Example 2
```powershell
PS:> $subscriptions = Get-PnPWebhookSubscriptions -List MyList
PS:> Remove-PnPWebhookSubscription -List MyList -Identity $subscriptions[0]
```
Removes the first Webhook subscription from the list MyList
