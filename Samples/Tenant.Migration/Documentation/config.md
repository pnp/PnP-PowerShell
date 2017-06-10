# Configuring the solution
After completing the [installation process](../readme.md) the config.xml will need to be configured. This document describes the syntax of the config.xml

The config.xml is used by the [scripts](scripts.md) to export and import sites

A typical example of a config.xml would look like this:

```
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<Configurations xmlns="https://www.triad.com"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xsi:schemaLocation="config.xsd">
  <Configuration>
    <Settings>
      <PnPRelease>2017\March\SharePointPnPPowerShellOnline</PnPRelease>
    </Settings>

    <Environments>

      <Environment Name="Dev" Tenant="https://mydevtenant.sharepoint.com" Site="" Username="admin@mydevtenant.onmicrosoft.com" Password="">
        <Sites>        
          <Site Name="Intranet Site Collection" Url="">           
            <Webs>
              <Web Name="Home Site - Staff Page" Url="" Template="HomeStaffPage" Location="HomeStaffPage" Import="False" Export="True" Handler="PageContent" PageUrl="SitePages/Staff.aspx" />
        
              <Web Name="Home Site" Url="" Template="Home" Location="Home" Import="False" Export="True">
                <Artefacts>
                  <Artefact Name="DisplayTemplates" Url="/_catalogs/masterpage/Display Templates/Search/Triad" Import="False" Export="True" />    
                  </Artefacts>
                <Lists>
                  <List Name="My test List" Url ="Lists//My%20Test%20List" Create="false" IncludeData="true" />
                </Lists>
              </Web>              
            </Webs>
          </Site>

          <Site Name="External Site Collection" Url="/sites/templa">
            <Webs>
                <Web Name="External Site" Url="" Template="External" Location="External" Import="False" Export="True" />               </Webs>
          </Site>
          
        </Sites>
      </Environment>

      <Environment Name="Uat" Tenant="https://myuattenant.sharepoint.com" Site="" Username="admin@myuattenant.onmicrosoft.com" Password="">
        <Sites>
          <Site Name="Intranet Site Collection" Url="">
            <Webs>
              <Web Name="Home Site - Staff Page" Url="" Template="HomeStaffPage" Location="HomeStaffPage" Import="True" Export="False" Handler="PageContent" PageUrl="SitePages/Staff.aspx">
              </Web>
              <Web Name="Home Site" Url="" Template="Home" Location="Home" Import="True" Export="False" >
              	<WorkArounds>
                  <WorkAround Name="Lookup lists" Timing="Pre-Apply">
                    <Lists>
                      <List Name="Supplier Companies" Url="Lists/Companies" Template="GenericList" Create="true" />
                      <List Name="Supplier Offices" Url="Lists/Offices" Template="GenericList" Create="true" />
                      <List CreateList="True"  Name="MyExternalList" Url="Lists/MyExternalList" Description="" Template="ExternalList">
                        <DataSource Entity="MyExternalEntity" NameSpace="MyExternalNameSpace" LobSystemInstance="MyLobSystem" SpecificReader="ReadSpecificEntities" />
                      </List>
                    </Lists>
                  <WorkAround>
                  <WorkAround Name="Features" Timing="Post-Apply">
                    <Features>
                      <Feature Name="MDS" Enable="false" FeatureId="87294C72-F260-42f3-A41B-981A2FFCE37A" />
                      <Feature Name="PushNotification" Enable="true" FeatureId="41e1d4bf-b1a2-47f7-ab80-d5d6cbba3092" />
                    </Features>
                  </WorkAround>
                 </WorkArounds>
              </Web
            </Webs>
          </Site>
          
          
          <Site Name="External Site Collection" Url="/sites/templa">
            <Webs>
                <Web Name="External Site" Url="" Template="External" Location="External" Import="True" Export="False" />               </Webs>
          </Site>
          
        </Sites>
      </Environment>
                  
    </Environments>
  </Configuration>
</Configurations>

```




The structure of the xml is as follows:

## Configurations

### Example
```
<Configurations xmlns="https://www.triad.com"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xsi:schemaLocation="config.xsd">
    ...
</Configurations>
```

### Child Elements
Configurations can contains multiple [Configuration](#configuration) Elements

## <a name="configuration"></a>Configuration

### Example
```
<Configuration>
    ...
</Configuration>
```

### Child Elements

Configuration needs to contain a single [Settings](#settings) and a single [Environments](#elements) element.

## <a name="settings"></a>Settings

### Example
```
<Settings>
    ...
</Settings>
```
### Child Elements


## <a name="environments"></a>PnPRelease

PnPRelease contains the location of the PnP PowerShell Module. This section of the config.xml can be used to specify which version of PnP PowerShell should be used making it easy to swithc between different versions of PnP PowerShell.

### Example
```
<PnPRelease>2017\MarchFixes\SharePointPnPPowerShellOnline</PnPRelease>
```


### Child Elements

Settings needs to contain PnPRelease

## <a name="environments"></a>Environments
Multiple environment can be configured within the Environments section of the config.xml. Typically one enviuronmnet for Dev, test and Production could be configured

### Example
```
<Environments>
    ...
</Environments>
```

### Child Elements

Environments can contain one or more [Environment](#environment) elements

## <a name="environment"></a>Environment

### Example
```
 <Environment Name="Dev" Tenant="https://mydevtenant.sharepoint.com" Site="" Username="admin@mydevtenant.onmicrosoft.com" Password="">
```

### Child Elements

Environments needs to contain one [Sites](#sites) element


## <a name="sites"></a>Sites

### Example
```
<Sites>
    ...
</Sites>
```

### Child Elements

Sites can contain one or more [Site](#site) elements

## <a name="site"></a>Site

### Example
```
<Site Name="Intranet Site Collection" Url="">     
```

### Child Elements

Site needs to contain one [Webs](#webs) element


## <a name="webs"></a>Webs

### Example
```
<Webs>
    ...
</Webs>
```

### Child Elements

Webs can contain one or more [Web](#web) element

## <a name="web"></a>Web

### Example 1

To export just a single page the following exmaple can be used. The PageUrl and Handler attributes ensure that only a page is exported. Note that during the export process the Welcome page is briefly set to the exported page. After the export the welcome page is set to its original value.

``` 
<Web Name="Home Site - Staff Page" Url="" Template="HomeStaffPage" Location="HomeStaffPage" Import="False" Export="True" Handler="PageContent" PageUrl="SitePages/Staff.aspx" />
```

### Example 2
To export a full library's content or a fodler within a library the Artefacts can be configured as shown below:

```       
<Web Name="Home Site" Url="" Template="Home" Location="Home" Import="False" Export="True">
	<Artefacts>
   		<Artefact Name="DisplayTemplates" Url="/_catalogs/masterpage/Display Templates/Search/Triad" Import="False" Export="True" />    
	</Artefacts>
    <Lists>
    	<List Name="My test List" Url ="Lists/My%20Test%20List" Create="false" IncludeData="true" />
   	</Lists>
</Web>   
```

### Attributes

The Web element has the folowing Attributes:

|Attribute|Description|
|---------|-----------|
|Name|The name of the site.|
|Url|The Url of the site relative to the site collection. Leave this blank for the root site|
|Template|the name of the template.|
|Location|the location within the Tmeplates folder used to store all files releated to the template|
|Import|Is this site used for import purposes. this is typically set to true for non development sites only|
|Export|Is this site used for import purposes. this is typically set to true for development sites only|


### Child Elements

Web can contain [Artefacts](#artefacts) and/or [WorkArounds](#workarounds) elements

## <a name="artefacts"></a>Artefacts

### Example
```
<Artefacts>
    ...
</Artefacts>
```

### Child Elements
Artefacts can contain one or more [Artefact](#artefact) element


## <a name="artefact"></a>Artefact

### Example
```
<Artefact Name="DisplayTemplates" Url="/_catalogs/masterpage/Display Templates/Search/Triad" Import="False" Export="True" /> 
```

### Child Elements
Artefact does not have any child elements


## <a name="workarounds"></a>WorkArounds

### Example
```
<WorkArounds>
    ...
</WorkArounds>
```

### Child Elements


## <a name="workaround"></a>WorkAround

### Example
```
<WorkAround>
    ...
</WorkAround>
```

### Child Elements
Workaround can contain one [Lists](#lists) and/or one [Features](#features) elements


## <a name="lists"></a>Lists

### Example
```
<Lists>
    ...
</Lists>
```

### Child Elements

## <a name="list"></a>List

### Example 1
```
 <List Name="My test List" Url ="Lists/MyTestList" Create="false" IncludeData="true" />
```

### Example 2
```
<List CreateList="True"  Name="MyExternalList" Url="Lists/MyExternalList" Description="" Template="ExternalList">
   <DataSource Entity="MyExternalEntity" NameSpace="MyExternalNameSpace" LobSystemInstance="MyLobSystem" SpecificReader="ReadSpecificEntities" />
</List>
```

### Attributes

The List element has the folowing Attributes:

|Attribute|Description|
|---------|-----------|
|Name|The name of the list.|
|Url|The Url of the list|
|Create|Values are true or false. This could be set to false if workarounds need to be applied to a list without there being a need to create the list itself|
|IncludeData|Does the data of the list need to be included. currently only simple text fields are supported. During the export of templates datarows can be included in the template generated by PnP PowerShell Cmdlets|
|Template|The template to be used to create the list|



## <a name="features"></a>Features

### Example
```
<Features>
    ...
</Features>
```

### Child Elements

## <a name="feature"></a>Feature

### Example
```
	<Feature Name="PushNotification" Enable="true" FeatureId="41e1d4bf-b1a2-47f7-ab80-d5d6cbba3092" />
```
### Attributes

The Datasource element has the folowing Attributes:

|Attribute|Description|
|---------|-----------|
|Name|The name of the feature. This is only used as a comment to improve the readability of the xml|
|Enable|Values are true or false, to enable or disable the features|
|FeatureId|The feature id of the feature that needs to be enabled or disabled|


### Child Elements
Feature does not have any child elements.

## <a name="datasource"></a>DataSource

### Example
```
 <DataSource Entity="MyExternalEntity" NameSpace="MyExternalNameSpace" LobSystemInstance="MyLobSystem" SpecificReader="ReadSpecificEntities" />
 
```

### Attributes

The Datasource element has the folowing Attributes:

|Attribute|Description|
|---------|-----------|
|Entity|The entity as specified in the BDC Model|
|Namespace|The name space as specified in the BDC model|
|LobSystemInstance|The lob system as specified in the BDC model|
|SpecificReader|The specific reader as specified in the BDC model|


### Child Elements
DataSource does not have any child elements.







