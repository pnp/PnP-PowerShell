---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Restore-PnPRecycleBinItem

## SYNOPSIS
Restores the provided recycle bin item to its original location

## SYNTAX 

### 
```powershell
Restore-PnPRecycleBinItem [-Identity <RecycleBinItemPipeBind>]
                          [-All [<SwitchParameter>]]
                          [-Force [<SwitchParameter>]]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Restore-PnpRecycleBinItem -Identity 72e4d749-d750-4989-b727-523d6726e442
```

Restores the recycle bin item with Id 72e4d749-d750-4989-b727-523d6726e442 to its original location

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPRecycleBinItems | ? FileLeafName -like "*.docx" | Restore-PnpRecycleBinItem
```

Restores all the items in the first and second stage recycle bins to their original location of which the filename ends with the .docx extension

## PARAMETERS

### -All


```yaml
Type: SwitchParameter
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

### -Identity


```yaml
Type: RecycleBinItemPipeBind
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