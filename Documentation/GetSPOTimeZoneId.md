#Get-SPOTimeZoneId
Returns a time zone ID
##Syntax
```powershell
Get-SPOTimeZoneId [-Match <String>]
```


##Returns
>System.Collections.Generic.IEnumerable`1[SharePointPnP.PowerShell.Commands.GetTimeZoneId+Zone]

Returns a list of matching zones. Use the ID property of the object for use in New-SPOTenantSite

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Match|String|False|A string to search for like 'Stockholm'|
##Examples

###Example 1
```powershell
PS:> Get-SPOTimeZoneId
```
This will return all time zone IDs in use by Office 365.

###Example 2
```powershell
PS:> Get-SPOTimeZoneId -Match Stockholm
```
This will return the time zone IDs for Stockholm
