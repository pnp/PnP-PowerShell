---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPOffice365GroupToSite

## SYNOPSIS
Groupifies a classic team site by creating an Office 365 group for it and connecting the site with the newly created group

## SYNTAX 

### 
```powershell
Add-PnPOffice365GroupToSite [-Url <String>]
                            [-Alias <String>]
                            [-Description <String>]
                            [-DisplayName <String>]
                            [-Classification <String>]
                            [-IsPublic [<SwitchParameter>]]
                            [-KeepOldHomePage [<SwitchParameter>]]
                            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command allows you to add an Office 365 Unified group to an existing classic site collection.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPOffice365GroupToSite -Url "https://contoso.sharepoint.com/sites/FinanceTeamsite" -Alias "FinanceTeamsite" -DisplayName = "My finance team site group"
```

This will add a group called MyGroup to the current site collection

## PARAMETERS

### -Alias


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Classification


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DisplayName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsPublic


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -KeepOldHomePage


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