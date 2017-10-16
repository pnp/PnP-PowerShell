# Remove-PnPWorkflowSubscription
Removes a workflow subscription
## Syntax
```powershell
Remove-PnPWorkflowSubscription -Identity <WorkflowSubscriptionPipeBind>
                               [-Web <WebPipeBind>]
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|WorkflowSubscriptionPipeBind|True|The subscription to remove|
|Web|WebPipeBind|False|The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.|
