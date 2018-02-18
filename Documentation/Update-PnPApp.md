---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# Update-PnPApp

## SYNOPSIS
Updates an available app from the app catalog

## SYNTAX 

### 
```powershell
Update-PnPApp [-Identity <AppMetadataPipeBind>]
              [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Update-PnPApp -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```

This will update an already installed app if a new version is available. Retrieve a list all available apps and the installed and available versions with Get-PnPApp

## PARAMETERS

### -Identity


```yaml
Type: AppMetadataPipeBind
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