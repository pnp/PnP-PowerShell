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
                          -ListItem <ListItemPipeBind>
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
The list item to start the workflow against

```yaml
Type: ListItemPipeBind
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

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Web
This parameter allows you to optionally apply the cmdlet action to a subweb within the current web. In most situations this parameter is not required and you can connect to the subweb using Connect-PnPOnline instead. Specify the GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)