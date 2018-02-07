---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPOffice365GroupToSite

## SYNOPSIS
Groupifies a classic team site by creating a group for it and connecting the site with the newly created group

## SYNTAX 

```powershell
Add-PnPOffice365GroupToSite -Alias <String>
                            -DisplayName <String>
                            [-Description <String>]
                            [-Classification <String>]
                            [-IsPublic [<SwitchParameter>]]
                            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
This command allows you to add an Office 365 Unified group to an existing classic site collection. It acts on the current site collection which you connected to with Connect-PnPOnline.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPOffice365GroupToSite -Alias "MyGroup" -DisplayName = "My new Group"
```

This will add a group call MyGroup to the current site collection

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

### -Classification
Specifies the classification of the group.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Description
The optional description of the group.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -DisplayName
The display name of the group.

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -IsPublic
Specifies if the group is public. Defaults to false.

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
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