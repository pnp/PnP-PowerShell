#Add-SPODocumentSet
Creates a new document set in a library.
##Syntax
```powershell
Add-SPODocumentSet -List <ListPipeBind> -Name <String> -ContentType <ContentTypePipeBind> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ContentType|ContentTypePipeBind|True||
|List|ListPipeBind|True||
|Name|String|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPODocumentSet -List "Documents" -ContentType "Test Document Set" -Name "Test"
```
This will add a new document set based upon the 'Test Document Set' content type to a list called 'Documents'. The document set will be named 'Test'
