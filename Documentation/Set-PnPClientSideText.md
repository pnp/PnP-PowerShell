---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPClientSideText

## SYNOPSIS
Set Client-Side Text Component properties

## SYNTAX 

### 
```powershell
Set-PnPClientSideText [-Page <ClientSidePagePipeBind>]
                      [-InstanceId <GuidPipeBind>]
                      [-Text <String>]
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


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Page


```yaml
Type: ClientSidePagePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Text


```yaml
Type: String
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