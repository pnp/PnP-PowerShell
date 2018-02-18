---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPList

## SYNOPSIS
Returns a List object

## SYNTAX 

### 
```powershell
Get-PnPList [-Identity <ListPipeBind>]
            [-ThrowExceptionIfListNotFound [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            [-Includes <String[]>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPList
```

Returns all lists in the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPList -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```

Returns a list with the given id.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPList -Identity Lists/Announcements
```

Returns a list with the given url.

## PARAMETERS

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

### -ThrowExceptionIfListNotFound


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

## OUTPUTS

### [Microsoft.SharePoint.Client.List](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.list.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)