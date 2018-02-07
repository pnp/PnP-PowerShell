---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Grant-PnPSiteDesignRights

## SYNOPSIS
Grants the specified principals rights to use the site design.

## SYNTAX 

```powershell
Grant-PnPSiteDesignRights -Principals <String[]>
                          -Identity <TenantSiteDesignPipeBind>
                          [-Rights <TenantSiteDesignPrincipalRights>]
                          [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Grant-PnPSiteDesignRights -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd -Principals "myuser@mydomain.com","myotheruser@mydomain.com"
```

Grants the specified principals View rights on the site design specified

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSiteDesign -Title "MySiteDesign" -SiteScriptIds 438548fd-60dd-42cf-b843-2db506c8e259 -WebTemplate TeamSite | Grant-PnPSiteDesignRights -Principals "myuser@mydomain.com","myotheruser@mydomain.com"
```

Grants the specified principals View rights on the site design specified

## PARAMETERS

### -Identity
The site design to use.

```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: True
```

### -Principals
One or more principals to grant rights to.

```yaml
Type: String[]
Parameter Sets: (All)

Required: True
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