---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPWorkflowDefinition

## SYNOPSIS
Removes a workflow definition

## SYNTAX 

### 
```powershell
Remove-PnPWorkflowDefinition [-Identity <WorkflowDefinitionPipeBind>]
                             [-Web <WebPipeBind>]
                             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPWorkflowDefinition -Identity $wfDef
```

Removes the workflow, retrieved by Get-PnPWorkflowDefinition, from the site.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWorkflowDefinition -Name MyWorkflow | Remove-PnPWorkflowDefinition
```

Get the workflow MyWorkFlow and remove from the site.

## PARAMETERS

### -Identity


```yaml
Type: WorkflowDefinitionPipeBind
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