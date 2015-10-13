#Add-SPOFile
<<<<<<< HEAD
*Topic automatically generated on: 2015-10-13*
=======
*Topic automatically generated on: 2015-10-02*
>>>>>>> 1b71760d2a6302aa1f33f204a6a39ecc5daaa873

Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
Uploads a file to Web
##Syntax
```powershell
Add-SPOFile -Path <String> -Folder <String> [-Checkout [<SwitchParameter>]] [-Approve [<SwitchParameter>]] [-ApproveComment <String>] [-Publish [<SwitchParameter>]] [-PublishComment <String>] [-UseWebDav [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|Approve|SwitchParameter|False|Will auto approve the uploaded file.|
|ApproveComment|String|False|The comment added to the approval.|
|Checkout|SwitchParameter|False|If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.|
|Folder|String|True|The destination folder in the site|
|Path|String|True|The local file path.|
|Publish|SwitchParameter|False|Will auto publish the file.|
|PublishComment|String|False|The comment added to the publish action.|
|UseWebDav|SwitchParameter|False||
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
PS:> Add-SPOFile -Path c:\temp\company.master -Folder "_catalogs/masterpage
```
This will upload the file company.master to the masterpage catalog

###Example 2
```powershell
PS:> Add-SPOFile -Path .\displaytemplate.html -Folder "_catalogs/masterpage/display templates/test
```
This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder not exists it will create it.
