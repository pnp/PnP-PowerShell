---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPJavaScriptLink

## SYNOPSIS
Adds a link to a JavaScript file to a web or sitecollection

## SYNTAX 

### 
```powershell
Add-PnPJavaScriptLink [-Name <String>]
                      [-Url <String[]>]
                      [-Sequence <Int>]
                      [-Scope <CustomActionScope>]
                      [-Web <WebPipeBind>]
                      [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Creates a custom action that refers to a JavaScript file

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPJavaScriptLink -Name jQuery -Url https://code.jquery.com/jquery.min.js -Sequence 9999 -Scope Site
```

Injects a reference to the latest v1 series jQuery library to all pages within the current site collection under the name jQuery and at order 9999

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPJavaScriptLink -Name jQuery -Url https://code.jquery.com/jquery.min.js
```

Injects a reference to the latest v1 series jQuery library to all pages within the current web under the name jQuery

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

### -Sequence


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: String[]
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