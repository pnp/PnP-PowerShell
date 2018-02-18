---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPWebhookSubscriptions

## SYNOPSIS
Gets all the Webhook subscriptions of the resource

## SYNTAX 

### 
```powershell
Get-PnPWebhookSubscriptions [-List <ListPipeBind>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWebhookSubscriptions -List MyList
```

Gets all Webhook subscriptions of the list MyList

## PARAMETERS

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