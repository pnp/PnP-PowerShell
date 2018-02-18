---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPAuditing

## SYNOPSIS
Set Auditing setting for a site

## SYNTAX 

### Specific flags
```powershell
Set-PnPAuditing [-RetentionTime <Int>]
                [-TrimAuditLog [<SwitchParameter>]]
                [-EditItems [<SwitchParameter>]]
                [-CheckOutCheckInItems [<SwitchParameter>]]
                [-MoveCopyItems [<SwitchParameter>]]
                [-DeleteRestoreItems [<SwitchParameter>]]
                [-EditContentTypesColumns [<SwitchParameter>]]
                [-SearchContent [<SwitchParameter>]]
                [-EditUsersPermissions [<SwitchParameter>]]
                [-Connection <SPOnlineConnection>]
```

### Enable all
```powershell
Set-PnPAuditing -EnableAll [<SwitchParameter>]
                [-RetentionTime <Int>]
                [-TrimAuditLog [<SwitchParameter>]]
                [-Connection <SPOnlineConnection>]
```

### Disable All
```powershell
Set-PnPAuditing -DisableAll [<SwitchParameter>]
                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPAuditing -EnableAll
```

Enables all auditing settings for the current site

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPAuditing -DisableAll
```

Disables all auditing settings for the current site

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPAuditing -RetentionTime 7
```

Sets the audit log trimming to 7 days, this also enables the automatic trimming of the audit log

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPAuditing -TrimAuditLog
```

Enables the automatic trimming of the audit log

### ------------------EXAMPLE 5------------------
```powershell
PS:> Set-PnPAuditing -RetentionTime 7 -CheckOutCheckInItems -MoveCopyItems -SearchContent
```

Sets the audit log trimming to 7 days, this also enables the automatic trimming of the audit log.

Do auditing for:
- Checking out or checking in items
- Moving or copying items to another location in the site
- Searching site content

## PARAMETERS

### -CheckOutCheckInItems
Audit checking out or checking in items

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -DeleteRestoreItems
Audit deleting or restoring items

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -DisableAll
Disable all audit flags

```yaml
Type: SwitchParameter
Parameter Sets: Disable All

Required: True
Position: Named
Accept pipeline input: False
```

### -EditContentTypesColumns
Audit editing content types and columns

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -EditItems
Audit editing items

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -EditUsersPermissions
Audit editing users and permissions

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -EnableAll
Enable all audit flags

```yaml
Type: SwitchParameter
Parameter Sets: Enable all

Required: True
Position: Named
Accept pipeline input: False
```

### -MoveCopyItems
Audit moving or copying items to another location in the site.

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -RetentionTime
Set the retention time

```yaml
Type: Int
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -SearchContent
Audit searching site content

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

Required: False
Position: Named
Accept pipeline input: False
```

### -TrimAuditLog
Trim the audit log

```yaml
Type: SwitchParameter
Parameter Sets: Specific flags

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