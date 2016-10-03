using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet("Load", "SPOProvisioningTemplate")]
    [CmdletHelp("Loads a PnP file from the file systems",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
       Code = @"PS:> Load-SPOProvisioningTemplate -Path template.pnp",
       Remarks = "Loads a PnP file from the file systems",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> Load-SPOProvisioningTemplate -Path template.pnp -TemplateProviderExtensions $extensions",
       Remarks = "Loads a PnP file from the file systems using some custom template provider extenions while loading the file.",
       SortOrder = 2)]
    public class LoadProvisioningTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename to read from, optionally including full path.")]
        public string Path;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while loading the template.")]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        protected override void ProcessRecord()
        {
            // Prepare the File Connector
            FileConnectorBase fileConnector;
            string templateFileName = System.IO.Path.GetFileName(Path);

            // Prepare the template path
            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }
            var fileInfo = new FileInfo(Path);
            fileConnector = new FileSystemConnector(fileInfo.DirectoryName, "");

            ProvisioningTemplate provisioningTemplate;

            // Load the provisioning template file
            Stream stream = fileConnector.GetFileStream(templateFileName);
            var isOpenOfficeFile = ApplyProvisioningTemplate.IsOpenOfficeFile(stream);

            XMLTemplateProvider provider;
            if (isOpenOfficeFile)
            {
                provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(templateFileName, fileConnector));
                templateFileName = templateFileName.Substring(0, templateFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";
            }
            else
            {
                provider = new XMLFileSystemTemplateProvider(fileConnector.Parameters[FileConnectorBase.CONNECTIONSTRING] + "", "");
            }

            provisioningTemplate = provider.GetTemplate(templateFileName, TemplateProviderExtensions);

            // Return the result
            WriteObject(provisioningTemplate);
        }
    }
}
