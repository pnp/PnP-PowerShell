---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPNavigationNode

## SYNOPSIS
Removes a menu item from either the quicklaunch or top navigation

## SYNTAX 

### By Title and Location
```powershell
Remove-PnPNavigationNode -Title <String>
                         -Location <NavigationType>
                         [-Header <String>]
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

### By Location
```powershell
Remove-PnPNavigationNode -All [<SwitchParameter>]
                         -Location <NavigationType>
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPNavigationNode -Title Recent -Location QuickLaunch
```

Will remove the recent navigation node from the quick launch in the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPNavigationNode -Title Home -Location TopNavigationBar -Force
```

Will remove the home navigation node from the top navigation bar without prompting for a confirmation in the current web.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPNavigationNode -Location QuickLaunch -All
```

Will remove all the navigation nodes from the quick launch bar in the current web.

## PARAMETERS

### -All
Specifying the All parameter will remove all the nodes from specifed Location.

```yaml
Type: SwitchParameter
Parameter Sets: By Location

Required: True
Position: Named
Accept pipeline input: False
```

### -Force
Specifying the Force parameter will skip the confirmation question.

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Header
The header where the node is located

```yaml
Type: String
Parameter Sets: By Title and Location

Required: False
Position: Named
Accept pipeline input: False
```

### -Location
The location of the node(s) to remove (QuickLaunch, SearchNav, TopNavigationBar)

```yaml
Type: NavigationType
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Title
The title of the node that needs to be removed

```yaml
Type: String
Parameter Sets: By Title and Location

Required: True
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

### -Web
This parameter allows you to optionally apply the cmdlet action to a subweb within the current web. In most situations this parameter is not required and you can connect to the subweb using Connect-PnPOnline instead. Specify the GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)