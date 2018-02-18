---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPList

## SYNOPSIS
Deletes a list

## SYNTAX 

### 
```powershell
Remove-PnPList [-Identity <ListPipeBind>]
               [-Recycle [<SwitchParameter>]]
               [-Force [<SwitchParameter>]]
               [-Web <WebPipeBind>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPList -Identity Announcements
```

Removes the list named 'Announcements'. Asks for confirmation.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPList -Identity Announcements -Force
```

Removes the list named 'Announcements' without asking for confirmation.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPList -Title Announcements -Recycle
```

Removes the list named 'Announcements' and saves to the Recycle Bin

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: ListPipeBind
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