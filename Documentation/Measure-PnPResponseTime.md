---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Measure-PnPResponseTime

## SYNOPSIS
Gets statistics on response time for the specified endpoint by sending probe requests

## SYNTAX 

```powershell
Measure-PnPResponseTime [-Count <UInt32>]
                        [-WarmUp <UInt32>]
                        [-Timeout <UInt32>]
                        [-Histogram <UInt32>]
                        [-Mode <MeasureResponseTimeMode>]
                        [-Url <DiagnosticEndpointPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Measure-PnPResponseTime -Count 100 -Timeout 20
```

Calculates statistics on sequence of 100 probe requests, sleeps 20ms between probes

### ------------------EXAMPLE 2------------------
```powershell
PS:> Measure-PnPResponseTime "/Pages/Test.aspx" -Count 1000
```

Calculates statistics on response time of Test.aspx by sending 1000 requests with default sleep time between requests

### ------------------EXAMPLE 3------------------
```powershell
PS:> Measure-PnPResponseTime $web -Count 1000 -WarmUp 10 -Histogram 20 -Timeout 50 | Select -expa Histogram | % {$_.GetEnumerator() | Export-Csv C:\Temp\responsetime.csv -NoTypeInformation}
```

Builds histogram of response time for the home page of the web and exports to CSV for later processing in Excel

## PARAMETERS

### -Count
Number of probe requests to send

```yaml
Type: UInt32
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Histogram
Number of buckets in histogram in output statistics

```yaml
Type: UInt32
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Mode
Response time measurement mode. RoundTrip - measures full request round trip. SPRequestDuration - measures server processing time only, based on SPRequestDuration HTTP header. Latency - difference between RoundTrip and SPRequestDuration

```yaml
Type: MeasureResponseTimeMode
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Timeout
Idle timeout between requests to avoid request throttling

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
Number of warm up requests to send before start calculating statistics

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