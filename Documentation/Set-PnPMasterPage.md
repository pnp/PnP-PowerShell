---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPMasterPage

## SYNOPSIS
Set the masterpage

## SYNTAX 

### 
```powershell
Set-PnPMasterPage [-MasterPageServerRelativeUrl <String>]
                  [-CustomMasterPageServerRelativeUrl <String>]
                  [-MasterPageSiteRelativeUrl <String>]
                  [-CustomMasterPageSiteRelativeUrl <String>]
                  [-Web <WebPipeBind>]
                  [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets the default master page of the current web.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master
```

Sets the master page based on a server relative URL

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master -CustomMasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master
```

Sets the master page and custom master page based on a server relative URL

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPMasterPage -MasterPageSiteRelativeUrl _catalogs/masterpage/oslo.master
```

Sets the master page based on a site relative URL

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPMasterPage -MasterPageSiteRelativeUrl _catalogs/masterpage/oslo.master -CustomMasterPageSiteRelativeUrl _catalogs/masterpage/oslo.master
```

Sets the master page and custom master page based on a site relative URL

## PARAMETERS

### -CustomMasterPageServerRelativeUrl


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "CustomMasterPageUrl" }

Required: False
Position: 0
Accept pipeline input: False
```

### -CustomMasterPageSiteRelativeUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MasterPageServerRelativeUrl


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "MasterPageUrl" }

Required: False
Position: 0
Accept pipeline input: False
```

### -MasterPageSiteRelativeUrl


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

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)