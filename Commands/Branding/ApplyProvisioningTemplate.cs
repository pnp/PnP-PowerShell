using System;
using System.IO;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using System.Collections;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet("Apply", "SPOProvisioningTemplate")]
    [CmdletHelp("Applies a provisioning template to a web",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
     Code = @"PS:> Apply-SPOProvisioningTemplate -Path template.xml",
     Remarks = @"Applies a provisioning template in XML format to the current web.
",
     SortOrder = 1)]
    [CmdletExample(
     Code = @"PS:> Apply-SPOProvisioningTemplate -Path template.xml -ResourceFolder c:\provisioning\resources",
     Remarks = @"Applies a provisioning template in XML format to the current web. Any resources like files that are referenced in the template will be retrieved from the folder as specified with the ResourceFolder parameter.
",
     SortOrder = 2)]

    [CmdletExample(
     Code = @"PS:> Apply-SPOProvisioningTemplate -Path template.xml -Parameters @{""ListTitle""=""Projects"";""parameter2""=""a second value""}",
     Remarks = @"Applies a provisioning template in XML format to the current web. It will populate the parameter in the template the values as specified and in the template you can refer to those values with the {parameter:<key>} token.

For instance with the example above, specifying {parameter:ListTitle} in your template will translate to 'Projects' when applying the template. These tokens can be used in most string values in a template.",
     SortOrder = 3)]

    [CmdletExample(
     Code = @"PS:> Apply-SPOProvisioningTemplate -Path template.xml -Handlers Lists, SiteSecurity",
     Remarks = @"Applies a provisioning template in XML format to the current web. It will only apply the lists and site security part of the template.",
     SortOrder = 4)]

    public class ApplyProvisioningTemplate : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, HelpMessage = "Path to the xml file containing the provisioning template.")]
        public string Path;

        [Parameter(Mandatory = false, HelpMessage = "Root folder where resources/files that are being referenced in the template are located. If not specified the same folder as where the provisioning template is located will be used.")]
        public string ResourceFolder;

        [Parameter(Mandatory = false, HelpMessage = "Specify this parameter if you want to overwrite and/or create properties that are known to be system entries (starting with vti_, dlc_, etc.)")]
        public SwitchParameter OverwriteSystemPropertyBagValues;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify parameters that can be referred to in the template by means of the {parameter:<Key>} token. See examples on how to use this parameter.")]
        public Hashtable Parameters;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to only process a specific part of the template. Notice that this might fail, as some of the handlers require other artifacts in place if they are not part of what your applying.")]
        public Handlers Handlers;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to run all handlers, excluding the ones specified.")]
        public Handlers ExcludeHandlers;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperty(w => w.Url);

            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }
            if (!string.IsNullOrEmpty(ResourceFolder))
            {
                if (!System.IO.Path.IsPathRooted(ResourceFolder))
                {
                    ResourceFolder = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, ResourceFolder);
                }
            }

            FileInfo fileInfo = new FileInfo(Path);

            XMLTemplateProvider provider = null;
            ProvisioningTemplate provisioningTemplate = null;
            var isOpenOfficeFile = IsOpenOfficeFile(Path);
            if (isOpenOfficeFile)
            {
                var fileSystemconnector = new FileSystemConnector(fileInfo.DirectoryName, "");
                provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(fileInfo.Name, fileSystemconnector));
                var fileName = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf(".")) + ".xml";
                provisioningTemplate = provider.GetTemplate(fileName);
            }
            else
            {
                provider = new XMLFileSystemTemplateProvider(fileInfo.DirectoryName, "");
                provisioningTemplate = provider.GetTemplate(fileInfo.Name);
            }

            if (provisioningTemplate != null)
            {
                if (isOpenOfficeFile)
                {
                    provisioningTemplate.Connector = provider.Connector;
                }
                else
                {
                    FileSystemConnector fileSystemConnector = null;
                    if(ResourceFolder != null)
                    {
                        fileSystemConnector = new FileSystemConnector(ResourceFolder, "");
                        provisioningTemplate.Connector = fileSystemConnector;
                    } else
                    {
                        provisioningTemplate.Connector = provider.Connector;
                    }
                }

                if (Parameters != null)
                {
                    foreach (var parameter in Parameters.Keys)
                    {
                        if (provisioningTemplate.Parameters.ContainsKey(parameter.ToString()))
                        {
                            provisioningTemplate.Parameters[parameter.ToString()] = Parameters[parameter].ToString();
                        }
                        else
                        {
                            provisioningTemplate.Parameters.Add(parameter.ToString(), Parameters[parameter].ToString());
                        }
                    }
                }

                var applyingInformation = new ProvisioningTemplateApplyingInformation();

                if (this.MyInvocation.BoundParameters.ContainsKey("Handlers"))
                {
                    applyingInformation.HandlersToProcess = Handlers;
                }
                if (this.MyInvocation.BoundParameters.ContainsKey("ExcludeHandlers"))
                {
                    foreach (var handler in (OfficeDevPnP.Core.Framework.Provisioning.Model.Handlers[])Enum.GetValues(typeof(Handlers)))
                    {
                        if (!ExcludeHandlers.Has(handler) && handler != Handlers.All)
                        {
                            Handlers = Handlers | handler;
                        }
                    }
                    applyingInformation.HandlersToProcess = Handlers;
                }

                applyingInformation.ProgressDelegate = (message, step, total) =>
                {
                    WriteProgress(new ProgressRecord(0, string.Format("Applying template to {0}", SelectedWeb.Url), message) { PercentComplete = (100 / total) * step });
                };

                applyingInformation.MessagesDelegate = (message, type) =>
                {
                    if (type == ProvisioningMessageType.Warning)
                    {
                        WriteWarning(message);
                    }
                };

                applyingInformation.OverwriteSystemPropertyBagValues = OverwriteSystemPropertyBagValues;
                SelectedWeb.ApplyProvisioningTemplate(provisioningTemplate, applyingInformation);
            }
        }


        private bool IsOpenOfficeFile(string path)
        {
            bool istrue = false;
            // SIG 50 4B 03 04 14 00
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[6];

                int n = stream.Read(bytes, 0, 6);
                var signature = string.Empty;
                foreach (var b in bytes)
                {
                    signature += b.ToString("X2");
                }
                if (signature == "504B03041400")
                {
                    istrue = true;
                }

            }
            return istrue;
        }
    }
}
