# Stop-PnPWorkflowInstance
Stops a workflow instance
## Syntax
```powershell
Stop-PnPWorkflowInstance -Identity <WorkflowInstancePipeBind>
                         [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|WorkflowInstancePipeBind|True|The instance to stop|
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
