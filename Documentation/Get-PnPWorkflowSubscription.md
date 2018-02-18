---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPWorkflowSubscription

## SYNOPSIS
Return a workflow subscription

## SYNTAX 

### 
```powershell
Get-PnPWorkflowSubscription [-Name <String>]
                            [-List <ListPipeBind>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns a workflow subscriptions from a list

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWorkflowSubscription -Name MyWorkflow
```

Gets an Workflow subscription with the name "MyWorkflow".

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWorkflowSubscription -Name MyWorkflow -list $list
```

Gets an Workflow subscription with the name "MyWorkflow" from the list $list.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPList -identity "MyList" | Get-PnPWorkflowSubscription -Name MyWorkflow
```

Gets an Workflow subscription with the name "MyWorkflow" from the list "MyList".

## PARAMETERS

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


```yaml
Type: String
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

### [Microsoft.SharePoint.Client.WorkflowServices.WorkflowSubscription](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.workflowservices.workflowsubscription.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)