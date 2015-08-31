#Get-SPOSearchConfiguration
*Topic automatically generated on: 2015-08-31*

Returns the search configuration
##Syntax
```powershell
Get-SPOSearchConfiguration [-Scope <SearchConfigurationScope>] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Scope|SearchConfigurationScope|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    PS:> Get-SPOSearchConfiguration
Returns the search configuration for the current web

###Example 2
    PS:> Get-SPOSearchConfiguration -Scope Site
Returns the search configuration for the current site collection

###Example 3
    PS:> Get-SPOSearchConfiguration -Scope Subscription
Returns the search configuration for the current tenant
<!-- Ref: 70F8EEE409C9A02BB2CBC837AEF3E6EA -->