# Get-PnPUserProfileProperty

## Syntax
```powershell
Get-PnPUserProfileProperty -Account <String[]>
```


## Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Account|String[]|True|The account of the user, formatted either as a login name, or as a claims identity, e.g. i:0#.f|membership|user@domain.com|
## Examples

### Example 1
```powershell
PS:> Get-PnPUserProfileProperty -Account 'user@domain.com'
```
Returns the profile properties for the specified user

### Example 2
```powershell
PS:> Get-PnPUserProfileProperty -Account 'user@domain.com','user2@domain.com'
```
Returns the profile properties for the specified users
