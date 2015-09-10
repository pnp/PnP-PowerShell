#Get-SPOList
*Topic automatically generated on: 2015-09-10*

Returns a List object
##Syntax
```powershell
Get-SPOList [-Web <WebPipeBind>] [-Identity <ListPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|ListPipeBind|False|The ID or Url of the list.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    PS:> Get-SPOList
Returns all lists in the current web

###Example 2
    PS:> Get-SPOList -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
Returns a list with the given id.

###Example 3
    PS:> Get-SPOList -Identity /Lists/Announcements
Returns a list with the given url.
<!-- Ref: A78A6AA20C4E2D00C8BE62A524816B03 -->