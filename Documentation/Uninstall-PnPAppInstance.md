---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Uninstall-PnPAppInstance

## SYNOPSIS
Removes an app from a site

## SYNTAX 

### 
```powershell
Uninstall-PnPAppInstance [-Identity <AppPipeBind>]
                         [-Force [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Removes an add-in/app that has been installed to a site.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Uninstall-PnPAppInstance -Identity $appinstance
```

Uninstalls the app instance which was retrieved with the command Get-PnPAppInstance

### ------------------EXAMPLE 2------------------
```powershell
PS:> Uninstall-PnPAppInstance -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```

Uninstalls the app instance with the ID '99a00f6e-fb81-4dc7-8eac-e09c6f9132fe'

### ------------------EXAMPLE 3------------------
```powershell
PS:> Uninstall-PnPAppInstance -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -force
```

Uninstalls the app instance with the ID '99a00f6e-fb81-4dc7-8eac-e09c6f9132fe' and do not ask for confirmation

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: AppPipeBind
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