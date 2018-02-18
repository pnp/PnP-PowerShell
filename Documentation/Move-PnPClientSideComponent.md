---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Move-PnPClientSideComponent

## SYNOPSIS
Moves a Client-Side Component to a different section/column

## SYNTAX 

### Move to other section
```powershell
Move-PnPClientSideComponent -Section <Int>
                            -InstanceId <GuidPipeBind>
                            -Page <ClientSidePagePipeBind>
                            [-Position <Int>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

### Move to other column
```powershell
Move-PnPClientSideComponent -Column <Int>
                            -InstanceId <GuidPipeBind>
                            -Page <ClientSidePagePipeBind>
                            [-Position <Int>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

### Move within a column
```powershell
Move-PnPClientSideComponent -Position <Int>
                            -InstanceId <GuidPipeBind>
                            -Page <ClientSidePagePipeBind>
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

### Move to other section and column
```powershell
Move-PnPClientSideComponent -Section <Int>
                            -Column <Int>
                            -InstanceId <GuidPipeBind>
                            -Page <ClientSidePagePipeBind>
                            [-Position <Int>]
                            [-Web <WebPipeBind>]
                            [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Moves a Client-Side Component to a different location on the page. Notice that the sections and or columns need to be present before moving the component.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Move-PnPClientSideComponent -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -Section 1
```

Moves the specified component to the first section of the page.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Move-PnPClientSideComponent -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -Column 2
```

Moves the specified component to the second column of the current section.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Move-PnPClientSideComponent -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -Section 1 -Column 2
```

Moves the specified component to the first section of the page into the second column.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Move-PnPClientSideComponent -Page Home -InstanceId a2875399-d6ff-43a0-96da-be6ae5875f82 -Section 1 -Column 2 -Position 2
```

Moves the specified component to the first section of the page into the second column and sets the column to position 2 in the list of webparts.

## PARAMETERS

### -Column
The column to move the webpart to

```yaml
Type: Int
Parameter Sets: Move to other column

Required: True
Position: Named
Accept pipeline input: False
```

### -InstanceId
The instance id of the control. Use Get-PnPClientSideControl retrieve the instance ids.

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

### -Position
Change to order of the webpart in the column

```yaml
Type: Int
Parameter Sets: Move to other column

Required: False
Position: Named
Accept pipeline input: False
```

### -Section
The section to move the webpart to

```yaml
Type: Int
Parameter Sets: Move to other section

Required: True
Position: Named
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