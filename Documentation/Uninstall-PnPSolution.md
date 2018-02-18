---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Uninstall-PnPSolution

## SYNOPSIS
Uninstalls a sandboxed solution from a site collection

## SYNTAX 

### 
```powershell
Uninstall-PnPSolution [-PackageId <GuidPipeBind>]
                      [-PackageName <String>]
                      [-MajorVersion <Int>]
                      [-MinorVersion <Int>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Uninstall-PnPSolution -PackageId c2f5b025-7c42-4d3a-b579-41da3b8e7254 -SourceFilePath mypackage.wsp
```

Removes the package to the current site

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

### -PackageName


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