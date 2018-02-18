---
external help file:
applicable: SharePoint Online, SharePoint 2016
schema: 2.0.0
---
# Measure-PnPWeb

## SYNOPSIS
Returns statistics on the web object

## SYNTAX 

### 
```powershell
Measure-PnPWeb [-Identity <WebPipeBind>]
               [-Recursive [<SwitchParameter>]]
               [-IncludeHiddenList [<SwitchParameter>]]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Measure-PnPWeb
```

Gets statistics on the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Measure-PnPList $web -Recursive
```

Gets statistics on the chosen including all sub webs

## PARAMETERS

### -Identity


```yaml
Type: WebPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeHiddenList


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Recursive


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