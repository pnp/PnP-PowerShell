---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Restore-PnPTenantRecycleBinItem

## SYNOPSIS
Restores a site collection from the tenant scoped recycle bin

## SYNTAX 

### 
```powershell
Restore-PnPTenantRecycleBinItem [-Url <String>]
                                [-Wait [<SwitchParameter>]]
                                [-Force [<SwitchParameter>]]
                                [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
The Reset-PnPTenantRecycleBinItem cmdlet allows a site collection that has been deleted and still exists in the tenant recycle bin to be restored to its original location.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Reset-PnPTenantRecycleBinItem -Url https://tenant.sharepoint.com/sites/contoso
```

This will restore the deleted site collection with the url 'https://tenant.sharepoint.com/sites/contoso' to its original location

### ------------------EXAMPLE 2------------------
```powershell
PS:> Reset-PnPTenantRecycleBinItem -Url https://tenant.sharepoint.com/sites/contoso -Wait
```

This will restore the deleted site collection with the url 'https://tenant.sharepoint.com/sites/contoso' to its original location and will wait with executing further PowerShell commands until the site collection restore has completed

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

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

### -Wait


```yaml
Type: SwitchParameter
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