---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Update-PnPSiteClassification

## SYNOPSIS
Updates Site Classifications for the tenant. Requires a connection to the Microsoft Graph.

## SYNTAX 

### 
```powershell
Update-PnPSiteClassification [-Settings <SiteClassificationsSettings>]
                             [-Classifications <List`1>]
                             [-DefaultClassification <String>]
                             [-UsageGuidelinesUrl <String>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Update-PnPSiteClassification -Classifications "HBI","Top Secret"
```

Replaces the existing values of the site classification settings

### ------------------EXAMPLE 2------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Update-PnPSiteClassification -DefaultClassification "LBI"
```

Sets the default classification value to "LBI". This value needs to be present in the list of classification values.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Connect-PnPOnline -Scopes "Directory.ReadWrite.All"
PS:> Update-PnPSiteClassification -UsageGuidelinesUrl http://aka.ms/sppnp
```

sets the usage guideliness URL to the specified URL.

## PARAMETERS

### -Classifications


```yaml
Type: List`1
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DefaultClassification


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Settings


```yaml
Type: SiteClassificationsSettings
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UsageGuidelinesUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)