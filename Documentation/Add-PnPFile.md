---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Add-PnPFile

## SYNOPSIS
Uploads a file to Web

## SYNTAX 

### 
```powershell
Add-PnPFile [-Path <String>]
            [-Folder <String>]
            [-FileName <String>]
            [-Stream <Stream>]
            [-Checkout [<SwitchParameter>]]
            [-CheckInComment <String>]
            [-Approve [<SwitchParameter>]]
            [-ApproveComment <String>]
            [-Publish [<SwitchParameter>]]
            [-PublishComment <String>]
            [-UseWebDav [<SwitchParameter>]]
            [-Values <Hashtable>]
            [-ContentType <ContentTypePipeBind>]
            [-Web <WebPipeBind>]
            [-Connection <SPOnlineConnection>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Add-PnPFile -Path c:\temp\company.master -Folder "_catalogs/masterpage"
```

This will upload the file company.master to the masterpage catalog

### ------------------EXAMPLE 2------------------
```powershell
PS:> Add-PnPFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test"
```

This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder does not exist it will create it.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Add-PnPFile -Path .\sample.doc -Folder "Shared Documents" -Values @{Modified="1/1/2016"}
```

This will upload the file sample.doc to the Shared Documnets folder. After uploading it will set the Modified date to 1/1/2016.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Add-PnPFile -FileName sample.doc -Folder "Shared Documents" -Stream $fileStream -Values @{Modified="1/1/2016"}
```

This will add a file sample.doc with the contents of the stream into the Shared Documents folder. After adding it will set the Modified date to 1/1/2016.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Add-PnPFile -FileName sample.doc -Folder "Shared Documents" -ContentType "Document" -Values @{Modified="1/1/2016"}
```

This will add a file sample.doc to the Shared Documents folder, with a ContentType of 'Documents'. After adding it will set the Modified date to 1/1/2016.

### ------------------EXAMPLE 6------------------
```powershell
PS:> Add-PnPFile -FileName sample.docx -Folder "Documents" -Values @{Modified="1/1/2016"; Created="1/1/2017"; Editor=23}
```

This will add a file sample.docx to the Documents folder and will set the Modified date to 1/1/2016, Created date to 1/1/2017 and the Modified By field to the user with ID 23. To find out about the proper user ID to relate to a specific user, use Get-PnPUser.

## PARAMETERS

### -Approve


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ApproveComment


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CheckInComment


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Checkout


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ContentType


```yaml
Type: ContentTypePipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -FileName


```yaml
Type: String
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

### -Path


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Publish


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -PublishComment


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Stream


```yaml
Type: Stream
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UseWebDav


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Values


```yaml
Type: Hashtable
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