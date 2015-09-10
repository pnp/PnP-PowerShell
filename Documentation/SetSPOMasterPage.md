#Set-SPOMasterPage
*Topic automatically generated on: 2015-09-10*

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
    
    PS:> Set-SPOMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master


<!-- Ref: 1274EB88287F617673769489F2359220 -->