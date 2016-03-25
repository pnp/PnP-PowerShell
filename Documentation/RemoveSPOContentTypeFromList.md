#Remove-SPOContentTypeFromList
Removes a content type from a list
##Syntax
```powershell
Remove-SPOContentTypeFromList -List <ListPipeBind> -ContentType <ContentTypePipeBind> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ContentType|ContentTypePipeBind|True||
|List|ListPipeBind|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Remove-SPOContentTypeFromList -List "Documents" -ContentType "Project Document"
```
This will remove a content type called "Project Document" from the "Documents" list
