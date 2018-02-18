---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPList

## SYNOPSIS
Creates a new list

## SYNTAX 

### 
```powershell
New-PnPList [-Title <String>]
            [-Template <ListTemplateType>]
            [-Url <String>]
            [-Hidden [<SwitchParameter>]]
            [-EnableVersioning [<SwitchParameter>]]
            [-EnableContentTypes [<SwitchParameter>]]
            [-OnQuickLaunch [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPList -Title Announcements -Template Announcements
```

Create a new announcements list

### ------------------EXAMPLE 2------------------
```powershell
PS:> New-PnPList -Title "Demo List" -Url "DemoList" -Template Announcements
```

Create a list with a title that is different from the url

### ------------------EXAMPLE 3------------------
```powershell
PS:> New-PnPList -Title HiddenList -Template GenericList -Hidden
```

Create a new custom list and hides it from the SharePoint UI.

## PARAMETERS

### -EnableContentTypes


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -EnableVersioning


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Hidden


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -OnQuickLaunch


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Template


```yaml
Type: ListTemplateType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


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