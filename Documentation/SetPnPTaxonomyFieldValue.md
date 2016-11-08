#Set-PnPTaxonomyFieldValue
Sets a taxonomy term value in a listitem field
##Syntax
```powershell
Set-PnPTaxonomyFieldValue -TermId <GuidPipeBind>
                          [-Label <String>]
                          -ListItem <ListItem>
                          -InternalFieldName <String>
```


```powershell
Set-PnPTaxonomyFieldValue -TermPath <String>
                          -ListItem <ListItem>
                          -InternalFieldName <String>
```


##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|InternalFieldName|String|True|The internal name of the field|
|Label|String|False|The Label value of the term|
|ListItem|ListItem|True|The list item to set the field value to|
|TermId|GuidPipeBind|True|The Id of the Term|
|TermPath|String|True|A path in the form of GROUPLABEL|TERMSETLABEL|TERMLABEL|
##Examples

###Example 1
```powershell
PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermId 863b832b-6818-4e6a-966d-2d3ee057931c
```
Sets the field called 'Department' to the value of the term with the ID specified

###Example 2
```powershell
PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermPath 'CORPORATE|DEPARTMENTS|HR'
```
Sets the field called 'Department' to the term called HR which is located in the DEPARTMENTS termset, which in turn is located in the CORPORATE termgroup.
