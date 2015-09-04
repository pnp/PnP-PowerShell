#Set-SPOSearchConfiguration
*Topic automatically generated on: 2015-08-31*

Returns the search configuration
##Syntax
```powershell
Set-SPOSearchConfiguration -Configuration <String> [-Scope <SearchConfigurationScope>] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Configuration|String|True||
|Scope|SearchConfigurationScope|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
    PS:> Set-SPOSearchConfiguration -Configuration $config
Sets the search configuration for the current web

###Example 2
    PS:> Set-SPOSearchConfiguration -Configuration $config -Scope Site
Sets the search configuration for the current site collection

###Example 3
    PS:> Set-SPOSearchConfiguration -Configuration $config -Scope Subscription
Sets the search configuration for the current tenant
<!-- Ref: 4DFAF0185ABB7F6BA79FF55644AAF448 -->