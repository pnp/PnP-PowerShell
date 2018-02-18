---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Ensure-PnPFolder

## SYNOPSIS
Returns a folder from a given site relative path, and will create it if it does not exist.

## SYNTAX 

### 
```powershell
Ensure-PnPFolder [-SiteRelativePath <String>]
                 [-Web <WebPipeBind>]
                 [-Includes <String[]>]
                 [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
If you do not want the folder to be created, for instance just to test if a folder exists, check Get-PnPFolder

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Ensure-PnPFolder -SiteRelativePath "demofolder/subfolder"
```

Creates a folder called subfolder in a folder called demofolder located in the root folder of the site. If the folder hierarchy does not exist, it will be created.

## PARAMETERS

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SiteRelativePath


```yaml
Type: String
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

### -Connection


```yaml
Type: SPOnlineConnection
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## OUTPUTS

### [Microsoft.SharePoint.Client.Folder](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.folder.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Get-PnPFolder](https://github.com/OfficeDev/PnP-PowerShell/blob/master/Documentation/GetPnPFolder.md)