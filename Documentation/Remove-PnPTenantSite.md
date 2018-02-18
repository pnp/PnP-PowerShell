---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Remove-PnPTenantSite

## SYNOPSIS
Removes a site collection

## SYNTAX 

### 
```powershell
Remove-PnPTenantSite [-Url <String>]
                     [-SkipRecycleBin [<SwitchParameter>]]
                     [-Force [<SwitchParameter>]]
                     [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes a site collection which is listed in your tenant administration site.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPTenantSite -Url https://tenant.sharepoint.com/sites/contoso
```

This will remove the site collection with the url 'https://tenant.sharepoint.com/sites/contoso'  and put it in the recycle bin.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPTenantSite -Url https://tenant.sharepoint.com/sites/contoso -Force -SkipRecycleBin
```

This will remove the site collection with the url 'https://tenant.sharepoint.com/sites/contoso' with force and it will skip the recycle bin.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPTenantSite -Url https://tenant.sharepoint.com/sites/contoso -FromRecycleBin
```

This will remove the site collection with the url 'https://tenant.sharepoint.com/sites/contoso' from the recycle bin.

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SkipRecycleBin


```yaml
Type: SwitchParameter
Parameter Sets: 
Aliases: new String[1] { "SkipTrash" }

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)