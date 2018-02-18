---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Resume-PnPWorkflowInstance

## SYNOPSIS
Resume a workflow

## SYNTAX 

### 
```powershell
Resume-PnPWorkflowInstance [-Identity <WorkflowInstancePipeBind>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Resumes a previously stopped workflow instance

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Resume-PnPWorkflowInstance -identity $wfInstance
```

Resumes the workflow instance, this can be the Guid of the instance or the instance itself.

## PARAMETERS

### -Identity


```yaml
Type: WorkflowInstancePipeBind
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