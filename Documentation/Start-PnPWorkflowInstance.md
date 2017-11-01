---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Start-PnPWorkflowInstance

## SYNOPSIS
Starts a workflow instance on a list item

## SYNTAX 

```powershell
Start-PnPWorkflowInstance -Subscription <WorkflowSubscriptionPipeBind>
                          -ListItemID <Int>
                          [-Web <WebPipeBind>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Start-PnPWorkflowInstance -Name 'WorkflowName' 
```

Stops the workflow Instance, this can be the Guid of the instance or the instance itself.

## PARAMETERS

### -ListItemID
The list item to start the workflow against

```yaml
Type: Int
Parameter Sets: (All)

Required: True
Position: 1
Accept pipeline input: False
```

### -Subscription
The workflow subscription to start

```yaml
Type: WorkflowSubscriptionPipeBind
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: False
```

### -Web
The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)