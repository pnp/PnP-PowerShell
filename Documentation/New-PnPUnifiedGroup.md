---
external help file:
applicable: SharePoint Online
schema: 2.0.0
---
# New-PnPUnifiedGroup

## SYNOPSIS
Creates a new Office 365 Group (aka Unified Group)

## SYNTAX 

### 
```powershell
New-PnPUnifiedGroup [-DisplayName <String>]
                    [-Description <String>]
                    [-MailNickname <String>]
                    [-Owners <String[]>]
                    [-Members <String[]>]
                    [-IsPrivate [<SwitchParameter>]]
                    [-GroupLogoPath <String>]
                    [-Force [<SwitchParameter>]]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> New-PnPUnifiedGroup -DisplayName $displayName -Description $description -MailNickname $nickname
```

Creates a public Office 365 Group with all the required properties

### ------------------EXAMPLE 2------------------
```powershell
PS:> New-PnPUnifiedGroup -DisplayName $displayName -Description $description -MailNickname $nickname -Owners $arrayOfOwners -Members $arrayOfMembers
```

Creates a public Office 365 Group with all the required properties, and with a custom list of Owners and a custom list of Members

### ------------------EXAMPLE 3------------------
```powershell
PS:> New-PnPUnifiedGroup -DisplayName $displayName -Description $description -MailNickname $nickname -IsPrivate
```

Creates a private Office 365 Group with all the required properties

### ------------------EXAMPLE 4------------------
```powershell
PS:> New-PnPUnifiedGroup -DisplayName $displayName -Description $description -MailNickname $nickname -Owners $arrayOfOwners -Members $arrayOfMembers -IsPrivate
```

Creates a private Office 365 Group with all the required properties, and with a custom list of Owners and a custom list of Members

## PARAMETERS

### -Description


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DisplayName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Force


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -GroupLogoPath


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IsPrivate


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MailNickname


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Members


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Owners


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)