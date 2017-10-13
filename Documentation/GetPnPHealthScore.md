# Get-PnPHealthScore

## SYNOPSIS
Retrieves the current health score value of the server

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPHealthScore
```

This will retrieve the current health score of the server.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPHealthScore -Url https://contoso.sharepoint.com
```

This will retrieve the current health score for the url https://contoso.sharepoint.com.

## OUTPUTS

### System.Int32

Returns a int value representing the current health score value of the server.

# RELATED LINKS

[SharePoint Developer Patterns and Practices:](http://aka.ms/sppnp)