#Invoke-SPOWebAction
Executes operations on web, lists, list items.
##Syntax
```powershell
Invoke-SPOWebAction [-Webs <Web[]>] [-WebAction <Action`1>] [-ShouldProcessWebAction <Func`2>] [-PostWebAction <Action`1>] [-ShouldProcessPostWebAction <Func`2>] [-WebProperties <String[]>] [-ListAction <Action`1>] [-ShouldProcessListAction <Func`2>] [-PostListAction <Action`1>] [-ShouldProcessPostListAction <Func`2>] [-ListProperties <String[]>] [-ListItemAction <Action`1>] [-ShouldProcessListItemAction <Func`2>] [-ListItemProperties <String[]>] [-SubWebs [<SwitchParameter>]] [-DisableStatisticsOutput [<SwitchParameter>]] [-SkipCounting [<SwitchParameter>]] [-Web <WebPipeBind>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|DisableStatisticsOutput|SwitchParameter|False|Will not output statistics after the operation|
|ListAction|Action`1|False|Function to be exectued on the list. There is one input parameter of type List|
|ListItemAction|Action`1|False|Function to be exectued on the list item. There is one input parameter of type ListItem|
|ListItemProperties|String[]|False|The properties to load for list items.|
|ListProperties|String[]|False|The properties to load for list.|
|PostListAction|Action`1|False|Function to be exectued on the list, this will trigger after list items have been proccesse. There is one input parameter of type List|
|PostWebAction|Action`1|False|Function to be exectued on the web, this will trigger after lists and list items have been proccessed. There is one input parameter of type Web|
|ShouldProcessListAction|Func`2|False|Function to be executed on the web that would decide if ListAction should be invoked, There is one input parameter of type List and the function should return a bool value|
|ShouldProcessListItemAction|Func`2|False|Function to be executed on the web that would decide if ListItemAction should be invoked, There is one input parameter of type ListItem and the function should return a bool value|
|ShouldProcessPostListAction|Func`2|False|Function to be executed on the web that would decide if PostListAction should be invoked, There is one input parameter of type List and the function should return a bool value|
|ShouldProcessPostWebAction|Func`2|False|Function to be executed on the web that would decide if PostWebAction should be invoked, There is one input parameter of type Web and the function should return a bool value|
|ShouldProcessWebAction|Func`2|False|Function to be executed on the web that would decide if WebAction should be invoked, There is one input parameter of type Web and the function should return a bool value|
|SkipCounting|SwitchParameter|False|Will skip the counting process, by doing this you will not get an estimated time remaining|
|SubWebs|SwitchParameter|False|Specify if sub webs will be processed|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
|WebAction|Action`1|False|Function to be exectued on the web. There is one input parameter of type Web|
|WebProperties|String[]|False|The properties to load for web.|
|Webs|Web[]|False|Webs you want to process (for example diffrent site collections), will use Web parameter if not specified|
##Examples

###Example 1
```powershell
PS:> Invoke-SPOWebAction -ListAction ${function:ListAction}
```
This will call the function ListAction on all the lists located on the current web.

###Example 2
```powershell
PS:> Invoke-SPOWebAction -ShouldProcessListAction ${function:ShouldProcessList} -ListAction ${function:ListAction}
```
This will call the function ShouldProcessList, if it returns true the function ListAction will then be called. This will occur on all lists located on the current web
