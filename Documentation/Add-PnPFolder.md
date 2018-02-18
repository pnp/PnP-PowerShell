---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPFolder

## SYNOPSIS
Creates a folder within a parent folder

## SYNTAX 

### 
```powershell
Add-PnPFolder [-Name <String>]
              [-Folder <String>]
              [-Web <WebPipeBind>]
              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPFolder -Name NewFolder -Folder _catalogs/masterpage
```

This will create the folder NewFolder in the masterpage catalog

## PARAMETERS

### -Folder


```yaml
Type: String
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