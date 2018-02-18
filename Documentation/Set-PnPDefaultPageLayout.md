---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPDefaultPageLayout

## SYNOPSIS
Sets a specific page layout to be the default page layout for a publishing site

## SYNTAX 

### 
```powershell
Set-PnPDefaultPageLayout [-Title <String>]
                         [-InheritFromParentSite [<SwitchParameter>]]
                         [-Web <WebPipeBind>]
                         [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPDefaultPageLayout -Title projectpage.aspx
```

Sets projectpage.aspx to be the default page layout for the current web

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPDefaultPageLayout -Title test/testpage.aspx
```

Sets a page layout in a folder in the Master Page & Page Layout gallery, such as _catalog/masterpage/test/testpage.aspx, to be the default page layout for the current web

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPDefaultPageLayout -InheritFromParentSite
```

Sets the default page layout to be inherited from the parent site

## PARAMETERS

### -InheritFromParentSite


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Title


```yaml
Type: String
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