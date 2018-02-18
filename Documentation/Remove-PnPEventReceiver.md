---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPEventReceiver

## SYNOPSIS
Remove an eventreceiver

## SYNTAX 

### 
```powershell
Remove-PnPEventReceiver [-Identity <EventReceiverPipeBind>]
                        [-List <ListPipeBind>]
                        [-Force [<SwitchParameter>]]
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes/unregisters a specific eventreceiver

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPEventReceiver -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22
```

This will remove the event receiver with ReceiverId "fb689d0e-eb99-4f13-beb3-86692fd39f22" from the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPEventReceiver -List ProjectList -Identity fb689d0e-eb99-4f13-beb3-86692fd39f22
```

This will remove the event receiver with ReceiverId "fb689d0e-eb99-4f13-beb3-86692fd39f22" from the "ProjectList" list

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPEventReceiver -List ProjectList -Identity MyReceiver
```

This will remove the event receiver with ReceiverName "MyReceiver" from the "ProjectList" list

### ------------------EXAMPLE 4------------------
```powershell
PS:> Remove-PnPEventReceiver -List ProjectList
```

This will remove all event receivers from the "ProjectList" list

### ------------------EXAMPLE 5------------------
```powershell
PS:> Remove-PnPEventReceiver
```

This will remove all event receivers from the current site

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPEventReceiver | ? ReceiverUrl -Like "*azurewebsites.net*" | Remove-PnPEventReceiver
```

This will remove all event receivers from the current site which are pointing to a service hosted on Azure Websites

## PARAMETERS

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
Type: EventReceiverPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
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