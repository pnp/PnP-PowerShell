---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPClientSideWebPart

## SYNOPSIS
Set Client-Side Web Part properties

## SYNTAX 

```powershell
Set-PnPClientSideWebPart -Identity <ClientSideWebPartPipeBind>
                         -Page <ClientSidePagePipeBind>
                         [-Title <String>]
                         [-PropertiesJson <String>]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets specific client side webpart properties. Notice that the title parameter will only set the -internal- title of webpart. The title which is shown in the UI will, if possible, have to be set using the PropertiesJson parameter. Use Get-PnPClientSideWebPart to retrieve the instance id and properties of a webpart.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPClientSideWebPart -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -PropertiesJson $myproperties
```

Sets the properties of the client side webpart given in the $myproperties variable.

## PARAMETERS

### -Identity
The identity of the webpart. This can be the webpart instance id or the title of a webpart

```yaml
Type: ClientSideWebPartPipeBind
Parameter Sets: (All)

Required: True
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

### -PropertiesJson
Sets the properties as a JSON string.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: True
```

### -Title
Sets the internal title of the webpart. Notice that this will NOT set a visible title.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
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