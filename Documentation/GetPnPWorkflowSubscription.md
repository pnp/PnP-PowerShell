# Get-PnPWorkflowSubscription

## SYNOPSIS
Returns a workflow subscriptions from a list

## SYNTAX 

```powershell
Get-PnPWorkflowSubscription [-Web <WebPipeBind>]
                            [-Name <String>]
                            [-List <ListPipeBind>]
```


## PARAMETERS

### -List
A list to search the association for

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: False
Position: 1
Accept pipeline input: False
```

### -Name
The name of the workflow

```yaml
Type: String
Parameter Sets: (All)

Required: False
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

## OUTPUTS

### [Microsoft.SharePoint.Client.WorkflowServices.WorkflowSubscription](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.workflowservices.workflowsubscription.aspx)

# RELATED LINKS

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)