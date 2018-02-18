---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPNavigationNode

## SYNOPSIS
Removes a menu item from either the quicklaunch or top navigation

## SYNTAX 

### 
```powershell
Remove-PnPNavigationNode [-Identity <NavigationNodePipeBind>]
                         [-All [<SwitchParameter>]]
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPNavigationNode -Identity 1032
```

Removes the navigation node with the specified id

### ------------------EXAMPLE 2------------------
```powershell
PS:> $nodes = Get-PnPNavigationNode -QuickLaunch
PS:>$nodes | Select-Object -First 1 | Remove-PnPNavigationNode -Force
```

Retrieves all navigation nodes from the Quick Launch navigation, then removes the first node in the list and it will not ask for a confirmation

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPNavigationNode -Title Recent -Location QuickLaunch
```

Will remove the recent navigation node from the quick launch in the current web.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Remove-PnPNavigationNode -Title Home -Location TopNavigationBar -Force
```

Will remove the home navigation node from the top navigation bar without prompting for a confirmation in the current web.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Remove-PnPNavigationNode -Location QuickLaunch -All
```

Will remove all the navigation nodes from the quick launch bar in the current web.

## PARAMETERS

### -All


```yaml
Type: SwitchParameter
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

### -Identity


```yaml
Type: NavigationNodePipeBind
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