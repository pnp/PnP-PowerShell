---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Move-PnPFolder

## SYNOPSIS
Move a folder to another location in the current web

## SYNTAX 

### 
```powershell
Move-PnPFolder [-Folder <String>]
               [-TargetFolder <String>]
               [-Web <WebPipeBind>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Move-PnPFolder -Folder Documents/Reports -TargetFolder 'Archived Reports'
```

This will move the folder Reports in the Documents library to the 'Archived Reports' library

### ------------------EXAMPLE 2------------------
```powershell
PS:> Move-PnPFolder -Folder 'Shared Documents/Reports/2016/Templates' -TargetFolder 'Shared Documents/Reports'
```

This will move the folder Templates to the new location in 'Shared Documents/Reports'

## PARAMETERS

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TargetFolder


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