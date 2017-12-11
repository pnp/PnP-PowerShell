---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Revoke-PnPSiteDesignRights

## SYNOPSIS
Revokes the specified principals rights to use the site design.

## SYNTAX 

```powershell
Revoke-PnPSiteDesignRights -Principals <String[]>
                           -Identity <TenantSiteDesignPipeBind>
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
The site design to use.

```yaml
Type: TenantSiteDesignPipeBind
Parameter Sets: (All)

Required: True
Position: 0
Accept pipeline input: True
```

### -Principals
One or more principals to revoke.

```yaml
Type: String[]
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