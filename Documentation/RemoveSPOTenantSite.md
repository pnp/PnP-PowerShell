#Remove-SPOTenantSite
Office365 only: Removes a site collection from the current tenant
##Syntax
```powershell
Remove-SPOTenantSite [-SkipRecycleBin [<SwitchParameter>]] [-FromRecycleBin [<SwitchParameter>]] [-Force [<SwitchParameter>]] -Url <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Force|SwitchParameter|False|Do not ask for confirmation.|
|FromRecycleBin|SwitchParameter|False|If specified, will search for the site in the Recycle Bin and remove it from there.|
|SkipRecycleBin|SwitchParameter|False|Do not add to the trashcan if selected.|
|Url|String|True||
##Examples

###Example 1
```powershell
PS:> Remove-SPOTenantSite -Url https://tenant.sharepoint.com/sites/contoso -Force -SkipRecycleBin
```
This will remove the site collection with the url 'https://tenant.sharepoint.com/sites/contoso' with force and it will skip the recycle bin.
