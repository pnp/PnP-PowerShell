---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPJavaScriptLink

## SYNOPSIS
Removes a JavaScript link or block from a web or sitecollection

## SYNTAX 

```powershell
Remove-PnPJavaScriptLink [-Force [<SwitchParameter>]]
                         [-Scope <CustomActionScope>]
                         [-Identity <UserCustomActionPipeBind>]
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
Use the -Force flag to bypass the confirmation question

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Identity
Name or id of the JavaScriptLink to remove. Omit if you want to remove all JavaScript Links.

```yaml
Type: UserCustomActionPipeBind
Parameter Sets: (All)
Aliases: Key,Name

Required: False
Position: 0
Accept pipeline input: True
```

### -Scope
Define if the JavaScriptLink is to be found at the web or site collection scope. Specify All to allow deletion from either web or site collection.

```yaml
Type: CustomActionScope
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Connection
Optional connection to be used by cmdlet. Retrieve the value for this parameter by eiter specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: SPOnlineConnection
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

### -Web
This parameter allows you to optionally apply the cmdlet action to a subweb within the current web. In most situations this parameter is not required and you can connect to the subweb using Connect-PnPOnline instead. Specify the GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)