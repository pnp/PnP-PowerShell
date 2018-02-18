---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPWorkflowDefinition

## SYNOPSIS
Return a workflow definition

## SYNTAX 

### 
```powershell
Get-PnPWorkflowDefinition [-Name <String>]
                          [-PublishedOnly [<SwitchParameter>]]
                          [-Web <WebPipeBind>]
                          [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns a workflow definition

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWorkflowDefinition -Name MyWorkflow
```

Gets an Workflow with the name "MyWorkflow".

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWorkflowDefinition -Name MyWorkflow -PublishedOnly $false
```

Gets an Workflow with the name "MyWorkflow" that is published.

## PARAMETERS

### -Name


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PublishedOnly


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

### [Microsoft.SharePoint.Client.WorkflowServices.WorkflowDefinition](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.workflowservices.workflowdefinition.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)