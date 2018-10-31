using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning.Site
{
    [Cmdlet(VerbsCommon.Remove, "PnPFileFromSiteTemplate")]
    [Alias("Remove-PnPFileFromProvisioningTemplate")]
    [CmdletHelp("Removes a file from a PnP Site Template",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Remove-PnPFileFromSiteTemplate -Path template.pnp -FilePath filePath",
       Remarks = "Removes a file from an in-memory PnP Provisioning Template",
       SortOrder = 1)]
    public class RemoveFileFromSiteTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename to read the template from, optionally including full path.")]
        public string Path;

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "The relative File Path of the file to remove from the in-memory template")]
        public string FilePath;

        [Parameter(Mandatory = false, Position = 2, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while saving the template.")]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        protected override void ProcessRecord()
        {
            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }
            // Load the template
            ProvisioningTemplate template = ReadSiteTemplate
                .LoadProvisioningTemplateFromFile(Path,
                TemplateProviderExtensions);

            if (template == null)
            {
                throw new ApplicationException("Invalid template file!");
            }

            var fileToRemove = template.Files.FirstOrDefault(f => f.Src == FilePath);
            if (fileToRemove != null)
            {
                template.Files.Remove(fileToRemove);
                template.Connector.DeleteFile(FilePath);

                if (template.Connector is ICommitableFileConnector)
                {
                    ((ICommitableFileConnector)template.Connector).Commit();
                }

                // Determine the output file name and path
                var outFileName = System.IO.Path.GetFileName(Path);
                var outPath = new FileInfo(Path).DirectoryName;

                var fileSystemConnector = new FileSystemConnector(outPath, "");
                var formatter = XMLPnPSchemaFormatter.LatestFormatter;
                var extension = new FileInfo(Path).Extension.ToLowerInvariant();
                if (extension == ".pnp")
                {
                    XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(outPath, fileSystemConnector));
                    var templateFileName = outFileName.Substring(0, outFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";

                    provider.SaveAs(template, templateFileName, formatter, TemplateProviderExtensions);
                }
                else
                {
                    XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(Path, "");
                    provider.SaveAs(template, Path, formatter, TemplateProviderExtensions);
                }
            }
        }
    }
}
