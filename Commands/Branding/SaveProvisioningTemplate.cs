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
    [Cmdlet("Save", "SPOProvisioningTemplate")]
    [CmdletHelp("Saves a PnP file to the file systems",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
       Code = @"PS:> Save-SPOProvisioningTemplate -InputInstance $template -Out .\template.pnp",
       Remarks = "Saves a PnP file to the file systems",
       SortOrder = 1)]
    public class SaveProvisioningTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Allows you to provide an in-memory instance of the ProvisioningTemplate type of the PnP Core Component. When using this parameter, the -Out parameter refers to the path for saving the template and storing any supporting file for the template.")]
        public ProvisioningTemplate InputInstance;

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename to write to, optionally including full path.")]
        public string Out;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while saving a template.")]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        protected override void ProcessRecord()
        {
            // Determine the output file name and path
            string outFileName = System.IO.Path.GetFileName(Out);
            string outPath = new System.IO.FileInfo(Out).DirectoryName;

            // Determine if it is an .XML or a .PNP file
            var extension = "";
            if (outFileName != null)
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
                XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(
                      Out, fileSystemConnector);
                var templateFileName = outFileName.Substring(0, outFileName.LastIndexOf(".", StringComparison.Ordinal)) + ".xml";

                provider.SaveAs(InputInstance, templateFileName, formatter, TemplateProviderExtensions);
            }
            else
            {
                XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(outPath, "");
                provider.SaveAs(InputInstance, Out, formatter, TemplateProviderExtensions);
            }
        }
    }
}
