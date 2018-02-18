---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPFolder

## SYNOPSIS
Return a folder object

## SYNTAX 

### 
```powershell
Get-PnPFolder [-Url <String>]
              [-Web <WebPipeBind>]
              [-Includes <String[]>]
              [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Retrieves a folder if it exists. Use Ensure-PnPFolder to create the folder if it does not exist.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPFolder -RelativeUrl "Shared Documents"
```

Returns the folder called 'Shared Documents' which is located in the root of the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPFolder -RelativeUrl "/sites/demo/Shared Documents"
```

Returns the folder called 'Shared Documents' which is located in the root of the current web

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

### -Url


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "RelativeUrl" }

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

### [Microsoft.SharePoint.Client.Folder](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.file.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[Ensure-PnPFolder](https://github.com/OfficeDev/PnP-PowerShell/blob/master/Documentation/EnsureSPOFolder.md)