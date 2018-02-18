---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPWorkflowSubscription

## SYNOPSIS
Remove workflow subscription

## SYNTAX 

### 
```powershell
Remove-PnPWorkflowSubscription [-Identity <WorkflowSubscriptionPipeBind>]
                               [-Web <WebPipeBind>]
                               [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes a previously registered workflow subscription

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPWorkflowSubscription -identity $wfSub
```

Removes the workflowsubscription, retrieved by Get-PnPWorkflowSubscription.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWorkflowSubscription -Name MyWorkflow | Remove-PnPWorkflowSubscription
```

Get the workflowSubscription MyWorkFlow and remove it.

## PARAMETERS

### -Identity


```yaml
Type: WorkflowSubscriptionPipeBind
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)