---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Measure-PnPResponseTime

## SYNOPSIS
Gets statistics on response time for the specified endpoint by sending probe requests

## SYNTAX 

### 
```powershell
Measure-PnPResponseTime [-Url <DiagnosticEndpointPipeBind>]
                        [-Count <UInt32>]
                        [-WarmUp <UInt32>]
                        [-Timeout <UInt32>]
                        [-Histogram <UInt32>]
                        [-Mode <MeasureResponseTimeMode>]
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


```yaml
Type: UInt32
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Histogram


```yaml
Type: UInt32
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Mode


```yaml
Type: MeasureResponseTimeMode
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Timeout


```yaml
Type: UInt32
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: DiagnosticEndpointPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -WarmUp


```yaml
Type: UInt32
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)