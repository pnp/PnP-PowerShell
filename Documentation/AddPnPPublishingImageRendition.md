#Add-PnPPublishingImageRendition
Adds an Image Rendition
##Syntax
```powershell
Add-PnPPublishingImageRendition -imageRenditionName <String>
                                -imageRenditionWidth <Int32>
                                -imageRenditionHeight <Int32>
                                [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|imageRenditionHeight|Int32|True|The height of the Image Rendition.|
|imageRenditionName|String|True|The display name of the Image Rendition.|
|imageRenditionWidth|Int32|True|The width of the Image Rendition.|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-PnPPublishingImageRendition -ImageRenditionName "MyImageRendition" -Width 800 -Height 600
```
Adds an Image Rendition.
