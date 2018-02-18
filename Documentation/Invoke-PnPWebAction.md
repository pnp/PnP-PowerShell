---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Invoke-PnPWebAction

## SYNOPSIS
Executes operations on web, lists and list items.

## SYNTAX 

### 
```powershell
Invoke-PnPWebAction [-Webs <Web[]>]
                    [-WebAction <Action`1>]
                    [-ShouldProcessWebAction <Func`2>]
                    [-PostWebAction <Action`1>]
                    [-ShouldProcessPostWebAction <Func`2>]
                    [-WebProperties <String[]>]
                    [-ListAction <Action`1>]
                    [-ShouldProcessListAction <Func`2>]
                    [-PostListAction <Action`1>]
                    [-ShouldProcessPostListAction <Func`2>]
                    [-ListProperties <String[]>]
                    [-ListItemAction <Action`1>]
                    [-ShouldProcessListItemAction <Func`2>]
                    [-ListItemProperties <String[]>]
                    [-SubWebs [<SwitchParameter>]]
                    [-DisableStatisticsOutput [<SwitchParameter>]]
                    [-SkipCounting [<SwitchParameter>]]
                    [-Web <WebPipeBind>]
                    [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Invoke-PnPWebAction -ListAction ${function:ListAction}
```

This will call the function ListAction on all the lists located on the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Invoke-PnPWebAction -ShouldProcessListAction ${function:ShouldProcessList} -ListAction ${function:ListAction}
```

This will call the function ShouldProcessList, if it returns true the function ListAction will then be called. This will occur on all lists located on the current web

## PARAMETERS

### -DisableStatisticsOutput


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListAction


```yaml
Type: Action`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListItemAction


```yaml
Type: Action`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListItemProperties


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListProperties


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PostListAction


```yaml
Type: Action`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PostWebAction


```yaml
Type: Action`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ShouldProcessListAction


```yaml
Type: Func`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ShouldProcessListItemAction


```yaml
Type: Func`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ShouldProcessPostListAction


```yaml
Type: Func`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ShouldProcessPostWebAction


```yaml
Type: Func`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ShouldProcessWebAction


```yaml
Type: Func`2
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SkipCounting


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SubWebs


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -WebAction


```yaml
Type: Action`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -WebProperties


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Webs


```yaml
Type: Web[]
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