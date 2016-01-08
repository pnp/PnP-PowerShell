#Get-SPOCustomAction
Returns all or a specific custom action(s)
##Syntax
```powershell
Get-SPOCustomAction [-Identity <GuidPipeBind>] [-Scope <CustomActionScope>] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GuidPipeBind|False|Identity of the CustomAction to return. Omit to return all CustomActions.|
|Scope|CustomActionScope|False|Scope of the CustomAction, either Web, Site or All to return both|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
