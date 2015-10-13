#Get-SPOProperty
<<<<<<< HEAD
*Topic automatically generated on: 2015-10-13*
=======
*Topic automatically generated on: 2015-10-02*
>>>>>>> 1b71760d2a6302aa1f33f204a6a39ecc5daaa873

Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
Will populate properties of an object and optionally, if needed, load the value from the server. If one property is specified its value will be returned to the output.
##Syntax
```powershell
Get-SPOProperty -ClientObject <ClientObject> -Property <String[]>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ClientObject|ClientObject|True||
|Property|String[]|True|The properties to load. If one property is specified its value will be returned to the output.|
##Examples

###Example 1
```powershell

PS:> $web = Get-SPOWeb
PS:> Get-SPOProperty -ClientObject $web -Property Id, Lists
PS:> $web.Lists
```
Will load both the Id and Lists properties of the specified Web object.

###Example 2
```powershell

PS:> $list = Get-SPOList -Identity 'Site Assets'
PS:> Get-SPOProperty -ClientObject $list -Property Views
```
Will load the views object of the specified list object and return its value to the output.
