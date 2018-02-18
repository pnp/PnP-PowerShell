---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPSearchConfiguration

## SYNOPSIS
Sets the search configuration

## SYNTAX 

### 
```powershell
Set-PnPSearchConfiguration [-Configuration <String>]
                           [-Path <String>]
                           [-Scope <SearchConfigurationScope>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSearchConfiguration -Configuration $config
```

Sets the search configuration for the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPSearchConfiguration -Configuration $config -Scope Site
```

Sets the search configuration for the current site collection

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPSearchConfiguration -Configuration $config -Scope Subscription
```

Sets the search configuration for the current tenant

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPSearchConfiguration -Path searchconfig.xml -Scope Subscription
```

Reads the search configuration from the specified XML file and sets it for the current tenant

## PARAMETERS

### -Configuration


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Scope


```yaml
Type: SearchConfigurationScope
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