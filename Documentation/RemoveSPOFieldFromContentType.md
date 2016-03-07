#Remove-SPOFieldFromContentType
Removes a site column from a content type
##Syntax
```powershell
Remove-SPOFieldFromContentType -Field <FieldPipeBind> -ContentType <ContentTypePipeBind> [-DoNotUpdateChildren [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ContentType|ContentTypePipeBind|True||
|DoNotUpdateChildren|SwitchParameter|False||
|Field|FieldPipeBind|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOFieldFromContentType -Field "Project_Name" -ContentType "Project Document"
```
This will remove the site column with an internal name of "Project_Name" to a content type called "Project Document"
