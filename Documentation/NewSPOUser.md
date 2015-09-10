#New-SPOUser
*Topic automatically generated on: 2015-09-11*

Adds a user to the build-in Site User Info List and returns a user object
##Syntax
```powershell
New-SPOUser -LoginName <String> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|LoginName|String|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    PS:> New-SPOUser -LoginName user@company.com

<!-- Ref: BCEFCCDCBBF1AD3ABCDB2CEBE9B6BFB9 -->