---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPView

## SYNOPSIS
Adds a view to a list

## SYNTAX 

### 
```powershell
Add-PnPView [-List <ListPipeBind>]
            [-Title <String>]
            [-Query <String>]
            [-Fields <String[]>]
            [-ViewType <ViewType>]
            [-RowLimit <UInt32>]
            [-Personal [<SwitchParameter>]]
            [-SetAsDefault [<SwitchParameter>]]
            [-Paged [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Add-PnPView -List "Demo List" -Title "Demo View" -Fields "Title","Address"
```

Adds a view named "Demo view" to the "Demo List" list.

### ------------------EXAMPLE 2------------------
```powershell
Add-PnPView -List "Demo List" -Title "Demo View" -Fields "Title","Address" -Paged
```

Adds a view named "Demo view" to the "Demo List" list and makes sure there's paging on this view.

## PARAMETERS

### -Fields


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Paged


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Personal


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Query


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RowLimit


```yaml
Type: UInt32
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SetAsDefault


```yaml
Type: SwitchParameter
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

### -ViewType


```yaml
Type: ViewType
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

## OUTPUTS

### [Microsoft.SharePoint.Client.View](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.view.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)