---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Grant-PnPSiteDesignRights

## SYNOPSIS
Grants the specified principals rights to use the site design.

## SYNTAX 

### 
```powershell
Grant-PnPSiteDesignRights [-Identity <TenantSiteDesignPipeBind>]
                          [-Principals <String[]>]
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


```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Principals


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Rights


```yaml
Type: TenantSiteDesignPrincipalRights
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