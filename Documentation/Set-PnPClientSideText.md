---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPClientSideText

## SYNOPSIS
Set Client-Side Text Component properties

## SYNTAX 

```powershell
Set-PnPClientSideText -InstanceId <GuidPipeBind>
                      -Text <String>
                      -Page <ClientSidePagePipeBind>
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets the rendered text in existing client side text component

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSetClientSideText -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -Text "MyText"
```

Sets the text of the client side text component.

## PARAMETERS

### -InstanceId
The instance id of the text component

```yaml
Type: GuidPipeBind
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

### -Text
Text to set

```yaml
Type: String
Parameter Sets: (All)

Required: True
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