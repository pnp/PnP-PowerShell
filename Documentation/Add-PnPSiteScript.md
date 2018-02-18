---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Add-PnPSiteScript

## SYNOPSIS
Creates a new Site Script on the current tenant.

## SYNTAX 

```powershell
Add-PnPSiteScript -Title <String>
                  -Content <String>
                  [-Description <String>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPSiteScript -Title "My Site Script" -Description "A more detailed description" -Content $script
```

Adds a new Site Script, where $script variable contains the script.

## PARAMETERS

### -Content
A JSON string containing the site script

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Description
The description of the site script

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Title
The title of the site script

```yaml
Type: String
Parameter Sets: (All)

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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)