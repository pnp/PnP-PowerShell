#Get-SPORequestAccessEmails
Returns the request access e-mail addresses
##Syntax
```powershell
Get-SPORequestAccessEmails [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Get-SPORequestAccessEmails
```
This will return all the request access e-mail addresses for the current web
