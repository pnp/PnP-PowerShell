---
external help file:
applicable: SharePoint Online, SharePoint 2016
schema: 2.0.0
---
# Measure-PnPList

## SYNOPSIS
Returns statistics on the list object

## SYNTAX 

### 
```powershell
Measure-PnPList [-Identity <ListPipeBind>]
                [-ItemLevel [<SwitchParameter>]]
                [-BrokenPermissions [<SwitchParameter>]]
                [-Web <WebPipeBind>]
                [-Includes <String[]>]
                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Measure-PnPList "Documents"
```

Gets statistics on Documents document library

### ------------------EXAMPLE 2------------------
```powershell
PS:> Measure-PnPList "Documents" -BrokenPermissions -ItemLevel
```

Displays items and folders with broken permissions inside Documents library

## PARAMETERS

### -BrokenPermissions


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

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ItemLevel


```yaml
Type: SwitchParameter
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