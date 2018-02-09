---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPNavigationNode

## SYNOPSIS
Returns all or a specific navigation node

## SYNTAX 

### All nodes by location
```powershell
Get-PnPNavigationNode [-Location <NavigationType>]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

### A single node by ID
```powershell
Get-PnPNavigationNode [-Id <Int>]
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
The Id of the node to retrieve

```yaml
Type: Int
Parameter Sets: A single node by ID

Required: False
Position: Named
Accept pipeline input: False
```

### -Location
The location of the nodes to retrieve. Either TopNavigationBar, QuickLaunch

```yaml
Type: NavigationType
Parameter Sets: All nodes by location

Required: False
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