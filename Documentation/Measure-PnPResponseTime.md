---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Measure-PnPResponseTime

## SYNOPSIS
Measures response time for the specified endpoint by sending probe requests and gathering stats.

## SYNTAX 

```powershell
Measure-PnPResponseTime [-Count <UInt32>]
                        [-WarmUp <UInt32>]
                        [-Timeout <UInt32>]
                        [-Histogram <UInt32>]
                        [-Url <DiagnosticEndpointPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## PARAMETERS

### -Count
Number of probe requests

```yaml
Type: UInt32
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Histogram
Number of buckets in histogram

```yaml
Type: UInt32
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Timeout
Idle timeout between requests

```yaml
Type: UInt32
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Url


```yaml
Type: DiagnosticEndpointPipeBind
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
```

### -WarmUp
Number of warm up requests

```yaml
Type: UInt32
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