---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPClientSideWebPart

## SYNOPSIS
Set Client-Side Web Part properties

## SYNTAX 

### 
```powershell
Set-PnPClientSideWebPart [-Page <ClientSidePagePipeBind>]
                         [-Identity <ClientSideWebPartPipeBind>]
                         [-Title <String>]
                         [-PropertiesJson <String>]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets specific client side webpart properties. Notice that the title parameter will only set the -internal- title of webpart. The title which is shown in the UI will, if possible, have to be set using the PropertiesJson parameter. Use Get-PnPClientSideComponent to retrieve the instance id and properties of a webpart.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPClientSideWebPart -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -PropertiesJson $myproperties
```

Sets the properties of the client side webpart given in the $myproperties variable.

## PARAMETERS

### -Identity


```yaml
Type: ClientSideWebPartPipeBind
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

### -PropertiesJson


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


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