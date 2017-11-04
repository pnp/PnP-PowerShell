---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPSiteClassifications

## SYNOPSIS
Returns the defined Site Classifications for the tenant. Requires a connection to the Microsoft Graph.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Get-PnPSiteClassifications
```

Returns the currently set site classifications for the tenant.

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)