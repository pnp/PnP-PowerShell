#Get-SPOWebPartXml
*Topic automatically generated on: 2015-08-10*

Returns the webpart XML of a webpart registered on a site
##Syntax
```powershell
Get-SPOWebPartXml -ServerRelativePageUrl <String> [-Identity <GuidPipeBind>] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GuidPipeBind|False|Id of the webpart. Use Get-SPOWebPart to retrieve all webpart Ids|
|ServerRelativePageUrl|String|True|Full server relative url of the webpart page, e.g. /sites/mysite/sitepages/home.aspx|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    PS:> Get-SPOWebPartXml -PageUrl "/sites/demo/sitepages/home.aspx" -Identity a2875399-d6ff-43a0-96da-be6ae5875f82
Returns the webpart XML for a given webpart on a page.
<!-- Ref: D9FF86CEB8E35A66E42337F2552BED44 -->