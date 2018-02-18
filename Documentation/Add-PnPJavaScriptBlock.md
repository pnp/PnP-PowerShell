---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPJavaScriptBlock

## SYNOPSIS
Adds a link to a JavaScript snippet/block to a web or site collection

## SYNTAX 

### 
```powershell
Add-PnPJavaScriptBlock [-Name <String>]
                       [-Script <String>]
                       [-Sequence <Int>]
                       [-Scope <CustomActionScope>]
                       [-Web <WebPipeBind>]
                       [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Specify a scope as 'Site' to add the custom action to all sites in a site collection.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPJavaScriptBlock -Name myAction -script '<script>Alert("This is my Script block");</script>' -Sequence 9999 -Scope Site
```

Add a JavaScript code block  to all pages within the current site collection under the name myAction and at order 9999

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPJavaScriptBlock -Name myAction -script '<script>Alert("This is my Script block");</script>'
```

Add a JavaScript code block  to all pages within the current web under the name myAction

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

### -Script


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Sequence


```yaml
Type: Int
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