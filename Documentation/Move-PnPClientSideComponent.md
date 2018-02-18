---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Move-PnPClientSideComponent

## SYNOPSIS
Moves a Client-Side Component to a different section/column

## SYNTAX 

### 
```powershell
Move-PnPClientSideComponent [-Page <ClientSidePagePipeBind>]
                            [-InstanceId <GuidPipeBind>]
                            [-Section <Int>]
                            [-Column <Int>]
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


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

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

### -Position


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Section


```yaml
Type: Int
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