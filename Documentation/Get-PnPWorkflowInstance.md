---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPWorkflowInstance

## SYNOPSIS
Get workflow instances

## SYNTAX 

```powershell
Get-PnPWorkflowInstance -List <ListPipeBind>
                        -ListItem <ListItemPipeBind>
                        [-Web <WebPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Gets all workflow instances

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPWorkflowInstance -List "My Library" -ListItem $ListItem
```

Retrieves workflow instances running against the provided item on list "My Library"

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPWorkflowInstance -List "My Library" -ListItem 2
```

Retrieves workflow instances running against the provided item with 2 in the list "My Library"

## PARAMETERS

### -List
The List for which workflow instances should be retrieved

```yaml
Type: ListPipeBind
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: False
```

### -ListItem
The List Item for which workflow instances should be retrieved

```yaml
Type: ListItemPipeBind
Parameter Sets: (All)

Required: True
Position: 1
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