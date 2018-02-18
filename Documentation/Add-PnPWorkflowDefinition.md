---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPWorkflowDefinition

## SYNOPSIS
Adds a workflow definition

## SYNTAX 

### 
```powershell
Add-PnPWorkflowDefinition [-Definition <WorkflowDefinition>]
                          [-DoNotPublish [<SwitchParameter>]]
                          [-Web <WebPipeBind>]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPWorkflowDefinition -Definition $wfdef
```

Adds an existing workflow definition, retrieved by Get-PnPWorkflowDefinition, to a site.

## PARAMETERS

### -Definition


```yaml
Type: WorkflowDefinition
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DoNotPublish


```yaml
Type: SwitchParameter
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

### System.Guid

Returns the Id of the workflow definition

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)