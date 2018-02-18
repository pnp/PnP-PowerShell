---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Clear-PnPRecycleBinItem

## SYNOPSIS
Permanently deletes all or a specific recycle bin item

## SYNTAX 

### 
```powershell
Clear-PnPRecycleBinItem [-Identity <RecycleBinItemPipeBind>]
                        [-All [<SwitchParameter>]]
                        [-SecondStageOnly [<SwitchParameter>]]
                        [-Force [<SwitchParameter>]]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPRecycleBinItems | ? FileLeafName -like "*.docx" | Clear-PnpRecycleBinItem
```

Permanently deletes all the items in the first and second stage recycle bins of which the file names have the .docx extension

### ------------------EXAMPLE 2------------------
```powershell
PS:> Clear-PnpRecycleBinItem -Identity 72e4d749-d750-4989-b727-523d6726e442
```

Permanently deletes the recycle bin item with Id 72e4d749-d750-4989-b727-523d6726e442 from the recycle bin

### ------------------EXAMPLE 3------------------
```powershell
PS:> Clear-PnpRecycleBinItem -Identity $item -Force
```

Permanently deletes the recycle bin item stored under variable $item from the recycle bin without asking for confirmation from the end user first

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

### -SecondStageOnly


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