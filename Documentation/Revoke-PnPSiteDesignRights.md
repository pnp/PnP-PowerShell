---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Revoke-PnPSiteDesignRights

## SYNOPSIS
Revokes the specified principals rights to use the site design.

## SYNTAX 

### 
```powershell
Revoke-PnPSiteDesignRights [-Identity <TenantSiteDesignPipeBind>]
                           [-Principals <String[]>]
                           [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Revoke-PnPSiteDesignRights -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd -Principals "myuser@mydomain.com","myotheruser@mydomain.com"
```

Revokes rights to the specified principals on the site design specified

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSiteDesign -Identity 5c73382d-9643-4aa0-9160-d0cba35e40fd | Revoke-PnPSiteDesignRights -Principals "myuser@mydomain.com","myotheruser@mydomain.com"
```

Revokes rights to the specified principals on the site design specified

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