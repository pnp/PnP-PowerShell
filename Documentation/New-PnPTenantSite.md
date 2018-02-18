---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# New-PnPTenantSite

## SYNOPSIS
Creates a new site collection for the current tenant

## SYNTAX 

### 
```powershell
New-PnPTenantSite [-Title <String>]
                  [-Url <String>]
                  [-Description <String>]
                  [-Owner <String>]
                  [-Lcid <UInt32>]
                  [-Template <String>]
                  [-TimeZone <Int>]
                  [-ResourceQuota <Double>]
                  [-ResourceQuotaWarningLevel <Double>]
                  [-StorageQuota <Int>]
                  [-StorageQuotaWarningLevel <Int>]
                  [-RemoveDeletedSite [<SwitchParameter>]]
                  [-Wait [<SwitchParameter>]]
                  [-Force [<SwitchParameter>]]
                  [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
The New-PnPTenantSite cmdlet creates a new site collection for the current company. However, creating a new SharePoint
Online site collection fails if a deleted site with the same URL exists in the Recycle Bin. If you want to use this command for an on-premises farm, please refer to http://blogs.msdn.com/b/vesku/archive/2014/06/09/provisioning-site-collections-using-sp-app-model-in-on-premises-with-just-csom.aspx 

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPTenantSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso -Owner user@example.org -TimeZone 4 -Template STS#0
```

This will add a site collection with the title 'Contoso', the url 'https://tenant.sharepoint.com/sites/contoso', the timezone 'UTC+01:00',the owner 'user@example.org' and the template used will be STS#0, a TeamSite

### ------------------EXAMPLE 2------------------
```powershell
PS:> New-PnPTenantSite -Title Contoso -Url /sites/contososite -Owner user@example.org -TimeZone 4 -Template STS#0
```

This will add a site collection with the title 'Contoso', the url 'https://tenant.sharepoint.com/sites/contososite' of which the base part will be picked up from your current connection, the timezone 'UTC+01:00', the owner 'user@example.org' and the template used will be STS#0, a TeamSite

## PARAMETERS

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Lcid


```yaml
Type: UInt32
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owner


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RemoveDeletedSite


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ResourceQuota


```yaml
Type: Double
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ResourceQuotaWarningLevel


```yaml
Type: Double
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StorageQuota


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -StorageQuotaWarningLevel


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Template


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TimeZone


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Wait


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

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Locale IDs](http://go.microsoft.com/fwlink/p/?LinkId=242911Id=242911)[Resource Usage Limits on Sandboxed Solutions in SharePoint 2010](http://msdn.microsoft.com/en-us/library/gg615462.aspx.)[Creating on-premises site collections using CSOM](http://blogs.msdn.com/b/vesku/archive/2014/06/09/provisioning-site-collections-using-sp-app-model-in-on-premises-with-just-csom.aspx)