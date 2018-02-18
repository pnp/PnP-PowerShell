---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPRecycleBinItem

## SYNOPSIS
Returns the items in the recycle bin from the context

## SYNTAX 

### 
```powershell
Get-PnPRecycleBinItem [-Identity <GuidPipeBind>]
                      [-FirstStage [<SwitchParameter>]]
                      [-SecondStage [<SwitchParameter>]]
                      [-Includes <String[]>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPRecycleBinItem
```

Returns all items in both the first and the second stage recycle bins in the current site collection

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPRecycleBinItem -Identity f3ef6195-9400-4121-9d1c-c997fb5b86c2
```

Returns all a specific recycle bin item by id

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPRecycleBinItem -FirstStage
```

Returns all items in only the first stage recycle bin in the current site collection

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPRecycleBinItem -SecondStage
```

Returns all items in only the second stage recycle bin in the current site collection

## PARAMETERS

### -FirstStage


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: GuidPipeBind
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

### -SecondStage


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

## OUTPUTS

### [Microsoft.SharePoint.Client.RecycleBinItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.recyclebinitem.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)