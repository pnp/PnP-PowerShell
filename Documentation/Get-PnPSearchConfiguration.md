---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPSearchConfiguration

## SYNOPSIS
Returns the search configuration

## SYNTAX 

### 
```powershell
Get-PnPSearchConfiguration [-Scope <SearchConfigurationScope>]
                           [-Path <String>]
                           [-OutputFormat <OutputFormat>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSearchConfiguration
```

Returns the search configuration for the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSearchConfiguration -Scope Site
```

Returns the search configuration for the current site collection

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPSearchConfiguration -Scope Subscription
```

Returns the search configuration for the current tenant

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPSearchConfiguration -Path searchconfig.xml -Scope Subscription
```

Returns the search configuration for the current tenant and saves it to the specified file

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPSearchConfiguration -Scope Site -OutputFormat ManagedPropertyMappings
```

Returns all custom managed properties and crawled property mapping at the current site collection

## PARAMETERS

### -OutputFormat


```yaml
Type: OutputFormat
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

## OUTPUTS

### System.String

Does not return a string when the -Path parameter has been specified.

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)