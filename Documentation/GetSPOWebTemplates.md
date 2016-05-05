#Get-SPOWebTemplates
Office365 only: Returns the available web templates.
##Syntax
```powershell
Get-SPOWebTemplates [-Lcid <UInt32>] [-CompatibilityLevel <Int32>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|CompatibilityLevel|Int32|False|The version of SharePoint|
|Lcid|UInt32|False|The language id like 1033 for English|
##Examples

###Example 1
```powershell
PS:> Get-SPOWebTemplates
```


###Example 2
```powershell
PS:> Get-SPOWebTemplates -LCID 1033
```
Returns all webtemplates for the Locale with ID 1033 (English)

###Example 3
```powershell
PS:> Get-SPOWebTemplates -CompatibilityLevel 15
```
Returns all webtemplates for the compatibility level 15
