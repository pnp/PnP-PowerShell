#Send-SPOMail
Sends an email using the Office 365 SMTP Service
##Syntax
```powershell
Send-SPOMail [-Server <String>] [-From <String>] [-Password <String>] -To <String[]> [-Cc <String[]>] -Subject <String> -Body <String> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Body|String|True||
|Cc|String[]|False||
|From|String|False|If using from address, you also have to provide a password|
|Password|String|False|If using a password, you also have to provide the associated from address|
|Server|String|False||
|Subject|String|True||
|To|String[]|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Send-SPOMail -To address@tenant.sharepointonline.com -Subject test -Body test
```
Sends an e-mail using the SharePoint SendEmail method using the current context. E-mail is sent from the system account and can only be sent to accounts in the same tenant

###Example 2
```powershell
PS:> Send-SPOMail -To address@contoso.com -Subject test -Body test -From me@tenant.onmicrosoft.com -Password xyz
```
Sends an e-mail via Office 365 SMTP and requires from address and password. E-mail is sent from the from user and can be sent to both internal and external addresses.
