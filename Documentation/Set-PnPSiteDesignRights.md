---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Set-PnPSiteDesignRights

## SYNOPSIS
Grants the specified principles rights to the site design.

## SYNTAX 

```powershell
Set-PnPSiteDesignRights [-Principles <String[]>]
                        [-Rights <TenantSiteDesignPrincipalRights>]
                        [-Identity <GuidPipeBind>]
                        [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPSiteDesignRights -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd -Principles "myuser@mydomain.com","myotheruser@mydomain.com"
```

Grants the specified principles View rights on the site design specified

## PARAMETERS

### -Identity
The site design to use.

```yaml
Type: GuidPipeBind
Parameter Sets: (All)

Required: False
Position: 0
Accept pipeline input: True
```

### -Principles
The principles to grant rights to.

```yaml
Type: String[]
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Rights
The rights to set. Defaults to 'View'

```yaml
Type: TenantSiteDesignPrincipalRights
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