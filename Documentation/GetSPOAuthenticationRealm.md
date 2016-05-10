#Get-SPOAuthenticationRealm
Gets the authentication realm for the current web
##Syntax
```powershell
Get-SPOAuthenticationRealm [-Url <String>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Url|String|False|Specifies the URL of the site|
##Examples

###Example 1
```powershell
PS:> Get-SPOAuthenticationRealm
```
This will get the authentication realm for the current connected site

###Example 2
```powershell
PS:> Get-SPOAuthenticationRealm -Url https://contoso.sharepoint.com
```
This will get the authentication realm for https://contoso.sharepoint.com
