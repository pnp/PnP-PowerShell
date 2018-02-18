---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Find-PnPFile

## SYNOPSIS
Finds a file in the virtual file system of the web.

## SYNTAX 

### 
```powershell
Find-PnPFile [-Match <String>]
             [-List <ListPipeBind>]
             [-Folder <FolderPipeBind>]
             [-Web <WebPipeBind>]
             [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Find-PnPFile -Match *.master
```

Will return all masterpages located in the current web.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Find-PnPFile -List "Documents" -Match *.pdf
```

Will return all pdf files located in given list.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Find-PnPFile -Folder "Shared Documents/Sub Folder" -Match *.docx
```

Will return all docx files located in given folder.

## PARAMETERS

### -Folder


```yaml
Type: FolderPipeBind
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

### -Match


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

## OUTPUTS

### [Microsoft.SharePoint.Client.File](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.file.aspx)

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)