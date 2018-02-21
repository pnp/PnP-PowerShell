---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Test-PnPOffice365GroupAlias

## SYNOPSIS
Tests if a given alias is free to be used

## SYNTAX 

```powershell
Test-PnPOffice365GroupAlias -Alias <String>
                            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command allows you to test if a provided alias is free to be used as part of connecting an Office 365 Unified group to an existing classic site collection.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Test-PnPOffice365GroupAlias -Alias "MyGroup"
```

This will test if the alias MyGroup can be used

## PARAMETERS

### -Alias
Specifies the alias of the group. Cannot contain spaces.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)