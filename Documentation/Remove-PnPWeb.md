---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPWeb

## SYNOPSIS
Removes a subweb in the current web

## SYNTAX 

### 
```powershell
Remove-PnPWeb [-Url <String>]
              [-Identity <WebPipeBind>]
              [-Force [<SwitchParameter>]]
              [-Web <WebPipeBind>]
              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPWeb -Url projectA
```

Remove a web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPWeb -Identity 5fecaf67-6b9e-4691-a0ff-518fc9839aa0
```

Remove a web specified by its ID

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPSubWebs | Remove-PnPWeb -Force
```

Remove all subwebs and do not ask for confirmation

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: WebPipeBind
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