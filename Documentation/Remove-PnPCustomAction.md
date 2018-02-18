---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Remove-PnPCustomAction

## SYNOPSIS
Removes a custom action

## SYNTAX 

### 
```powershell
Remove-PnPCustomAction [-Identity <UserCustomActionPipeBind>]
                       [-Scope <CustomActionScope>]
                       [-Force [<SwitchParameter>]]
                       [-Web <WebPipeBind>]
                       [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Remove-PnPCustomAction -Identity aa66f67e-46c0-4474-8a82-42bf467d07f2
```

Removes the custom action with the id 'aa66f67e-46c0-4474-8a82-42bf467d07f2'.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Remove-PnPCustomAction -Identity aa66f67e-46c0-4474-8a82-42bf467d07f2 -Scope web
```

Removes the custom action with the id 'aa66f67e-46c0-4474-8a82-42bf467d07f2' from the current web.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Remove-PnPCustomAction -Identity aa66f67e-46c0-4474-8a82-42bf467d07f2 -Force
```

Removes the custom action with the id 'aa66f67e-46c0-4474-8a82-42bf467d07f2' without asking for confirmation.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Get-PnPCustomAction -Scope All | ? Location -eq ScriptLink | Remove-PnPCustomAction
```

Removes all custom actions that are ScriptLinks

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