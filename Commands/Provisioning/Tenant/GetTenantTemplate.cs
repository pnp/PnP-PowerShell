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

        [Parameter(Mandatory = true)]
        public string SiteUrl;

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
            using (var siteContext = Tenant.Context.Clone(SiteUrl))
            {
                if (siteContext.Web.IsSubSite())
                {
                    WriteError(new ErrorRecord(new ArgumentException("You can only run this cmdlet on a root site"), "NOTROOTSITE", ErrorCategory.InvalidType, this));
                    return;
                }
                siteContext.Web.EnsureProperties(w => w.WebTemplate, w => w.Configuration);
                if (siteContext.Web.WebTemplate != "GROUP" && siteContext.Web.WebTemplate != "SITEPAGEPUBLISHING")
                {
                    WriteError(new ErrorRecord(new ArgumentException("You can only run this cmdlet on a Team Site (GROUP#0) or a Communication Site (SITEPAGEPUBLSHING#0) site"), "SITECANNOTBECLASSIC", ErrorCategory.InvalidType, this));
                    return;
                }
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

        private void ExtractTemplate(string path, string packageName, ExtractConfiguration configuration)
        {
            configuration.ProgressAction = (message, step, total) =>
            {
                var percentage = Convert.ToInt32((100 / Convert.ToDouble(total)) * Convert.ToDouble(step));

                WriteProgress(new ProgressRecord(0, $"Extracting Tenant Template", message) { PercentComplete = percentage });
                WriteProgress(new ProgressRecord(1, " ", " ") { RecordType = ProgressRecordType.Completed });
            };
            configuration.MessageAction = (message, type) =>
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
            var tenantTemplate = Tenant.GetTenantTemplate(SiteUrl, configuration);
            XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(path, "");
            provider.SaveAs(tenantTemplate, Path.Combine(path, packageName));
        }
    }
}
#endif