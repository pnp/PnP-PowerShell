---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPJavaScriptLink

## SYNOPSIS
Removes a JavaScript link or block from a web or sitecollection

## SYNTAX 

### 
```powershell
Remove-PnPJavaScriptLink [-Identity <UserCustomActionPipeBind>]
                         [-Force [<SwitchParameter>]]
                         [-Scope <CustomActionScope>]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPJavaScriptLink -Identity jQuery
```

Removes the injected JavaScript file with the name jQuery from the current web after confirmation

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPJavaScriptLink -Identity jQuery -Scope Site
```

Removes the injected JavaScript file with the name jQuery from the current site collection after confirmation

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPJavaScriptLink -Identity jQuery -Scope Site -Confirm:$false
```

Removes the injected JavaScript file with the name jQuery from the current site collection and will not ask for confirmation

### ------------------EXAMPLE 4------------------
```powershell
PS:> Remove-PnPJavaScriptLink -Scope Site
```

Removes all the injected JavaScript files from the current site collection after confirmation for each of them

### ------------------EXAMPLE 5------------------
```powershell
PS:> Remove-PnPJavaScriptLink -Identity faea0ce2-f0c2-4d45-a4dc-73898f3c2f2e -Scope All
```

Removes the injected JavaScript file with id faea0ce2-f0c2-4d45-a4dc-73898f3c2f2e from both the Web and Site scopes

### ------------------EXAMPLE 6------------------
```powershell
PS:> Get-PnPJavaScriptLink -Scope All | ? Sequence -gt 1000 | Remove-PnPJavaScriptLink
```

Removes all the injected JavaScript files from both the Web and Site scope that have a sequence number higher than 1000

## PARAMETERS

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Identity


```yaml
Type: UserCustomActionPipeBind
Parameter Sets: 
Aliases: new String[2] { "Key", "Name" }

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