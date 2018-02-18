---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Get-PnPClientSideComponent

## SYNOPSIS
Retrieve one or more Client-Side components from a page

## SYNTAX 

```powershell
Get-PnPClientSideComponent -Page <ClientSidePagePipeBind>
                           [-InstanceId <GuidPipeBind>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPClientSideComponent -Page Home
```

Returns all controls defined on the given page.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPClientSideComponent -Page Home -Identity a2875399-d6ff-43a0-96da-be6ae5875f82
```

Returns a specific control defined on the given page.

## PARAMETERS

### -InstanceId
The instance id of the component

```yaml
Type: GuidPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: True
```

### -Page
The name of the page

```yaml
Type: ClientSidePagePipeBind
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: True
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