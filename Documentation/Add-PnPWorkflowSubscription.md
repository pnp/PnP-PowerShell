---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPWorkflowSubscription

## SYNOPSIS
Adds a workflow subscription to a list

## SYNTAX 

### 
```powershell
Add-PnPWorkflowSubscription [-Name <String>]
                            [-DefinitionName <String>]
                            [-List <ListPipeBind>]
                            [-StartManually [<SwitchParameter>]]
                            [-StartOnCreated [<SwitchParameter>]]
                            [-StartOnChanged [<SwitchParameter>]]
                            [-HistoryListName <String>]
                            [-TaskListName <String>]
                            [-AssociationValues <Dictionary`2>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPWorkflowSubscription -Name MyWorkflow -DefinitionName SendMessageWf -list $list
```

Adds an Workflow with the name 'SendMessageWf' to the list $list.

### ------------------EXAMPLE 2------------------
```powershell
PS:> $list | Add-PnPWorkflowSubscription -Name MyWorkflow -DefinitionName SendMessageWf
```

Adds an Workflow with the name "SendMessageWf" to the list $list.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPList -Identity "MyCustomList" | Add-PnPWorkflowSubscription -Name MyWorkflow -DefinitionName SendMessageWf
```

Adds an Workflow with the name "SendMessageWf" to the list "MyCustomList".

## PARAMETERS

### -AssociationValues


```yaml
Type: Dictionary`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DefinitionName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -HistoryListName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

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

### -StartManually


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StartOnChanged


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StartOnCreated


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TaskListName


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)