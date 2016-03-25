#Remove-SPOCustomAction
Removes a custom action
##Syntax
```powershell
Remove-SPOCustomAction [-Scope <CustomActionScope>] [-Force [<SwitchParameter>]] [-Web <WebPipeBind>] -Identity <GuidPipeBind>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|Use the -Force flag to bypass the confirmation question|
|Identity|GuidPipeBind|True|The identifier of the CustomAction that needs to be removed|
|Scope|CustomActionScope|False|Define if the CustomAction is to be found at the web or site collection scope. Specify All to allow deletion from either web or site collection.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
