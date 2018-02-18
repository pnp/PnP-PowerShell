---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPFolder

## SYNOPSIS
Deletes a folder within a parent folder

## SYNTAX 

### 
```powershell
Remove-PnPFolder [-Name <String>]
                 [-Folder <String>]
                 [-Recycle [<SwitchParameter>]]
                 [-Force [<SwitchParameter>]]
                 [-Web <WebPipeBind>]
                 [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPFolder -Name NewFolder -Folder _catalogs/masterpage
```

Removes the folder 'NewFolder' from '_catalogsmasterpage'

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPFolder -Name NewFolder -Folder _catalogs/masterpage -Recycle
```

Removes the folder 'NewFolder' from '_catalogsmasterpage' and is saved in the Recycle Bin

## PARAMETERS

### -Folder


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

### -Name


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Recycle


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

### -Web


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)