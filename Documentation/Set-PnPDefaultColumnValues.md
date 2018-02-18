---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Set-PnPDefaultColumnValues

## SYNOPSIS
Sets default column values for a document library

## SYNTAX 

### 
```powershell
Set-PnPDefaultColumnValues [-List <ListPipeBind>]
                           [-Field <FieldPipeBind>]
                           [-Value <String[]>]
                           [-Folder <String>]
                           [-Web <WebPipeBind>]
                           [-Connection <SPOnlineConnection>]
```

## DESCRIPTION
Sets default column values for a document library, per folder, or for the root folder if the folder parameter has not been specified. Supports both text and taxonomy fields.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Set-PnPDefaultColumnValues -List Documents -Field TaxKeyword -Value "Company|Locations|Stockholm"
```

Sets a default value for the enterprise keywords field on a library to a term called "Stockholm", located in the "Locations" term set, which is part of the "Company" term group

### ------------------EXAMPLE 2------------------
```powershell
PS:> Set-PnPDefaultColumnValues -List Documents -Field TaxKeyword -Value "15c4c4e4-4b67-4894-a1d8-de5ff811c791"
```

Sets a default value for the enterprise keywords field on a library to a term with the id "15c4c4e4-4b67-4894-a1d8-de5ff811c791". You need to ensure the term is valid for the field.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Set-PnPDefaultColumnValues -List Documents -Field MyTextField -Value "DefaultValue"
```

Sets a default value for the MyTextField text field on a library to a value of "DefaultValue"

### ------------------EXAMPLE 4------------------
```powershell
PS:> Set-PnPDefaultColumnValues -List Documents -Field MyPeopleField -Value "1;#Foo Bar"
```

Sets a default value for the MyPeopleField people field on a library to a value of "Foo Bar" using the id from the user information list.

### ------------------EXAMPLE 5------------------
```powershell
PS:> $user = New-PnPUser -LoginName foobar@contoso.com
PS:> Set-PnPDefaultColumnValues -List Documents -Field MyPeopleField -Value "$($user.Id);#$($user.LoginName)"
```

Sets a default value for the MyPeopleField people field on a library to a value of "Foo Bar" using the id from the user information list.

### ------------------EXAMPLE 6------------------
```powershell
PS:> $user1 = New-PnPUser -LoginName user1@contoso.com
PS:> $user2 = New-PnPUser -LoginName user2@contoso.com
PS:> Set-PnPDefaultColumnValues -List Documents -Field MyMultiPeopleField -Value "$($user1.Id);#$($user1.LoginName)","$($user2.Id);#$($user2.LoginName)"
```

Sets a default value for the MyMultiPeopleField people field on a library to a value of "User 1" and "User 2" using the id from the user information list.

## PARAMETERS

### -Field


```yaml
Type: FieldPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Folder


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -List


```yaml
Type: ListPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Value


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