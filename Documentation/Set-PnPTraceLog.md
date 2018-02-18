---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPTraceLog

## SYNOPSIS
Turn log tracing on or off

## SYNTAX 

### 
```powershell
Set-PnPTraceLog [-On [<SwitchParameter>]]
                [-LogFile <String>]
                [-Level <LogLevel>]
                [-Delimiter <String>]
                [-IndentSize <Int>]
                [-AutoFlush <Boolean>]
                [-Off [<SwitchParameter>]]
```

## DESCRIPTION
Defines if tracing should be turned on. PnP Core, which is the foundation of these cmdlets, uses the standard Trace functionality of .NET. With this cmdlet you can turn capturing of this trace to a log file on or off. Notice that basically only the Provisioning Engine writes to the tracelog which means that cmdlets related to the engine will produce output.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPTraceLog -On -LogFile traceoutput.txt
```

This turns on trace logging to the file 'traceoutput.txt' and will capture events of at least 'Information' level.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPTraceLog -On -LogFile traceoutput.txt -Level Debug
```

This turns on trace logging to the file 'traceoutput.txt' and will capture debug events.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPTraceLog -On -LogFile traceoutput.txt -Level Debug -Delimiter ","
```

This turns on trace logging to the file 'traceoutput.txt' and will write the entries as comma separated. Debug events are captured.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPTraceLog -Off
```

This turns off trace logging. It will flush any remaining messages to the log file.

## PARAMETERS

### -AutoFlush


```yaml
Type: Boolean
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Delimiter


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IndentSize


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Level


```yaml
Type: LogLevel
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -LogFile


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)