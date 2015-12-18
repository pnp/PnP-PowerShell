#Get-SPOJavaScriptLink
Returns all or a specific custom action(s) with location type ScriptLink
##Syntax
```powershell
Get-SPOJavaScriptLink [-Scope <CustomActionScope>] [-Web <WebPipeBind>] [-Name <String>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Name|String|False|Name of the Javascript link. Omit this parameter to retrieve all script links|
|Scope|CustomActionScope|False|Scope of the action, either Web, Site or All to return both|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Get-SPOJavaScriptLink
```
Returns all web and site scoped JavaScriptLinks

###Example 2
```powershell
PS:> Get-SPOJavaScriptLink -Scope Web
```
Returns all site scoped JavaScriptLinks

###Example 3
```powershell
PS:> Get-SPOJavaScriptLink -Scope Site
```
Returns all web scoped JavaScriptLinks

###Example 4
```powershell
PS:> Get-SPOJavaScriptLink -Name Test
```
Returns the JavaScriptLink named Test
