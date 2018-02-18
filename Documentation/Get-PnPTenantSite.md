---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPTenantSite

## SYNOPSIS
Retrieve site information.

## SYNTAX 

### 
```powershell
Get-PnPTenantSite [-Url <String>]
                  [-Template <String>]
                  [-Detailed [<SwitchParameter>]]
                  [-IncludeOneDriveSites [<SwitchParameter>]]
                  [-Force [<SwitchParameter>]]
                  [-WebTemplate <String>]
                  [-Filter <String>]
                  [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Use this cmdlet to retrieve site information from your tenant administration.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPTenantSite
```

Returns all site collections

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPTenantSite -Url http://tenant.sharepoint.com/sites/projects
```

Returns information about the project site

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPTenantSite -Detailed
```

Returns all sites with the full details of these sites

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPTenantSite -IncludeOneDriveSites
```

Returns all sites including all OneDrive for Business sites

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPTenantSite -IncludeOneDriveSites -Filter "Url -like '-my.sharepoint.com/personal/'"
```

Returns all OneDrive for Business sites

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPTenantSite -WebTemplate SITEPAGEPUBLISHING#0
```

Returns all Communication sites

### ------------------EXAMPLE 7------------------
```powershell
PS:> Get-PnPTenantSite -Filter "Url -like 'sales'" 
```

Returns all sites including 'sales' in the url

## PARAMETERS

### -Detailed


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Filter


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeOneDriveSites


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Template


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "Identity" }

Required: False
Position: 0
Accept pipeline input: False
```

### -WebTemplate


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [Microsoft.Online.SharePoint.TenantAdministration.SiteProperties](https://msdn.microsoft.com/en-us/library/microsoft.online.sharepoint.tenantadministration.siteproperties.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)