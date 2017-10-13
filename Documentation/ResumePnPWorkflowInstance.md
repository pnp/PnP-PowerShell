# Resume-PnPWorkflowInstance

## SYNOPSIS
Resumes a previously stopped workflow instance

## SYNTAX 

```powershell
Resume-PnPWorkflowInstance -Identity <WorkflowInstancePipeBind>
                           [-Web <WebPipeBind>]
```


## PARAMETERS

### -Identity
The instance to resume

```yaml
Type: WorkflowInstancePipeBind
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

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)