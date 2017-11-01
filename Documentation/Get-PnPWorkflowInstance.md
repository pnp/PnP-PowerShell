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
Get-PnPWorkflowInstance -List <List>
                        -ListItem <ListItem>
                        [-Web <WebPipeBind>]
```

## DESCRIPTION
Gets all workflow instances

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
Get-PnPWorkflowInstance -Item $SPListItem
```

Retreives workflow instances running against the provided item

### ------------------EXAMPLE 2------------------
```powershell
Get-PnPWorkflowInstance -Item $SPListItem
```

Retreives workflow instances running against the provided item

## PARAMETERS

### -List
The SPList for which workflow instances should be retreived

```yaml
Type: List
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: False
```

### -ListItem
The SPListItem for which workflow instances should be retreived

```yaml
Type: ListItem
Parameter Sets: (All)

Required: True
Position: 1
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

# RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)