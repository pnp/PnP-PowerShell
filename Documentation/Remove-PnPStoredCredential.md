---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPStoredCredential

## SYNOPSIS
Removes a credential

## SYNTAX 

```powershell
Remove-PnPStoredCredential -Name <String>
                           [-Force [<SwitchParameter>]]
```

## DESCRIPTION
Removes a stored credential from the Windows Credential Manager

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPStoredCredential -Name https://tenant.sharepoint.com
```

Removes the specified credential from the Windows Credential Manager

## PARAMETERS

### -Force
If specified you will not be asked for confirmation

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Name
The credential to remove

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)