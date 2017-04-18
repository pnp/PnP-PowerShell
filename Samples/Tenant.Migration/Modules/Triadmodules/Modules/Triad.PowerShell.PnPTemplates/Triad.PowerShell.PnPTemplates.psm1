function Get-TMPnPTemplatesForSiteCollections
{
	<#
		.SYNOPSIS
		Get PnP Templates for all sites within a site collection.

		.DESCRIPTION
		The password is read from the configuration file. If no paassword is found then a login window will be presented to the user.

		.EXAMPLE
		Get-TMPnPTemplatesForSiteCollection -Configuration $configuration -Environment $environment

		.PARAMETER Configuration
		The Xml as a string for the configuration used. This Xml is a full copy of the config.xml

		.PARAMETER Environment
		The environment within the configuration that needs to be retrieved. e.g. "Dev" or "UAT"

	#>

	param(
        [Parameter(Mandatory=$True)]
        [string]$TemplatePath,
        
		[Parameter(Mandatory=$True)]
		[string]$Configuration,

		[Parameter(Mandatory=$True)]
		[string]$Environment
	)

	begin
	{
		[xml]$config = $Configuration
		$defaultSourceEnvironment = "Dev"
        $path = $TemplatePath
	}

	process
	{
		# Get the environment to export the solution from.
		if ($Environment -ne $null -and  $Environment -ne ""  )
		{
			$runExportsFrom = $Environment
		} else
		{
			$runExportsFrom = $defaultSourceEnvironment
		}

		# Load the PnP Module as specified in the config.xml/
		$PnPPath = $config.Configurations.Configuration.Settings.PnPRelease

		if ($env:PSModulePath -notlike "*$path\Modules\$PnPPath\Modules*")
		{
			"Adding ;$path\Modules\$PnPPath\Modules to PSModulePath" | Write-Debug
			$env:PSModulePath += ";$path\Modules\$PnPPath\Modules"
		}

		if ($env:PSModulePath -notlike "*$path\Modules\TriadModules\Modules*")
		{
			"Adding ;$path\Modules\TriadModules\Modules to PSModulePath" | Write-Debug
			$env:PSModulePath += ";$path\Modules\TriadModules\Modules"
		}

		#Reload Modules if they are loaded
		if ((Get-Module | Where {$_.Name -eq "Triad.PowerShell.Utilities"}).Count -eq 1)
		{
			Remove-Module "Triad.PowerShell.Utilities"
			Import-Module "Triad.PowerShell.Utilities"
		}

		if ((Get-Module | Where {$_.Name -eq "Triad.PowerShell.PnPTemplates"}).Count -eq 1)
		{
			Remove-Module "Triad.PowerShell.PnPTemplates"
			Import-Module "Triad.PowerShell.PnPTemplates"
		}

		"The current module path is set to :" + $env:PSModulePath | Write-Debug

		# Get the environment configuration
		[System.Xml.XmlLinkedNode]$environment = $config.Configurations.Configuration.Environments.Environment | Where { $_.Name -eq $runExportsFrom}
		"The " + $environment.Name + " environment will be exported" | Write-Debug

		[string]$environmentStr = $environment.OuterXml
		$cred = Get-TMCredential -Environment $environmentStr

		Foreach ( $siteConfig in $environment.Sites.Site)
		{
			[string]$siteConfigStr = $siteConfig.OuterXml
			Get-TMPnPTemplateForSite -TemplatePath $path -Environment $environmentStr -Site $siteConfigStr -Credentials $cred
		}
	}

	end
	{
		Write-Debug "Templates have been generated in $path\Templates\$template\$environmentName\template.xml"
	}
}

function Get-WelcomePageUrl
{
	<#

		.SYNOPSIS
		Get the Url of the welcome page for a site

		.DESCRIPTION
		Get the Url of the welcome page for a given site

		.EXAMPLE
		Get-WelcomePageUrl -Web $web

		.PARAMETER Web
		The Web to retrieve the welcome page url from

	#>

    Param(
		[Parameter(Mandatory=$True)]
		[Microsoft.SharePoint.Client.Web]$Web
	)

    $Web.Context.Load($Web.RootFolder)
    $Web.Context.ExecuteQuery();

	$WelcomePage = $Web.RootFolder.WelcomePage.ToString();

    return $WelcomePage
}

function Set-WelcomePageUrl
{
	<#
		.SYNOPSIS
		Set the Url of the welcome page for a site

		.DESCRIPTION
		Set the Url of the welcome page for a given site

		.EXAMPLE
		Set-WelcomePageUrl -Web $web

		.PARAMETER Web
		The site to set the welcome page for

		.PARAMETER WelcomePageUrl
		The welcome page url to set the web's welcome page to.

	#>

    param(
		[Parameter(Mandatory=$True)]
		[Microsoft.SharePoint.Client.Web]$Web,

		[Parameter(Mandatory=$True)]
        [string] $WelcomePageUrl
	)

	$web.RootFolder.WelcomePage = $WelcomePageUrl
    $web.RootFolder.Update()
    $web.Context.ExecuteQuery();
}

function Get-TMPnPTemplateForSite
{
	<#

		.SYNOPSIS
		Get a PnP Template and other artefacts for a single site.

		.DESCRIPTION
		Get a PnP Template and other artefacts for a single site.

		.EXAMPLE
		Get-TMPnPTemplateForSite -Environment -Site $site -Credentials $credentials

		.PARAMETER Environment
		A string representation of the configuration Xml for an envrionment

		.PARAMETER Site
		The string representation of the configuration Xml for the site. Get a template from a site including artefacts such as display templates and a PnP template

		.PARAMETER Credentials
		The credentials used to connect to the site.

	#>

	param(
        [Parameter(Mandatory=$True)]
		[string]$TemplatePath,

		[Parameter(Mandatory=$True)]
		[String]$Environment,
		
		[Parameter(Mandatory=$True)]
		[String]$Site,

		[Parameter(Mandatory=$True)]		
		[PSCredential]$Credentials
	)

	begin
	{
        $path = $TemplatePath
    }

	process
	{
		[Xml]$EnvironmentXml = $Environment
		[Xml]$SiteXml = $Site

		$tenantUrl = $EnvironmentXml.Environment.Tenant
		$environmentName = $EnvironmentXml.Environment.Name

		if ($SiteXml.Site.Url -eq "")
		{
			$siteUrl = $tenantUrl
		} else
		{
			$siteUrl = $tenantUrl + "/" + $SiteXml.Site.Url
		}

		Connect-PnPOnline -Url $siteUrl -Credentials $Credentials
		Write-Host "Connected to $siteUrl"

		foreach ($webConfig in $SiteXml.Site.Webs.Web)
		{
            if ($webConfig.Export -eq "True")
            {
				if ($webConfig.Url -eq "")
				{
					$web = Get-PnPWeb
				}
				else
				{
					$web = Get-PnPWeb $webConfig.Url
				}

				$template = $webConfig.Template

				Set-PnPTraceLog -On -Level Debug

			#	Get-PnPProvisioningTemplate -Web $web -Out "$path\Templates\$template\$environmentName\template.xml" -PersistBrandingFiles -PersistPublishingFiles -IncludeAllTermGroups -Force
                $origWelcomePage = Get-WelcomePageUrl -Web $web

				if ($webConfig.PageUrl -ne $null -and $webConfig.PageUrl -ne "")
				{					
					$welcomePageUrl = $webConfig.PageUrl
  			    }
				else
				{
					$welcomePageUrl = $origWelcomePage 
				}

				if ($webconfig.Handler -eq $null -or $webConfig.Handler -eq "")
				{
					$handlers = "All"
				}
				else
				{
					$handlers = $webConfig.Handler
				}

				if ($webConfig.PageUrl -ne $null -and $webConfig.PageUrl -ne "")
				{
					Set-WelcomePageUrl -Web $web -WelcomePageUrl $welcomePageUrl
  			    }

                if ($webConfig.Url -eq "")
                {	
					
					Get-PnPProvisioningTemplate -Web $web -Out "$path\Templates\$template\$environmentName\template.xml" -PersistBrandingFiles -PersistPublishingFiles -IncludeSiteCollectionTermGroup -IncludeAllTermGroups -Force -Handlers $handlers
					if ( $? -eq $false)
					{
						Write-Host "Failure happened during export of $template" $webConfig.Handler
						if ($webConfig.PageUrl -ne $null -and $webConfig.PageUrl -ne "")
						{
							Set-WelcomePageUrl -Web $web -WelcomePageUrl $origWelcomePage
  						}

						exit
					}
					
                }
                else
                {
										
					Get-PnPProvisioningTemplate -Web $web -Out "$path\Templates\$template\$environmentName\template.xml" -PersistBrandingFiles -PersistPublishingFiles -Force
					if ( $? -eq $false)
					{
						Write-Host "Failure happened during export of $template" $webConfig.Handler
						if ($webConfig.PageUrl -ne $null -and $webConfig.PageUrl -ne "")
						{
							Set-WelcomePageUrl -Web $web -WelcomePageUrl $origWelcomePage
  						}

						exit
					}					
                }

				if ($webConfig.PageUrl -ne $null -and $webConfig.PageUrl -ne "")
				{
					Set-WelcomePageUrl -Web $web -WelcomePageUrl $origWelcomePage
  				}

                $ctx = Get-PnPContext

				#Insert Data into template
				foreach ($listXml in $webConfig.Lists.List)
				{
                    $dataXml =""

					if ($listXml.IncludeData)
					{
						$list = Get-PnPList -Web $web -Identity $listXml.Name		
                        $list.ParentWeb.Context.Load($list.Fields)
                        $list.ParentWeb.Context.ExecuteQuery()


                        $listItems = Get-PnPListItem -List $list

                        
            
              

                        $dataXml += '<pnp:DataRows xmlns:pnp="http://schemas.dev.office.com/PnP/2016/05/ProvisioningSchema">'
                        

                        foreach ($listItem in $listItems)
                        {
                           
                           $dataXml += "<pnp:DataRow>"

                                                      
                           foreach($fieldValue in $listItem.FieldValues.GetEnumerator())
                           {
                           
                                $fieldName = $fieldValue.Key #($list.Fields | Where {$_.InternalName -eq $fieldValue.Key}).Title

                                if ($fieldName -notin "ServerRedirectedEmbedUri", "ContentTypeID", "_ModerationComments", "File_x0020_Type", "ID","Author","Created","Editor","Modified By","_HasCopyDestinations",
                "_CopySource", "owshiddenversion", "WorkflowVersion", "_UIVersion", "_UIVersionString", "Attachments", "FileRef", "FileDirRef", "_ModerationStatus", "InstanceID", "WorkflowInstanceID", "Order", "GUID", "Workflow Instance ID", "URL Path",
                "Path", "Modified", "Created", "Item Type", "Sort Type", "Name",  "Unique Id",  "Client Id",  "ProgId", "ScopeId", "Property Bag", "_Level", "_IsCurrentVersion","ItemChildCount",
                "FolderChildCount","Restricted", "OriginatorId", 'ContentVersion;', "_ComplianceFlags", "_ComplianceTag", "_ComplianceTagWrittenTime", "_ComplianceTagUserId",
                "AccessPolicy", "AppAuthor","AppEditor", "SMTotalSize", "SMLastModifiedDate", "SMTotalFileStreamSize", "SMTotalFileCount", "Last_x0020_Modified", "Created_x0020_Date", "FSObjType", "SortBehavior",  "FileLeafRef", "UniqueId", "SyncClientId", "MetaInfo",  "NoExecute","ContentVersion" )
                                {

                                    if ($fieldName -ne "" -and $fieldName -ne $null)
                                    {                                        

                                        $dataXml += "<pnp:DataValue FieldName=""$fieldName"" >" 
                                        $dataXml += $fieldValue.Value
                                        $dataXml += "</pnp:DataValue>"
                                
                                    }
                                }
                           
                           }

                           $dataXml += "</pnp:DataRow>"

                        }

                        $dataXml += "</pnp:DataRows>"
                        
					}

                    [xml]$templateXml = Get-Content "$path\Templates\$template\$environmentName\template.xml"

                    $xmlList = $templateXml.Provisioning.Templates.ProvisioningTemplate.Lists.ListInstance | where { $_.Title -eq $list.Title}

                    [xml]$XmlData = $dataXml
                   
                    $xmlList.AppendChild([System.Xml.XmlNode]$templateXml.ImportNode($XmlData.DataRows,$true))

                    $templateXml.Save("$path\Templates\$template\$environmentName\template.xml")

				}


            }
		}

		#Get All Artefacts

		foreach ($ArtefactConfig in $Site.Artefacts.Artefact)
		{
			if ($ArtefactConfig.Export -eq "True")
            {
				$ArtefactName = $ArtefactConfig.Name
				$ArtefactUrl = $ArtefactConfig.Url

                $ctx = Get-PnPContext

				$folder = Get-PnPFolder -Url $ArtefactUrl

                $ctx.Load($folder.Files)
                $ctx.ExecuteQuery()

                foreach ($file in $folder.Files)
                {
                   $fileName = $file.Name
                   Get-PnPFile -Url $ArtefactUrl/$fileName  -Path $path\Templates\$environmentName\$ArtefactName -Filename $fileName -AsFile
                }
			}
		}




	}

	end
	{
	}
}


function Update-TMFeatures
{
	<#

		.SYNOPSIS
		Activate or deactivate a feature within the site

		.DESCRIPTION
		Get a PnP Template and other artefacts for a single site.

		.EXAMPLE
		Update-TMFeatures -Web $web -Site $feature -Activate $true

		.PARAMETER Environment
		A string representation of the configuration Xml for an envrionment

		.PARAMETER Feature
		The feature that needs to be activated or deactivated. Use a copy of the Xml as string from the confgiuratin Xml
	#>
    
	param(
		[Parameter(Mandatory=$True)]
        [Microsoft.SharePoint.Client.Web]$Web,

		[Parameter(Mandatory=$True)]
        [String]$Features)

	begin
	{
		[Xml]$featuresXml = $Features
	}

	process
	{
        Foreach($featureXml in $FeaturesXml.Features.Feature)
        {

		    $featureId = $featureXml.FeatureId
		    $activate = $featureXml.Enable

		    if ($activate)
		    {
			    Enable-PnPfeature -Identity $featureId -Web $Web
		    } 
		    else
		    {
			    Disable-PnPfeature -Identity $featureId -Web $Web
		    }
        }
	}

	end
	{

	}

}


function New-TMLists
{
    <#

		.SYNOPSIS
		Create lists as specified in the config file

		.DESCRIPTION
		Create lists as specified in the config file

		.EXAMPLE
		New-TMLists -Web $web -Lists $lists

		.PARAMETER Web
		the web to create the lists in

		.PARAMETER Lists
        the xml as a string that contains the list definitions.		

	#>
    param(
        [Parameter(Mandatory=$True)]
        [Microsoft.SharePoint.Client.Web]$Web,

        [Parameter(Mandatory=$True)]
        [String]$Lists
    )

    [Xml]$ListXml= $Lists

    foreach( $list in $ListXml.Lists.List)
    {
        switch ($list.Template)
        {
           "ExternalList" {
                            

                            try
                            {
                                [Microsoft.SharePoint.Client.ListCreationInformation] $listCreateInfo = New-Object -TypeName Microsoft.SharePoint.Client.ListCreationInformation

                                [Microsoft.SharePoint.Client.ListDataSource] $listDataSource = New-Object -TypeName Microsoft.SharePoint.Client.ListDataSource;

                                $listCreateInfo.Title = $list.Name
                                $listCreateInfo.Description = $list.Description

                                $listCreateInfo.DataSourceProperties.Add("Entity", $list.DataSource.Entity)
                                $listCreateInfo.DataSourceProperties.Add("EntityNamespace", $list.DataSource.NameSpace)
                                $listCreateInfo.DataSourceProperties.Add("LobSystemInstance",$list.DataSource.LobSystemInstance)
                                $listCreateInfo.DataSourceProperties.Add("SpecificFinder", $list.DataSource.SpecificReader)

                                $listCreateInfo.Url = $list.Url
                                $listCreateInfo.QuickLaunchOption = [Microsoft.SharePoint.Client.QuickLaunchOptions]::On
                                $listCreateInfo.TemplateFeatureId = [Guid]::new("00bfea71-9549-43f8-b978-e47e54a10600")
                                $listCreateInfo.TemplateType = 600

                                $ctx = Get-PnPContext
                                $web.Context.Load($web.Lists)
                                $web.Context.ExecuteQuery();

                                $newList = $web.Lists.Add($listCreateInfo)

                                $web.Context.ExecuteQuery();

                                Write-Host "Created List" $listCreateInfo.Title 
                            }
                            catch
                            {
                                $exceptionMessage = $_.Exception.Message
                                $hresult = $_.Exception.HResult
                                

                                switch($_.Exception.HResult)
                                {
                                    -2146233087 { 
                                        $exceptionMessage | Write-Host
                                        "External list " + $listCreateInfo.Title + " already exists, ignoring list" | Write-Host 
                                        }
                                    default {
                                                $exceptionMessage | Write-Host
                                                "Has the model file for external lists have been uploaded?" | Write-Host
                                                exit
                                           }

                                }
                            }



                          }
           "default" {
                            New-PnPList -Web $Web -Title $list.Name -Url $list.Url -Template $list.Template -ErrorAction SilentlyContinue
                     }
        }
    }
}

function Add-TMWorkarounds
{
    <#

		.SYNOPSIS
		Add workarounds to a site.

		.DESCRIPTION
		Add workarounds to a site either before or after the template is applied

		.EXAMPLE
		New-TMLists -Web $web -Timing "Pre-Apply" -Lists $lists

		.PARAMETER Web
		the web to add the workarounds to

		.PARAMETER Timing
        "Pre-Apply" or "Post-Apply" 
        
        .PARAMETER WorkArounds
        The xml containing all the workarounds		

	#>
    param(
        [Parameter(Mandatory=$True)]
        [Microsoft.SharePoint.Client.Web]$Web,

        [Parameter(Mandatory=$True)]
        [String]$Timing,
        
        [String]$WorkArounds
    )

    [Xml]$WorkAroundXml = $WorkArounds

    $selectedWorkArounds = $WorkAroundXml.WorkArounds.WorkAround | Where {$_.Timing -eq $Timing }

    foreach ($workaround in $selectedWorkArounds)
    {
        switch ($workaround.Name)
        {
            "Lookup Lists" {
                                $ListsStr = $workaround.Lists.OuterXml
                                New-TMLists -Web $Web -Lists $ListsStr
                           }

            "Features" {
                            $FeaturesStr = $workaround.Features.OuterXml
                            Update-TMFeatures -Web $Web -Features $FeaturesStr
                        }

            default {
                      Write-Host $workaround.Name "not implemented"
                      exit
                    }
       }
    }
}

function Add-TMPreWorkarounds
{
    <#

		.SYNOPSIS
		Add pre-apply workarounds to a site.

		.DESCRIPTION
		Add pre-apply workarounds to a site either before or after the template is applied

		.EXAMPLE
		New-TMLists -Web $web -Lists $lists

		.PARAMETER Web
		the web to add the workarounds to
		
        .PARAMETER WorkArounds
        The xml containing all the workarounds		

	#>

    param( 
           [Parameter(Mandatory=$True)]
           [Microsoft.SharePoint.Client.Web]$Web,
           
           [String]$WorkArounds
         )

    Add-TMWorkarounds -Web $Web -Timing "Pre-Apply" -WorkArounds $WorkArounds
}

function Add-TMPostWorkarounds
{
	<#

		.SYNOPSIS
		Add post-apply workarounds to a site.

		.DESCRIPTION
		Add post-apply workarounds to a site either before or after the template is applied

		.EXAMPLE
		New-TMLists -Web $web -Lists $lists

		.PARAMETER Web
		the web to add the workarounds to
		
        .PARAMETER WorkArounds
        The xml containing all the workarounds		

	#>
    param(  [Microsoft.SharePoint.Client.Web]$Web,
            [String]$WorkArounds

         )

    Add-TMWorkarounds -Web $Web -Timing "Post-Apply" -WorkArounds $WorkArounds
}

function Add-TMArtefacts
{
    <#

		.SYNOPSIS
		Add artefacts to a site.

		.DESCRIPTION
		Add artefacts to a site

		.EXAMPLE
		Add-TMArtefacts -Web $web -Lists $lists

		.PARAMETER Web
		the web to add the workarounds to
		
        .PARAMETER WorkArounds
        The xml containing all the workarounds		

	#>
    param(
            [Parameter(Mandatory=$True)]
            [Microsoft.SharePoint.Client.Web]$Web,

            [Parameter(Mandatory=$True)]
            [String]$SourceEnvironment,

            [Parameter(Mandatory=$True)]
            [String]$Artefacts
         )

    [Xml]$ArtefactsXml = $Artefacts
    foreach($Artefact in $ArtefactsXml.Artefacts.Artefact)
    {
        $ArtefactPath = $path + "\Templates\$SourceEnvironment\" + $Artefact.Name

        if (Test-Path $ArtefactPath)
        {
            $files = Get-ChildItem $ArtefactPath

            foreach ($file in  $files)
            {
                $filePath = $ArtefactPath + "\" + $file
                Add-PnPFile -Path $filePath -Web $Web -Folder $Artefact.Url
            }
        }
    }
}

function Update-TemplateWithFixes
{
    <#

		.SYNOPSIS
		Update the template file with fixes.

		.DESCRIPTION
		Update the template file with fixes.The result is copied to a file $templatefile + $DestinationTenant + ".xml". 

		.EXAMPLE
		Update-TemplateWithFixes -templatefile $templatefile -SourceTenant $source -DestinationTenant $destination 

		.PARAMETER templatefile
		the file to update
		
        .PARAMETER SourceTenant
        The name of the source tenant	

        .PARAMETER DestinationTenant
        The name of the source tenant

        .PARAMETER Notes
        This removes the Style Library from the template as it causes access denieds.

	#>

    param( [Parameter(Mandatory=$True)]
           [String]$templatefile,

           [Parameter(Mandatory=$True)]
           [String]$SourceTenant,

           [Parameter(Mandatory=$True)]
           [String]$DestinationTenant)

    begin
    {
    }

    process
    {
        $newFileName =  $templatefile + $DestinationTenant + ".xml"
        ## replace anything to do with the source tenant name with the destination tenant name
	    $content = (Get-Content $templatefile )
        $content = $content -replace "$SourceTenant", "$DestinationTenant"



        # fix the issue  with Style Libraries where the apply template falls overs.

        $foundat = -1

        for( $i = 0 ; $i -lt $content.Count; $i++ )
        {
           if ($content[$i].Contains('Title="Style Library"'))
           {
              $foundat = $i
           }

           if ($foundat -gt 0)
           {
             if ($content[$i].Contains('</pnp:ListInstance>'))
             {
                $content[$i] = ""
                  $i = $content.Count
             }
             else
             {
             $content[$i] = ""
             }
           }
        }

        $content | Out-File $newFileName -encoding "UTF8"


        # fix the issue where lists have custom document templates set. Setting them back to the default value.

    }

    end
    {
    }
}

function Add-TMPnPTemplateForSite
{
	<#

		.SYNOPSIS
		Apply a template and upload all Artefacts

		.DESCRIPTION
		Apply the template and all Artefacts

		.EXAMPLE
		./Add-TMCredentials -Site $site -Credentials -$credentials

		.PARAMETER Site
		Supply the site xml to apply the template to

		.PARAMETER Credentials
		Use credentials

	#>

	param(
         [Parameter(Mandatory=$True)]
		 [string]$TemplatePath,

         [Parameter(Mandatory=$True)]
		 [String]$SourceEnvironment,

         [Parameter(Mandatory=$True)]
         [String]$DestinationEnvironment,

         [Parameter(Mandatory=$True)]
		 [String]$Site,

         [Parameter(Mandatory=$True)]
		 [PSCredential]$Credentials
	)

	begin
	{
        $path = $TemplatePath
    }

	process
	{
		[Xml]$SourceEnvironmentXml = $SourceEnvironment
        [Xml]$DestinationEnvironmentXml = $DestinationEnvironment
		[Xml]$SiteXml = $Site

        $sourceTenantUrl = $SourceEnvironmentXml.Environment.Tenant
		$destinationTenantUrl = $DestinationEnvironmentXml.Environment.Tenant
	    $destinationEnvironmentName = $DestinationEnvironmentXml.Environment.Name
        $sourceEnvironmentName = $SourceEnvironmentXml.Environment.Name

			if ($SiteXml.Site.Url -eq "" -or $SiteXml.Site.Url -eq $null)
				{
					$siteUrl = $destinationTenantUrl

                    Connect-PnPOnline -Url $destinationTenantUrl -Credentials $Credentials

                    $siteCollection = Get-PnPTenantSite -Url $siteUrl
                    if ($siteCollection -ne $null)
                   {
                            "$siteUrl already exists " | Write-Debug
                   } else
                   {
                            #TODO:  make following configurable
                            New-PnPTenantSite -Title "New Site Collection" -Url $siteUrl -Template "STS#0"
                   }
				} else
				{
				   $siteUrl = $destinationTenantUrl + "/" + $SiteXml.Site.Url
                   $siteCollection = Get-PnPTenantSite -Url $siteUrl
                   if ($siteCollection -ne $null)
                   {
                            "$siteUrl already exists " | Write-Debug
                   } else
                   {
                            #TODO:  make following configurable
                            New-PnPTenantSite -Title "New Site Collection" -Url $siteUrl -Template "STS#0"
                   }
				}

                
               

				Connect-PnPOnline -Url $siteUrl -Credentials $Credentials
                if ($? -eq $false)
                {
                    Write-Host "Failed to Connect to $siteUrl"
                    exit
                }

				Write-Host "Connected to $siteUrl"

				foreach ($webConfig in $SiteXml.Site.Webs.Web)
				{
                    if ($WebConfig.Import -eq "True")
                    {
                        $template = $webConfig.Template

					    if ($webConfig.Url -eq "")
					    {
						    $web = Get-PnPWeb
					    }
					    else
					    {
                            if ($webConfig.Url.Contains("/"))
                            {
                                #this is a subweb
                                $urlArray = ([string]$webConfig.Url).Split("/")

                                $webUrl = $urlArray[$urlArray.Count-1]
                                
                                $parentWebUrl = $webConfig.Url -replace "$webUrl", ""

                                $web = Get-PnPSubWebs -Web $parentWebUrl | Where-Object { $_.ServerRelativeUrl -match $webConfig.Url }
                                if ($web -eq $null -or $web.Count -ne 1)
                                {
                                    Write-Host "About to create site with Url " $webConfig.Url 

                                    [xml]$content = Get-Content "$path\Templates\$template\$sourceEnvironmentName\template.xml"

                                    $baseTemplate = $content.Provisioning.Templates.ProvisioningTemplate.BaseSitetemplate
                                
                                    
                                     $retry = 10;
                                    while($retry -gt 0)
                                    {
                                        try
                                        {
                                            New-PnPWeb -Web $parentWebUrl -Url  $webUrl -Title "New site created" -Template $baseTemplate 
                                            $retry = 0
                                        }
                                        catch
                                        {                                         
                                            #try again
                                            $web = New-PnPWeb -Url  $webConfig.Url -Title "New site created" -Template $baseTemplate 
                                            $retry--
                                        }
                                    }

                                    $web = Get-PnPSubWebs -Web $parentWebUrl | Where-Object { $_.ServerRelativeUrl -match $webConfig.Url }
                                }

                            } else
                            {
						        $web = Get-PnPWeb $webConfig.Url 
                                if ($? -eq $false)
                                {
                                    Write-Host "About to create site with Url " $webConfig.Url 

                                    [xml]$content = Get-Content "$path\Templates\$template\$sourceEnvironmentName\template.xml"

                                    $baseTemplate = $content.Provisioning.Templates.ProvisioningTemplate.BaseSitetemplate
                                
                                    $retry = 10;
                                    while($retry -gt 0)
                                    {
                                        try
                                        {
                                            $web = New-PnPWeb -Url  $webConfig.Url -Title "New site created" -Template $baseTemplate 
                                            $retry = 0
                                        }
                                        catch
                                        {
                                            
                                            #try again
                                            $web = New-PnPWeb -Url  $webConfig.Url -Title "New site created" -Template $baseTemplate 
                                            $retry--
                                        }
                                    }


                                    
                                }
                            }
                            

                            

					    }

					    $template = $webConfig.Template

                        [string]$workarounds = $webConfig.WorkArounds.OuterXml
                        Add-TMPreWorkarounds -Web $web -WorkArounds $workarounds

                        $destinationTenant = $destinationTenantUrl.Replace(".sharepoint.com", "").Replace("https://","")
                        $sourceTenant = $sourceTenantUrl.Replace(".sharepoint.com", "").Replace("https://","")

                        Update-TemplateWithFixes -TemplateFile "$path\Templates\$template\$sourceEnvironmentName\template.xml" -SourceTenant $sourceTenant -DestinationTenant $destinationTenant

                        $templateFile =  "$path\Templates\$template\$sourceEnvironmentName\template.xml" + $DestinationTenant + ".xml"

					    Set-PnPTraceLog -On -Level Debug

                        if ( $webConfig.Handler -eq $null)
                        {
                            Apply-PnPProvisioningTemplate -Web $web -Path $templateFile -ExcludeHandlers TermGroups, SiteSecurity, Navigation
                            # Might need to use the following when moving from team site to publishing
                            #Apply-PnPProvisioningTemplate -Web $web -Path "$path\Templates\$template\$environmentNameFrom\template.xml" -ExcludeHandlers Workflows, Pages, PageContents
                            if ( $? -eq $false)
                            {
                                Write-Host "Failure happened with $template ($templateFile)" $webConfig.Handler "template"
                                exit
                            }
                            #Apply-PnPProvisioningTemplate -Web $web -Path $templateFile -Handlers Navigation
                        } else
                        {
                            Apply-PnPProvisioningTemplate -Web $web -Path $templateFile -Handlers $webConfig.Handler
                            if ( $? -eq $false)
                            {
                                Write-Host "Failure happened with $template ($templateFile)" $webConfig.Handler "template"
                                exit
                            }
                        }

                        $ArtefactsStr = $webConfig.Artefacts.OuterXml

                        if ($ArtefactsStr -ne $null -and $ArtefactsStr -ne "")
                        {
                            Add-TMArtefacts -Web $web -Artefacts $ArtefactsStr -SourceEnvironment $sourceEnvironmentName
                        }

                        
                        $workArounds = $webConfig.WorkArounds.OuterXml
                        Add-TMPostWorkarounds -Web $web -WorkArounds $workArounds 
                    }
				}
		}
	}

function Add-TMPnPTemplatesForSiteCollections
{
	<#

		.SYNOPSIS
		Apply a template and upload all artefacts for a whole site collection and all its subsites

		.DESCRIPTION
		Apply a template and upload all artefacts for a whole site collection and all its subsites

		.EXAMPLE
		Add-TMPnPTemplatesForSiteCollections -SourceEnvironment $source -DestinationEnvironment -$dest -Site $site

		.PARAMETER Site
		Supply the site xml to apply the template to

		.PARAMETER Credentials
		Use credentials

	#>
	param(
        [Parameter(Mandatory=$True)]
		[string]$TemplatePath,

         [Parameter(Mandatory=$True)]
         [String]$Configuration,

         [Parameter(Mandatory=$True)]
		 [String]$SourceEnvironment,

         [Parameter(Mandatory=$True)]
         [String]$DestinationEnvironment

	)

	begin
	{
        [xml]$config = $Configuration
        $path = $TemplatePath
    }

	process
	{
		# Get the source environment name where the solution was exported from.
		if ($sourceEnvironment -ne $null -and $sourceEnvironment -ne ""  )
		{
			$sourceEnvironment = $SourceEnvironment
		} else
		{
			$sourceEnvironment = $defaultSourceEnvironment
		}
		# Get the destination environment name where the solution was exported from.
		if ($destinationEnvironment -ne $null -and $destinationEnvironment -ne ""  )
		{
			$destinationEnvironment = $DestinationEnvironment
		} else
		{
			$destinationEnvironment = $defaultDestinationEnvironment
		}

		# Load the PnP Module as specified in the config.xml
		$PnPPath = $config.Configurations.Configuration.Settings.PnPRelease

		if ($env:PSModulePath -notlike "*$path\Modules\$PnPPath\Modules*")
		{
			"Adding ;$path\Modules\$PnPPath\Modules to PSModulePath" | Write-Debug
			$env:PSModulePath += ";$path\Modules\$PnPPath\Modules"
		}

		if ($env:PSModulePath -notlike "*$path\Modules\TriadModules\Modules\*")
		{
			"Adding ;$path\Modules to PSModulePath" | Write-Debug
			$env:PSModulePath += ";$path\Modules\TriadModules\Modules"
		}

		#Reload Modules if they are loaded already to avoid old versions being used
		if ((Get-Module | Where {$_.Name -eq "Triad.PowerShell.Utilities"}).Count -eq 1)
		{
			Remove-Module "Triad.PowerShell.Utilities"
			Import-Module "Triad.PowerShell.Utilities"
		}

		if ((Get-Module | Where {$_.Name -eq "Triad.PowerShell.PnPTemplates"}).Count -eq 1)
		{
			Remove-Module "Triad.PowerShell.PnPTemplates"
			Import-Module "Triad.PowerShell.PnPTemplates"
		}

		"The current module path is set to :" + $env:PSModulePath | Write-Debug

		$environmentNameFrom  = "" # set the name where from to empty

		# Get the environments from configuration configuration
		[System.Xml.XmlLinkedNode]$sourceEnvironmentXml = $config.Configurations.Configuration.Environments.Environment | Where { $_.Name -eq $sourceEnvironment }
		[System.Xml.XmlLinkedNode]$destinationEnvironmentXml = $config.Configurations.Configuration.Environments.Environment | Where { $_.Name -eq $destinationEnvironment }

		"The " + $sourceEnvironmentXml.Name + " template site will be applied to " + $destinationEnvironmentXml.Name | Write-Debug

		[string]$sourceEnvironmentStr = $sourceEnvironmentXml.OuterXml
		[string]$destinationEnvironmentStr = $destinationEnvironmentXml.OuterXml

		$cred = Get-TMCredential -Environment $destinationEnvironmentStr

		$tenantUrl = $environment.Tenant
		$environmentNameTo = $environment.Name

		Foreach ( $siteConfig in $destinationEnvironmentXml.Sites.Site)
		{
			$siteConfigXml = $siteConfig.OuterXml

            Add-TMPnPTemplateForSite -TemplatePath "$path" -SourceEnvironment "$sourceEnvironmentStr" -DestinationEnvironment "$destinationEnvironmentStr"  -Site "$siteConfigXml" -Credentials $cred
		}

		Write-Host "Templates have been applied from $path\Templates"
	}

	end
	{
	}
}