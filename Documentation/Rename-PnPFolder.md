---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Rename-PnPFolder

## SYNOPSIS
Renames a folder

## SYNTAX 

### 
```powershell
Rename-PnPFolder [-Folder <String>]
                 [-TargetFolderName <String>]
                 [-Web <WebPipeBind>]
                 [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Rename-PnPFolder -Folder Documents/Reports -TargetFolderName 'Archived Reports'
```

This will rename the folder Reports in the Documents library to 'Archived Reports'

## PARAMETERS

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TargetFolderName


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