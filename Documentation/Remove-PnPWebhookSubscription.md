---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPWebhookSubscription

## SYNOPSIS
Removes a Webhook subscription from the resource

## SYNTAX 

### 
```powershell
Remove-PnPWebhookSubscription [-Identity <WebhookSubscriptionPipeBind>]
                              [-List <ListPipeBind>]
                              [-Force [<SwitchParameter>]]
                              [-Web <WebPipeBind>]
                              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPWebhookSubscription -List MyList -Identity ea1533a8-ff03-415b-a7b6-517ee50db8b6
```

Removes the Webhook subscription with the specified id from the list MyList

### ------------------EXAMPLE 2------------------
```powershell
PS:> $subscriptions = Get-PnPWebhookSubscriptions -List MyList
PS:> Remove-PnPWebhookSubscription -Identity $subscriptions[0] -List MyList
```

Removes the first Webhook subscription from the list MyList

### ------------------EXAMPLE 3------------------
```powershell
PS:> $subscriptions = Get-PnPWebhookSubscriptions -List MyList
PS:> $subscriptions[0] | Remove-PnPWebhookSubscription -List MyList
```

Removes the first Webhook subscription from the list MyList

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: WebhookSubscriptionPipeBind
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