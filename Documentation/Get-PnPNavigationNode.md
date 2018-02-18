---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPNavigationNode

## SYNOPSIS
Returns all or a specific navigation node

## SYNTAX 

### 
```powershell
Get-PnPNavigationNode [-Location <NavigationType>]
                      [-Id <Int>]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPNavigationNode
```

Returns all navigation nodes in the quicklaunch navigation

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPNavigationNode -QuickLaunch
```

Returns all navigation nodes in the quicklaunch navigation

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPNavigationNode -TopNavigationBar
```

Returns all navigation nodes in the top navigation bar

### ------------------EXAMPLE 4------------------
```powershell
PS:> $node = Get-PnPNavigationNode -Id 2030
PS> $children = $node.Children
```

Returns the selected navigation node and retrieves any children

## PARAMETERS

### -Id


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Location


```yaml
Type: NavigationType
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