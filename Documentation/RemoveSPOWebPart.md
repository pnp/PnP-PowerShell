#Remove-SPOWebPart
*Topic automatically generated on: 2015-09-21*

Removes a webpart from a page
##Syntax
```powershell
Remove-SPOWebPart -Identity <GuidPipeBind> -ServerRelativePageUrl <String> [-Web <WebPipeBind>]
```


```powershell
Remove-SPOWebPart -Name <String> -ServerRelativePageUrl <String> [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Identity|GuidPipeBind|True||
|Name|String|True||
|ServerRelativePageUrl|String|True||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
<!-- Ref: BB23C4F1B5D04A3FD182E08560F933A5 -->