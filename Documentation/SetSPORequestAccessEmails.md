#Set-SPORequestAccessEmails
Sets Request Access Emails on a web
##Syntax
```powershell
Set-SPORequestAccessEmails -Emails <List`1> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Emails|List`1|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Set-SPORequestAccessEmails -Emails someone@example.com )
```
This will update the request access e-mail address

###Example 2
```powershell
PS:> Set-SPORequestAccessEmails -Emails @( someone@example.com; someoneelse@example.com )
```
This will update multiple request access e-mail addresses
