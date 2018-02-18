---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPCustomAction

## SYNOPSIS
Adds a custom action

## SYNTAX 

### 
```powershell
Add-PnPCustomAction [-Name <String>]
                    [-Title <String>]
                    [-Description <String>]
                    [-Group <String>]
                    [-Location <String>]
                    [-Sequence <Int>]
                    [-Url <String>]
                    [-ImageUrl <String>]
                    [-CommandUIExtension <String>]
                    [-RegistrationId <String>]
                    [-Rights <PermissionKind[]>]
                    [-RegistrationType <UserCustomActionRegistrationType>]
                    [-Scope <CustomActionScope>]
                    [-ClientSideComponentId <GuidPipeBind>]
                    [-ClientSideComponentProperties <String>]
                    [-Web <WebPipeBind>]
                    [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Adds a user custom action to a web or sitecollection.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
$cUIExtn = "<CommandUIExtension><CommandUIDefinitions><CommandUIDefinition Location=""Ribbon.List.Share.Controls._children""><Button Id=""Ribbon.List.Share.GetItemsCountButton"" Alt=""Get list items count"" Sequence=""11"" Command=""Invoke_GetItemsCountButtonRequest"" LabelText=""Get Items Count"" TemplateAlias=""o1"" Image32by32=""_layouts/15/images/placeholder32x32.png"" Image16by16=""_layouts/15/images/placeholder16x16.png"" /></CommandUIDefinition></CommandUIDefinitions><CommandUIHandlers><CommandUIHandler Command=""Invoke_GetItemsCountButtonRequest"" CommandAction=""javascript: alert('Total items in this list: '+ ctx.TotalListItems);"" EnabledScript=""javascript: function checkEnable() { return (true);} checkEnable();""/></CommandUIHandlers></CommandUIExtension>"

Add-PnPCustomAction -Name 'GetItemsCount' -Title 'Invoke GetItemsCount Action' -Description 'Adds custom action to custom list ribbon' -Group 'SiteActions' -Location 'CommandUI.Ribbon' -CommandUIExtension $cUIExtn
```

Adds a new custom action to the custom list template, and sets the Title, Name and other fields with the specified values. On click it shows the number of items in that list. Notice: escape quotes in CommandUIExtension.

## PARAMETERS

### -ClientSideComponentId


```yaml
Type: GuidPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ClientSideComponentProperties


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CommandUIExtension


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Group


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ImageUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Location


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Name


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RegistrationId


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RegistrationType


```yaml
Type: UserCustomActionRegistrationType
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Rights


```yaml
Type: PermissionKind[]
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

### -Sequence


```yaml
Type: Int
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

### -Url


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

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)[UserCustomAction](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.usercustomaction.aspx)[BasePermissions](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.client.basepermissions.aspx)