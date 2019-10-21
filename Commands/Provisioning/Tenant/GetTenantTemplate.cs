#if !ONPREMISES
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using File = System.IO.File;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;
using System.Collections;
using SharePointPnP.PowerShell.Commands.Utilities;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using OfficeDevPnP.Core.Framework.Provisioning.Model.Configuration;
using SharePointPnP.PowerShell.Commands.Base;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands.Provisioning.Site
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantTemplate", SupportsShouldProcess = true)]
    [CmdletHelp("Generates a provisioning tenant template from a site",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Get-PnPTemplateTemplate -Out template.pnp",
       Remarks = "Extracts a provisioning template in Office Open XML from the current web.",
       SortOrder = 1)]
    public class GetTenantTemplate : PnPAdminCmdlet
    {
        private ProgressRecord mainProgressRecord = new ProgressRecord(0, "Processing", "Status");
        private ProgressRecord subProgressRecord = new ProgressRecord(1, "Activity", "Status");

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename to write to, optionally including full path")]
        public string Out;

        [Parameter(Mandatory = false, HelpMessage = "Overwrites the output file if it exists.")]
        public SwitchParameter Force;

        [Parameter(Mandatory = false, HelpMessage = "Returns the template as an in-memory object, which is an instance of the ProvisioningTemplate type of the PnP Core Component. It cannot be used together with the -Out parameter.")]
        public SwitchParameter OutputInstance;

        [Parameter(Mandatory = false, HelpMessage = "Specify a JSON configuration file to configure the extraction progress.")]
        public ProvisioningConfigurationPipeBind Configuration;

        protected override void ExecuteCmdlet()
        {
            if (WebContext.Web.IsSubSite())
            {
                WriteError(new ErrorRecord(new ArgumentException("You can only run this cmdlet on a root site"), "NOTROOTSITE", ErrorCategory.InvalidType, this));
                return;
            }
            WebContext.Web.EnsureProperties(w => w.WebTemplate, w => w.Configuration);
            if (WebContext.Web.WebTemplate != "GROUP" && WebContext.Web.WebTemplate != "SITEPAGEPUBLISHING")
            {
                WriteError(new ErrorRecord(new ArgumentException("You can only run this cmdlet on a Team Site (GROUP#0) or a Communication Site (SITEPAGEPUBLSHING#0) site"), "SITECANNOTBECLASSIC", ErrorCategory.InvalidType, this));
                return;
            }
            ExtractConfiguration extractConfiguration = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Configuration)))
            {
                extractConfiguration = OfficeDevPnP.Core.Framework.Provisioning.Model.Configuration.ExtractConfiguration.FromString(Configuration.GetContents(SessionState.Path.CurrentFileSystemLocation.Path));
            }


            if (!string.IsNullOrEmpty(Out))
            {
                if (!Path.IsPathRooted(Out))
                {
                    Out = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Out);
                }
                if (File.Exists(Out))
                {
                    if (Force || ShouldContinue(string.Format(Resources.File0ExistsOverwrite, Out), Resources.Confirm))
                    {
                        ExtractTemplate(new FileInfo(Out).DirectoryName, new FileInfo(Out).Name, extractConfiguration);
                    }
                }
                else
                {
                    ExtractTemplate(new FileInfo(Out).DirectoryName, new FileInfo(Out).Name, extractConfiguration);
                }
            }
            else
            {
                ExtractTemplate(SessionState.Path.CurrentFileSystemLocation.Path, null, extractConfiguration);
            }
        }

        private ProvisioningTemplate GetTemplate(string url, string path, ExtractConfiguration configuration)
        {
            using (var webContext = ClientContext.Clone(url))
            {
                WebContext.Web.EnsureProperty(w => w.Url);
                ProvisioningTemplateCreationInformation creationInformation = null;
                if (configuration != null)
                {
                    creationInformation = configuration.ToCreationInformation(WebContext.Web);
                }
                else
                {
                    creationInformation = new ProvisioningTemplateCreationInformation(WebContext.Web);
                }

                var fileSystemConnector = new FileSystemConnector(path, "");
                creationInformation.FileConnector = fileSystemConnector;

                creationInformation.ProgressDelegate = (message, step, total) =>
                {
                    var percentage = Convert.ToInt32((100 / Convert.ToDouble(total)) * Convert.ToDouble(step));

                    WriteProgress(new ProgressRecord(0, $"Extracting Template from {webContext.Web.Url}", message) { PercentComplete = percentage });
                    WriteProgress(new ProgressRecord(1, " ", " ") { RecordType = ProgressRecordType.Completed });
                };
                creationInformation.MessagesDelegate = (message, type) =>
                {
                    switch (type)
                    {
                        case ProvisioningMessageType.Warning:
                            {
                                WriteWarning(message);
                                break;
                            }
                        case ProvisioningMessageType.Progress:
                            {
                                var activity = message;
                                if (message.IndexOf("|") > -1)
                                {
                                    var messageSplitted = message.Split('|');
                                    if (messageSplitted.Length == 4)
                                    {
                                        var current = double.Parse(messageSplitted[2]);
                                        var total = double.Parse(messageSplitted[3]);
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.Activity = messageSplitted[0];
                                        subProgressRecord.StatusDescription = messageSplitted[1];
                                        subProgressRecord.PercentComplete = Convert.ToInt32((100 / total) * current);
                                        WriteProgress(subProgressRecord);
                                    }
                                    else
                                    {
                                        subProgressRecord.Activity = "Processing";
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.StatusDescription = activity;
                                        subProgressRecord.PercentComplete = 0;
                                        WriteProgress(subProgressRecord);
                                    }
                                }
                                else
                                {
                                    subProgressRecord.Activity = "Processing";
                                    subProgressRecord.RecordType = ProgressRecordType.Processing;
                                    subProgressRecord.StatusDescription = activity;
                                    subProgressRecord.PercentComplete = 0;
                                    WriteProgress(subProgressRecord);
                                }
                                break;
                            }
                        case ProvisioningMessageType.Completed:
                            {
                                WriteProgress(new ProgressRecord(1, message, " ") { RecordType = ProgressRecordType.Completed });
                                break;
                            }
                    }
                };
                return webContext.Web.GetProvisioningTemplate(creationInformation);
            }
        }

        private List<ProvisioningTemplate> ParseSubWebsTemplates(WebCollection subwebs, string path, ExtractConfiguration configuration)
        {
            List<ProvisioningTemplate> templates = new List<ProvisioningTemplate>();
            foreach (var subweb in subwebs)
            {
                subweb.EnsureProperties(w => w.Url, w => w.WebTemplate, w => w.Configuration);
                var url = subweb.Url;
                if (subweb.WebTemplate == "STS" && subweb.Configuration == 3)
                {
                    var template = GetTemplate(subweb.EnsureProperty(w => w.Url), path, configuration);
                    template.Parameters.Add("SITEURL", url);
                    templates.Add(template);
                    var subsubwebs = subweb.EnsureProperty(s => s.Webs);
                    if (subsubwebs.Count > 0)
                    {
                        templates.AddRange(ParseSubWebsTemplates(subsubwebs, path, configuration));
                    }
                }
            }
            return templates;
        }

        private SubSite ParseSubsiteSequences(Web subweb, List<ProvisioningTemplate> subwebTemplates, ref ProvisioningHierarchy tenantTemplate)
        {
            subweb.EnsureProperties(sw => sw.Url, sw => sw.Title, sw => sw.QuickLaunchEnabled, sw => sw.Description, sw => sw.Language, sw => sw.RegionalSettings.TimeZone, sw => sw.Webs, sw => sw.HasUniqueRoleAssignments);
            var subwebTemplate = subwebTemplates.FirstOrDefault(t => t.Parameters["SITEURL"] == subweb.Url);
            var uniqueid = Guid.NewGuid().ToString("N");
            tenantTemplate.Parameters.Add($"SUBSITE_{uniqueid}_SITEURL", subweb.Url);
            tenantTemplate.Parameters.Add($"SUBSITE_{uniqueid}_SITETITLE", subweb.Title);
            var subSiteCollection = new TeamNoGroupSubSite()
            {
                Url = $"{{parameter:SUBSITE_{uniqueid}_SITEURL}}",
                Title = $"{{parameter:SUBSITE_{uniqueid}_SITEURL}}",
                QuickLaunchEnabled = subweb.QuickLaunchEnabled,
                Description = subweb.Description,
                Language = (int)subweb.Language,
                TimeZoneId = subweb.RegionalSettings.TimeZone.Id,
                UseSamePermissionsAsParentSite = !subweb.HasUniqueRoleAssignments,
                Templates = { subwebTemplate.Id }
            };
            if (subweb.Webs.AreItemsAvailable)
            {
                foreach (var subsubweb in subweb.Webs)
                {
                    subSiteCollection.Sites.Add(ParseSubsiteSequences(subsubweb, subwebTemplates, ref tenantTemplate));
                }

            }
            return subSiteCollection;
        }

        private void ExtractTemplate(string path, string packageName, ExtractConfiguration configuration)
        {
            WebContext.Web.EnsureProperty(w => w.Url);

            var rootTemplate = GetTemplate(WebContext.Web.Url, path, configuration);

            List<ProvisioningTemplate> subwebTemplates = new List<ProvisioningTemplate>();
            // subsites?
            var subwebs = WebContext.Web.EnsureProperty(w => w.Webs);
            if (subwebs.Count > 0)
            {
                subwebTemplates = ParseSubWebsTemplates(subwebs, path, configuration);
            }

            // Set metadata for template, if any
            //SetTemplateMetadata(template, TemplateDisplayName, TemplateImagePreviewUrl, TemplateProperties);

            if (!OutputInstance)
            {
                ProvisioningHierarchy tenantTemplate = new ProvisioningHierarchy();
                ProvisioningSequence tenantSequence = new ProvisioningSequence();

                WebContext.Web.EnsureProperties(w => w.Title, w => w.Language, w => w.Description);

                var hubsitesProperties = Tenant.GetHubSitesProperties();
                Tenant.Context.Load(hubsitesProperties);
                Tenant.Context.ExecuteQueryRetry();
                var hubsiteProperties = hubsitesProperties.FirstOrDefault(h => h.SiteUrl == WebContext.Web.Url);
                Tenant.Context.ExecuteQueryRetry();
                switch (WebContext.Web.WebTemplate)
                {
                    case "SITEPAGEPUBLISHING":
                        {
                            tenantTemplate.Parameters.Add("ROOTSITEURL", WebContext.Web.Url);
                            tenantTemplate.Parameters.Add("ROOTSITETITLE", WebContext.Web.Title);
                            // Communication site
                            var siteCollection = new CommunicationSiteCollection()
                            {
                                Title = "{parameter:ROOTSITETITLE}",
                                Classification = WebContext.Site.EnsureProperty(s => s.Classification),
                                IsHubSite = WebContext.Site.EnsureProperty(s => s.IsHubSite),
                                HubSiteTitle = hubsiteProperties?.Title,
                                HubSiteLogoUrl = hubsiteProperties?.LogoUrl,
                                Language = (int)WebContext.Web.Language,
                                Description = WebContext.Web.Description,
                                Url = "{parameter:ROOTSITEURL}",
                                Templates = {
                                    rootTemplate.Id
                                }
                            };
                            if (WebContext.Web.EnsureProperty(w => w.Webs).Count > 0)
                            {
                                foreach (var subweb in WebContext.Web.Webs)
                                {
                                    siteCollection.Sites.Add(ParseSubsiteSequences(subweb, subwebTemplates, ref tenantTemplate));
                                }
                            }
                            tenantSequence.SiteCollections.Add(siteCollection);
                            break;
                        }
                }
                tenantTemplate.Templates.Add(rootTemplate);
                tenantTemplate.Sequences.Add(tenantSequence);
                foreach (var subwebTemplate in subwebTemplates)
                {
                    tenantTemplate.Templates.Add(subwebTemplate);
                }

                //if (extension == ".pnp")
                //{
                //    IsolatedStorage.InitializeIsolatedStorage();

                //    XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(
                //          creationInformation.FileConnector as OpenXMLConnector);
                //    var templateFileName = packageName.Substring(0, packageName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";

                //    provider.SaveAs(tenantTemplate, templateFileName);
                //}
                //else
                //{
                XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(path, "");
                provider.SaveAs(tenantTemplate, Path.Combine(path, packageName));
                //}
            }
            //else
            //{
            //    WriteObject(tenantTemplate);
            //}
        }
    }
}
#endif