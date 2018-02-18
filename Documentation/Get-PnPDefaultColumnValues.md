---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPDefaultColumnValues

## SYNOPSIS
Gets the default column values for all folders in document library

## SYNTAX 

### 
```powershell
Get-PnPDefaultColumnValues [-List <ListPipeBind>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Gets the default column values for a document library, per folder. Supports both text, people and taxonomy fields.

## PARAMETERS

### -List


```yaml
Type: ListPipeBind
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