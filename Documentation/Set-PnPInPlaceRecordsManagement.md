---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPInPlaceRecordsManagement

## SYNOPSIS
Activates or deactivates in the place records management feature.

## SYNTAX 

### 
```powershell
Set-PnPInPlaceRecordsManagement [-On [<SwitchParameter>]]
                                [-Off [<SwitchParameter>]]
                                [-Web <WebPipeBind>]
                                [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPInPlaceRecordsManagement -On
```

Activates In Place Records Management

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPInPlaceRecordsManagement -Off
```

Deactivates In Place Records Management

## PARAMETERS

### -Off


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -On


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