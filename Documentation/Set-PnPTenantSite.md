---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPTenantSite

## SYNOPSIS
Set site information.

## SYNTAX 

### 
```powershell
Set-PnPTenantSite [-Url <String>]
                  [-Title <String>]
                  [-Sharing <Nullable`1>]
                  [-StorageMaximumLevel <Nullable`1>]
                  [-StorageWarningLevel <Nullable`1>]
                  [-UserCodeMaximumLevel <Nullable`1>]
                  [-UserCodeWarningLevel <Nullable`1>]
                  [-AllowSelfServiceUpgrade <Nullable`1>]
                  [-Owners <List`1>]
                  [-LockState <SiteLockState>]
                  [-NoScriptSite [<SwitchParameter>]]
                  [-Wait [<SwitchParameter>]]
                  [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets site properties for existing sites.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com -Title "Contoso Website" -Sharing Disabled
```

This will set the title of the site collection with the URL 'https://contoso.sharepoint.com' to 'Contoso Website' and disable sharing on this site collection.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com -Title "Contoso Website" -StorageWarningLevel 8000 -StorageMaximumLevel 10000
```

This will set the title of the site collection with the URL 'https://contoso.sharepoint.com' to 'Contoso Website', set the storage warning level to 8GB and set the storage maximum level to 10GB.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com/sites/sales -Owners "user@contoso.onmicrosoft.com"
```

This will add user@contoso.onmicrosoft.com as an additional site collection owner at 'https://contoso.sharepoint.com/sites/sales'.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com/sites/sales -Owners @("user1@contoso.onmicrosoft.com", "user2@contoso.onmicrosoft.com")
```

This will add user1@contoso.onmicrosoft.com and user2@contoso.onmicrosoft.com as additional site collection owners at 'https://contoso.sharepoint.com/sites/sales'.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Set-PnPTenantSite -Url https://contoso.sharepoint.com/sites/sales -NoScriptSite:$false
```

This will enable script support for the site 'https://contoso.sharepoint.com/sites/sales' if disabled.

## PARAMETERS

### -AllowSelfServiceUpgrade


```yaml
Type: Nullable`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -LockState


```yaml
Type: SiteLockState
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -NoScriptSite


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owners


```yaml
Type: List`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Sharing


```yaml
Type: Nullable`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StorageMaximumLevel


```yaml
Type: Nullable`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StorageWarningLevel


```yaml
Type: Nullable`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


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

Required: False
Position: 0
Accept pipeline input: False
```

### -UserCodeMaximumLevel


```yaml
Type: Nullable`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UserCodeWarningLevel


```yaml
Type: Nullable`1
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