---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPSitePolicy

## SYNOPSIS
Retrieves all or a specific site policy

## SYNTAX 

### 
```powershell
Get-PnPSitePolicy [-AllAvailable [<SwitchParameter>]]
                  [-Name <String>]
                  [-Web <WebPipeBind>]
                  [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSitePolicy
```

Retrieves the current applied site policy.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSitePolicy -AllAvailable
```

Retrieves all available site policies.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPSitePolicy -Name "Contoso HBI"
```

Retrieves an available site policy with the name "Contoso HBI".

## PARAMETERS

### -AllAvailable


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


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

## OUTPUTS

### OfficeDevPnP.Core.Entities.SitePolicyEntity

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)