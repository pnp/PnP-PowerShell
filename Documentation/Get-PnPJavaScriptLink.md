---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Get-PnPJavaScriptLink

## SYNOPSIS
Returns all or a specific custom action(s) with location type ScriptLink

## SYNTAX 

### 
```powershell
Get-PnPJavaScriptLink [-Name <String>]
                      [-Scope <CustomActionScope>]
                      [-ThrowExceptionIfJavaScriptLinkNotFound [<SwitchParameter>]]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Get-PnPJavaScriptLink
```

Returns all web scoped JavaScript links

### ------------------EXAMPLE 2------------------
```powershell
PS:> Get-PnPJavaScriptLink -Scope All
```

Returns all web and site scoped JavaScript links

### ------------------EXAMPLE 3------------------
```powershell
PS:> Get-PnPJavaScriptLink -Scope Web
```

Returns all Web scoped JavaScript links

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPJavaScriptLink -Scope Site
```

Returns all Site scoped JavaScript links

### ------------------EXAMPLE 5------------------
```powershell
PS:> Get-PnPJavaScriptLink -Name Test
```

Returns the web scoped JavaScript link named Test

## PARAMETERS

### -Name


```yaml
Type: String
Parameter Sets: 
Aliases: new String[1] { "Key" }

Required: False
Position: 0
Accept pipeline input: False
```

### -Scope


```yaml
Type: CustomActionScope
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ThrowExceptionIfJavaScriptLinkNotFound


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

## OUTPUTS

### [Microsoft.SharePoint.Client.UserCustomAction](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.usercustomaction.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)