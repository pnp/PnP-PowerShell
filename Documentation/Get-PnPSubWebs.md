---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPSubWebs

## SYNOPSIS
Returns the subwebs of the current web

## SYNTAX 

### 
```powershell
Get-PnPSubWebs [-Identity <WebPipeBind>]
               [-Recurse [<SwitchParameter>]]
               [-Web <WebPipeBind>]
               [-Includes <String[]>]
               [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPSubWebs
```

Retrieves all subsites of the current context returning the Id, Url, Title and ServerRelativeUrl of each subsite in the output

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPSubWebs -Recurse
```

Retrieves all subsites of the current context and all of their nested child subsites returning the Id, Url, Title and ServerRelativeUrl of each subsite in the output

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPSubWebs -Recurse -Includes "WebTemplate","Description" | Select ServerRelativeUrl, WebTemplate, Description
```

Retrieves all subsites of the current context and shows the ServerRelativeUrl, WebTemplate and Description properties in the resulting output

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPSubWebs -Identity Team1 -Recurse
```

Retrieves all subsites of the subsite Team1 and all of its nested child subsites returning the Id, Url, Title and ServerRelativeUrl of each subsite in the output

## PARAMETERS

### -Identity


```yaml
Type: WebPipeBind
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

### -Recurse


```yaml
Type: SwitchParameter
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

### [Microsoft.SharePoint.Client.Web](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.web.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)