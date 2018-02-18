---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSiteScript

## SYNOPSIS
Updates an existing Site Script on the current tenant.

## SYNTAX 

```powershell
Set-PnPSiteScript -Identity <TenantSiteScriptPipeBind>
                  [-Title <String>]
                  [-Description <String>]
                  [-Content <String>]
                  [-Version <Int>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSiteScript -Identity f1d55d9b-b116-4f54-bc00-164a51e7e47f -Title "My Site Script"
```

Updates an existing Site Script and changes the title.

### ------------------EXAMPLE 2------------------
```powershell
PS:> $script = Get-PnPSiteScript -Identity f1d55d9b-b116-4f54-bc00-164a51e7e47f 
PS:> Set-PnPSiteScript -Identity $script -Title "My Site Script"
```

Updates an existing Site Script and changes the title.

## PARAMETERS

### -Content
A JSON string containing the site script

```yaml
Type: String
Parameter Sets: (All)

Required: False
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

### -Identity
The guid or an object representing the site script

```yaml
Type: TenantSiteScriptPipeBind
Parameter Sets: (All)

Required: True
Position: Named
Accept pipeline input: False
```

### -Title
The title of the site script

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Version
Specifies the version of the site script

```yaml
Type: Int
Parameter Sets: (All)

Required: False
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