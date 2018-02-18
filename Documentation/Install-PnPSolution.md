---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Install-PnPSolution

## SYNOPSIS
Installs a sandboxed solution to a site collection. WARNING! This method can delete your composed look gallery due to the method used to activate the solution. We recommend you to only to use this cmdlet if you are okay with that.

## SYNTAX 

### 
```powershell
Install-PnPSolution [-PackageId <GuidPipeBind>]
                    [-SourceFilePath <String>]
                    [-MajorVersion <Int>]
                    [-MinorVersion <Int>]
                    [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Install-PnPSolution -PackageId c2f5b025-7c42-4d3a-b579-41da3b8e7254 -SourceFilePath mypackage.wsp
```

Installs the package to the current site

## PARAMETERS

### -MajorVersion


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MinorVersion


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PackageId


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SourceFilePath


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