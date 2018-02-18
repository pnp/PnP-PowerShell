---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Start-PnPWorkflowInstance

## SYNOPSIS
Starts a workflow instance on a list item

## SYNTAX 

### 
```powershell
Start-PnPWorkflowInstance [-Subscription <WorkflowSubscriptionPipeBind>]
                          [-ListItem <ListItemPipeBind>]
                          [-Web <WebPipeBind>]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Start-PnPWorkflowInstance -Name 'WorkflowName' -ListItem $item 
```

Starts a workflow instance on the specified list item

### ------------------EXAMPLE 2------------------
```powershell
PS:> Start-PnPWorkflowInstance -Name 'WorkflowName' -ListItem 2 
```

Starts a workflow instance on the specified list item

## PARAMETERS

### -ListItem


```yaml
Type: ListItemPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Subscription


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