---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPWorkflowInstance

## SYNOPSIS
Get workflow instances

## SYNTAX 

### 
```powershell
Get-PnPWorkflowInstance [-List <ListPipeBind>]
                        [-ListItem <ListItemPipeBind>]
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


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ListItem


```yaml
Type: ListItemPipeBind
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