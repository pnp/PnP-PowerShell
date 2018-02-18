---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPWebhookSubscription

## SYNOPSIS
Updates a Webhook subscription

## SYNTAX 

### 
```powershell
Set-PnPWebhookSubscription [-Subscription <WebhookSubscriptionPipeBind>]
                           [-List <ListPipeBind>]
                           [-NotificationUrl <String>]
                           [-ExpirationDate <DateTime>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPWebhookSubscription -List MyList -Subscription ea1533a8-ff03-415b-a7b6-517ee50db8b6 -NotificationUrl https://my-func.azurewebsites.net/webhook
```

Updates an existing Webhook subscription with the specified id on the list MyList with a new Notification Url

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPWebhookSubscription -List MyList -Subscription ea1533a8-ff03-415b-a7b6-517ee50db8b6 -NotificationUrl https://my-func.azurewebsites.net/webhook -ExpirationDate "2017-09-01"
```

Updates an existing Webhook subscription with the specified id on the list MyList with a new Notification Url and a new expiration date

### ------------------EXAMPLE 3------------------
```powershell
PS:> $subscriptions = Get-PnPWebhookSubscriptions -List MyList
PS:> $updated = $subscriptions[0]
PS:> $updated.ExpirationDate = "2017-10-01"
PS:> Set-PnPWebhookSubscription -List MyList -Subscription $updated
```

Updates the Webhook subscription from the list MyList with a modified subscription object.
Note: The date will be converted to Universal Time

## PARAMETERS

### -ExpirationDate


```yaml
Type: DateTime
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -NotificationUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Subscription


```yaml
Type: WebhookSubscriptionPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Web


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### OfficeDevPnP.Core.Entities.WebhookSubscription

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)