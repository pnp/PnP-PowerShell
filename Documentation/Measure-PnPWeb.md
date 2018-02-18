---
external help file:
applicable: SharePoint Online, SharePoint 2016
schema: 2.0.0
---
# Measure-PnPWeb

## SYNOPSIS
Returns statistics on the web object

## SYNTAX 

```powershell
Measure-PnPWeb [-Recursive [<SwitchParameter>]]
               [-IncludeHiddenList [<SwitchParameter>]]
               [-Identity <WebPipeBind>]
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
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
```

### -IncludeHiddenList
Include hidden lists in statistics calculation

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Recursive
Iterate all sub webs recursively

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)