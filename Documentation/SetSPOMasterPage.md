#Set-SPOMasterPage
*Topic automatically generated on: 2015-09-17*

Sets the default master page of the current web.
##Syntax
```powershell
Set-SPOMasterPage [-MasterPageServerRelativeUrl <String>] [-CustomMasterPageServerRelativeUrl <String>] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|CustomMasterPageServerRelativeUrl|String|False||
|MasterPageServerRelativeUrl|String|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell

    PS:> Set-SPOMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master

```

<!-- Ref: 32528467FDAD4E8CEEC9C7299736653A -->