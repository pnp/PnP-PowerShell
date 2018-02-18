---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPDataRowsToProvisioningTemplate

## SYNOPSIS
Adds datarows to a list inside a PnP Provisioning Template

## SYNTAX 

### 
```powershell
Add-PnPDataRowsToProvisioningTemplate [-Path <String>]
                                      [-List <ListPipeBind>]
                                      [-Query <String>]
                                      [-Fields <String[]>]
                                      [-IncludeSecurity [<SwitchParameter>]]
                                      [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                                      [-TokenizeUrls [<SwitchParameter>]]
                                      [-Web <WebPipeBind>]
                                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPDataRowsToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Query '<View></View>' -Fields 'Title','Choice'
```

Adds datarows to a list in an in-memory PnP Provisioning Template

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPDataRowsToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Query '<View></View>' -Fields 'Title','Choice' -IncludeSecurity
```

Adds datarows to a list in an in-memory PnP Provisioning Template

## PARAMETERS

### -Fields


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IncludeSecurity


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Query


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TemplateProviderExtensions


```yaml
Type: ITemplateProviderExtension[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TokenizeUrls


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