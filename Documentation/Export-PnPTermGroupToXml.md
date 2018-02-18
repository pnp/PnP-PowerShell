---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Export-PnPTermGroupToXml

## SYNOPSIS
Exports a taxonomy TermGroup to either the output or to an XML file.

## SYNTAX 

### 
```powershell
Export-PnPTermGroupToXml [-Identity <Id, Title or TermGroup>]
                         [-Out <String>]
                         [-FullTemplate [<SwitchParameter>]]
                         [-Encoding <Encoding>]
                         [-Force [<SwitchParameter>]]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Export-PnPTermGroupToXml
```

Exports all term groups in the default site collection term store to the standard output

### ------------------EXAMPLE 2------------------
```powershell
PS:> Export-PnPTermGroupToXml -Out output.xml
```

Exports all term groups in the default site collection term store to the file 'output.xml' in the current folder

### ------------------EXAMPLE 3------------------
```powershell
PS:> Export-PnPTermGroupToXml -Out c:\output.xml -Identity "Test Group"
```

Exports the term group with the specified name to the file 'output.xml' located in the root folder of the C: drive.

### ------------------EXAMPLE 4------------------
```powershell
PS:> $termgroup = Get-PnPTermGroup -GroupName Test
PS:> $termgroup | Export-PnPTermGroupToXml -Out c:\output.xml
```

Retrieves a termgroup and subsequently exports that term group to a the file named 'output.xml'

## PARAMETERS

### -Encoding


```yaml
Type: Encoding
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FullTemplate


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: Id, Title or TermGroup
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Out


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)