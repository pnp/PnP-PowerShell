---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPFile

## SYNOPSIS
Downloads a file.

## SYNTAX 

### 
```powershell
Get-PnPFile [-Url <String>]
            [-Path <String>]
            [-Filename <String>]
            [-AsFile [<SwitchParameter>]]
            [-AsListItem [<SwitchParameter>]]
            [-ThrowExceptionIfFileNotFound [<SwitchParameter>]]
            [-AsString [<SwitchParameter>]]
            [-Force [<SwitchParameter>]]
            [-Web <WebPipeBind>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor
```

Retrieves the file and downloads it to the current folder

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor -AsFile
```

Retrieves the file and downloads it to c:\temp\company.spcolor

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsString
```

Retrieves the file and outputs its contents to the console

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsFile
```

Retrieves the file and returns it as a File object

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsListItem
```

Retrieves the file and returns it as a ListItem object

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPFile -Url _catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor -AsFile
```

Retrieves the file by site relative URL and downloads it to c:\temp\company.spcolor

## PARAMETERS

### -AsFile


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AsListItem


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AsString


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Filename


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

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ThrowExceptionIfFileNotFound


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: String
Parameter Sets: 
Aliases: new String[2] { "ServerRelativeUrl", "SiteRelativeUrl" }

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

## OUTPUTS

### [Microsoft.SharePoint.Client.File](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.file.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)