#Execute-SPOQuery
Executes any queued actions / changes on the SharePoint Client Side Object Model Context
##Syntax
```powershell
Execute-SPOQuery
        [-RetryCount <Int32>]
        [-RetryWait <Int32>]
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|RetryCount|Int32|False|Number to times to retry in case of throttling. Defaults to 10.|
|RetryWait|Int32|False|Delay in seconds. Defaults to 1.|
##Examples

###Example 1
```powershell
PS:> Execute-SPOQuery -RetryCount 5
```
This will execute any queued actions / changes on the SharePoint Client Side Object Model Context and will retry 5 times in case of throttling.

###Example 2
```powershell
PS:> Execute-SPOQuery -RetryWait 10
```
This will execute any queued actions / changes on the SharePoint Client Side Object Model Context and delay the execution with 10 seconds when it needs to retry the execution.
