#Get-SPOProperty
*Topic automatically generated on: 2015-09-17*

Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty [-Web <WebPipeBind>] -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    
PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
Will load both the Id and Lists properties of the specified Web object.

###Example 2
    
PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
Will load the views object of the specified list object and return its value to the output.
<!-- Ref: E2AD6357CDA29241CDB99BC0F0EE5478 -->