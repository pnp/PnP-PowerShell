using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http.Headers;
using System.Net.Mime;
using Newtonsoft.Json;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Enums;
using SharePointPnP.PowerShell.Commands.Utilities;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Get, "SPOProvisioningTemplateFromGallery", DefaultParameterSetName = "Search")]
    [CmdletHelp("Retrieves or searches provisioning templates from the PnP Template Gallery", Category = CmdletHelpCategory.Lists)]
    [CmdletExample(
        Code = @"Get-SPOProvisionTemplateFromGallery",
        Remarks = @"Retrieves all templates from the gallery",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"Get-SPOProvisionTemplateFromGallery -Search ""Data""",
        Remarks = @"Searches for a templates containing the word 'Data' in the Display Name",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"Get-SPOProvisionTemplateFromGallery -Identity ae925674-8aa6-438b-acd0-d2699a022edd",
        Remarks = @"Retrieves a template with the specified ID",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"$template = Get-SPOProvisionTemplateFromGallery -Identity ae925674-8aa6-438b-acd0-d2699a022edd
Apply-SPOProvisioningTemplate -InputInstance $template",
        Remarks = @"Retrieves a template with the specified ID and applies it to the site.",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"$template = Get-SPOProvisionTemplateFromGallery -Identity ae925674-8aa6-438b-acd0-d2699a022edd -Path c:\temp",
        Remarks = @"Retrieves a template with the specified ID and saves the template to the specified path",
        SortOrder = 4)]
    public class GetProvisioningTemplateFromGallery : PSCmdlet
    {
        private const string BaseTemplateUrl = "https://templates-gallery.sharepointpnp.com";
        [Parameter(Mandatory = false, ParameterSetName = "Identity")]
        public Guid Identity;

        [Parameter(Mandatory = false, ParameterSetName = "Search")]
        public string Search;

        [Parameter(Mandatory = false, ParameterSetName = "Search")]
        public TargetPlatform TargetPlatform = TargetPlatform.All;
        
        [Parameter(Mandatory = false, ParameterSetName = "Search")]
        public TargetScope TargetScope = TargetScope.Site;

        [Parameter(Mandatory = false, ParameterSetName = "Identity")]
        public string Path;

        [Parameter(Mandatory = false, ParameterSetName = "Identity")] public SwitchParameter Force;

            
            
        protected override void BeginProcessing()
        {
            var targetPlatforms = TargetPlatform.ToString();
            var targetScopes = TargetScope.ToString();
 
            if(ParameterSetName == "Identity")
            { 
                var template = DownloadTemplate(Identity,Path);
                if (template != null)
                {
                    WriteObject(template);
                }

            }
            else
            {
                var searchKey = Search != null ? System.Web.HttpUtility.UrlEncode(Search) : "";
                var jsonSearchResult =
                    HttpHelper.MakeGetRequestForString(
                        $"{BaseTemplateUrl}/api/SearchTemplates?searchText={searchKey}&Platform={System.Web.HttpUtility.UrlEncode(targetPlatforms)}&Scope={System.Web.HttpUtility.UrlEncode(targetScopes)}");

                if (!string.IsNullOrEmpty(jsonSearchResult))
                {
                    // Convert from JSON to a typed array
                    var searchResultItems =
                        JsonConvert.DeserializeObject<PnPTemplatesGalleryResultItem[]>(jsonSearchResult);

                    var result = (from r in searchResultItems
                        select new ProvisioningTemplateInformation
                        {
                            Id = r.Id,
                            DisplayName = r.Title,
                            Description = r.Abstract,
                            TemplateFileUri = r.TemplatePnPUrl,
                            TemplateImageUrl = r.ImageUrl,
                            Scope = r.Scopes,
                            Platforms = r.Platforms,
                        }).ToArray();
                    WriteObject(result, true);
                }
            }

        }

        private ProvisioningTemplate DownloadTemplate(Guid templateId, string path)
        {
            if (path != null && !System.IO.Path.IsPathRooted(path))
            {
                path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, path);
            }
            HttpContentHeaders headers = null;
            // Get the template via HTTP REST
            var templateStream = HttpHelper.MakeGetRequestForStreamWithResponseHeaders($"{BaseTemplateUrl}/api/DownloadTemplate?templateId={templateId}", "application/octet-stream", out headers);

            // If we have any result
            if (templateStream != null)
            {
                XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(templateStream));
                var cd = new ContentDisposition(headers.ContentDisposition.ToString());
                var openXMLFileName = cd.FileName;

                if (path != null)
                {
                    if (System.IO.Directory.Exists(path))
                    {
                        var fileName = System.IO.Path.Combine(path, openXMLFileName);
                        bool doSave = false;
                        if (System.IO.File.Exists(fileName))
                        {
                            if (Force ||
                                ShouldContinue(string.Format(Resources.File0ExistsOverwrite, openXMLFileName), Resources.Confirm))
                            {
                                doSave = true;
                            }
                        }
                        else
                        {
                            doSave = true;
                        }
                        if (doSave)
                        {
                            // Save the template to the path
                            using (var fileStream = System.IO.File.Create(fileName)
                            )
                            {
                                templateStream.Seek(0, SeekOrigin.Begin);
                                templateStream.CopyTo(fileStream);
                            }
                            WriteObject($"File saved to {openXMLFileName}");
                        }
                        return null;
                    }
                    else
                    {
                        WriteError(new ErrorRecord(new Exception("Folder does not exist"), "FOLDERDOESNOTEXIST", ErrorCategory.InvalidArgument, path));
                    }
                }
                else
                {
                    // Determine the name of the XML file inside the PNP Open XML file
                    var xmlTemplateFile = openXMLFileName.ToLower().Replace(".pnp", ".xml");

                    // Get the template
                    var result = provider.GetTemplate(xmlTemplateFile);
                    result.Connector = provider.Connector;
                    templateStream.Close();
                    return result;
                }
                
            }
            return null;
        }
    }
}
