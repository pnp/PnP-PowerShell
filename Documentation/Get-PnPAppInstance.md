---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPAppInstance

## SYNOPSIS
Returns a SharePoint AddIn Instance

## SYNTAX 

### 
```powershell
Get-PnPAppInstance [-Identity <AppPipeBind>]
                   [-Web <WebPipeBind>]
                   [-Includes <String[]>]
                   [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Returns a SharePoint App/Addin that has been installed in the current site

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPAppInstance
```

This will return all addin instances in the site.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPAppInstance -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe
```

This will return an addin instance with the specified id.

## PARAMETERS

### -Identity


```yaml
Type: AppPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Includes
Specify properties to include when retrieving objects from the server.

```yaml
Type: String[]
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

### [List<Microsoft.SharePoint.Client.AppInstance>](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.appinstance.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)