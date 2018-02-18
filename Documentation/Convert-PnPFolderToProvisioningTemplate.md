---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Convert-PnPFolderToProvisioningTemplate

## SYNOPSIS
Creates a pnp package file of an existing template xml, and includes all files in the current folder

## SYNTAX 

### 
```powershell
Convert-PnPFolderToProvisioningTemplate [-Out <String>]
                                        [-Folder <String>]
                                        [-Force [<SwitchParameter>]]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Convert-PnPFolderToProvisioningTemplate -Out template.pnp
```

Creates a pnp package file of an existing template xml, and includes all files in the current folder

### ------------------EXAMPLE 2------------------
```powershell
PS:> Convert-PnPFolderToProvisioningTemplate -Out template.pnp -Folder c:\temp
```

Creates a pnp package file of an existing template xml, and includes all files in the c:\temp folder

## PARAMETERS

### -Folder


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

### -Out


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)