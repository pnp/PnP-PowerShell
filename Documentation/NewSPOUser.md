#New-SPOUser
Adds a user to the built-in Site User Info List and returns a user object
##Syntax
```powershell
New-SPOUser -LoginName <String>
            [-Web <WebPipeBind>]
```


##Returns
```[Microsoft.SharePoint.Client.User](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.user.aspx)```

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|LoginName|String|True|The users login name (user@company.com)|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> New-SPOUser -LoginName user@company.com
```

