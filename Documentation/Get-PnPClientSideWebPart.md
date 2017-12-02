---
external help file:
applicable: SharePoint 2016
schema: 2.0.0
---
# Get-PnPClientSideWebPart

## SYNOPSIS
Retrieve one or more Client-Side Web Parts from a page

## SYNTAX 

```powershell
Get-PnPClientSideWebPart -Page <ClientSidePagePipeBind>
                         [-Identity <ClientSideWebPartPipeBind>]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPClientSideWebPart -Page Home
```

Returns all webparts defined on the given page.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPClientSideWebPart -Page Home -Identity a2875399-d6ff-43a0-96da-be6ae5875f82
```

Returns a specific webpart defined on the given page.

## PARAMETERS

### -Identity
The identity of the webpart. This can be the webpart instance id or the title of a webpart

```yaml
Type: ClientSideWebPartPipeBind
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
The GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)