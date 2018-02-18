---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPAppSideLoading

## SYNOPSIS
Enables the App SideLoading Feature on a site

## SYNTAX 

### 
```powershell
Set-PnPAppSideLoading [-On [<SwitchParameter>]]
                      [-Off [<SwitchParameter>]]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPAppSideLoading -On
```

This will turn on App side loading

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPAppSideLoading -Off
```

This will turn off App side loading

## PARAMETERS

### -Off


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -On


```yaml
Type: SwitchParameter
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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)