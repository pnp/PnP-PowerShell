---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPListFoldersToProvisioningTemplate

## SYNOPSIS
Adds folders to a list in a PnP Provisioning Template

## SYNTAX 

### 
```powershell
Add-PnPListFoldersToProvisioningTemplate [-Path <String>]
                                         [-List <ListPipeBind>]
                                         [-Recursive [<SwitchParameter>]]
                                         [-IncludeSecurity [<SwitchParameter>]]
                                         [-TemplateProviderExtensions <ITemplateProviderExtension[]>]
                                         [-Web <WebPipeBind>]
                                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList'
```

Adds top level folders from a list to an existing template and returns an in-memory PnP Provisioning Template

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Recursive
```

Adds all folders from a list to an existing template and returns an in-memory PnP Provisioning Template

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPListFoldersToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Recursive -IncludeSecurity
```

Adds all folders from a list with unique permissions to an in-memory PnP Provisioning Template

## PARAMETERS

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

### -Recursive


```yaml
Type: SwitchParameter
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