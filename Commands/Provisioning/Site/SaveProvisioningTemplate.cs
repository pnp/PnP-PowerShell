using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsData.Save, "PnPProvisioningTemplate")]
    [CmdletHelp("Saves a PnP site template to the file system",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Save-PnPSiteTemplate -InputInstance $template -Out .\template.pnp",
       Remarks = "Saves a PnP site template to the file system as a PnP file.",
       SortOrder = 1)]
    public class SaveProvisioningTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Allows you to provide an in-memory instance of the ProvisioningTemplate type of the PnP Core Component. When using this parameter, the -Out parameter refers to the path for saving the template and storing any supporting file for the template.")]
        [Alias("InputInstance")]
        public ProvisioningTemplate Template;

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename to write to, optionally including full path.")]
        public string Out;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify the ITemplateProviderExtension to execute while saving a template.")]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        protected override void ProcessRecord()
        {
            // Determine the output file name and path
            string outFileName = Path.GetFileName(Out);

            if (!Path.IsPathRooted(Out))
            {
                Out = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Out);
            }

            bool proceed = false;

            if (System.IO.File.Exists(Out))
            {
                if (Force || ShouldContinue(string.Format(Properties.Resources.File0ExistsOverwrite, Out),
                    Properties.Resources.Confirm))
                {
                    proceed = true;
                }
            }
            else
            {
                proceed = true;
            }

            string outPath = new FileInfo(Out).DirectoryName;

            // Determine if it is an .XML or a .PNP file
            var extension = "";
            if (proceed && outFileName != null)
            {
                if (outFileName.IndexOf(".", StringComparison.Ordinal) > -1)
                {
                    extension = outFileName.Substring(outFileName.LastIndexOf(".", StringComparison.Ordinal)).ToLower();
                }
                else
                {
                    extension = ".pnp";
                }
            }

            var fileSystemConnector = new FileSystemConnector(outPath, "");

            ITemplateFormatter formatter = XMLPnPSchemaFormatter.LatestFormatter;

            if (extension == ".pnp")
            {
                IsolatedStorage.InitializeIsolatedStorage();

                XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(
                      Out, fileSystemConnector);
                var templateFileName = outFileName.Substring(0, outFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";

                provider.SaveAs(Template, templateFileName, formatter, TemplateProviderExtensions);
                ProcessFiles(Out, fileSystemConnector, provider.Connector);
            }
            else
            {
                XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(outPath, "");
                provider.SaveAs(Template, Out, formatter, TemplateProviderExtensions);
            }
        }

        private void ProcessFiles(string templateFileName, FileConnectorBase fileSystemConnector, FileConnectorBase connector)
        {
            var templateFile = ReadProvisioningTemplate.LoadProvisioningTemplateFromFile(templateFileName, null, (e) =>
            {
                WriteError(new ErrorRecord(e, "TEMPLATENOTVALID", ErrorCategory.SyntaxError, null));
            });
            if (Template.Tenant?.AppCatalog != null)
            {
                foreach (var app in Template.Tenant.AppCatalog.Packages)
                {
                    WriteObject($"Processing {app.Src}");
                    AddFile(app.Src, templateFile, fileSystemConnector, connector);
                }
            }
            if (Template.Tenant?.SiteScripts != null)
            {
                foreach (var siteScript in Template.Tenant.SiteScripts)
                {
                    WriteObject($"Processing {siteScript.JsonFilePath}");
                    AddFile(siteScript.JsonFilePath, templateFile, fileSystemConnector, connector);
                }
            }
            if (Template.Localizations != null && Template.Localizations.Any())
            {
                foreach (var location in Template.Localizations)
                {
                    WriteObject($"Processing {location.ResourceFile}");
                    AddFile(location.ResourceFile, templateFile, fileSystemConnector, connector);
                }
            }

            if (Template.WebSettings != null && !String.IsNullOrEmpty(Template.WebSettings.SiteLogo))
            {
                // is it a file?
                var isFile = false;
                using (var fileStream = fileSystemConnector.GetFileStream(Template.WebSettings.SiteLogo))
                {
                    isFile = fileStream != null;
                }
                if (isFile)
                {
                    WriteObject($"Processing {Template.WebSettings.SiteLogo}");
                    AddFile(Template.WebSettings.SiteLogo, templateFile, fileSystemConnector, connector);
                }
            }
            if (Template.Files.Any())
            {
                foreach (var file in Template.Files)
                {
                    WriteObject($"Processing {file.Src}");
                    AddFile(file.Src, templateFile, fileSystemConnector, connector);
                }
            }

            if (templateFile.Connector is ICommitableFileConnector)
            {
                ((ICommitableFileConnector)templateFile.Connector).Commit();
            }
        }

        private void AddFile(string sourceName, ProvisioningTemplate provisioningTemplate, FileConnectorBase fileSystemConnector, FileConnectorBase connector)
        {
            using (var fs = fileSystemConnector.GetFileStream(sourceName))
            {
                var fileName = sourceName.IndexOf("\\") > 0 ? sourceName.Substring(sourceName.LastIndexOf("\\") + 1) : sourceName;
                var folderName = sourceName.IndexOf("\\") > 0 ? sourceName.Substring(0, sourceName.LastIndexOf("\\")) : "";
                provisioningTemplate.Connector.SaveFileStream(fileName, folderName, fs);
            }
        }
    }
}
