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
using System.Linq;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Set, "SPOProvisioningTemplateMetadata")]
    [CmdletHelp("Sets metadata of a provisioning template",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.xml -TemplateDisplayName ""DisplayNameValue""",
     Remarks = @"Sets the DisplayName property of a provisioning template in XML format.
",
     SortOrder = 1)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.pnp -TemplateDisplayName ""DisplayNameValue""",
     Remarks = @"Sets the DisplayName property of a provisioning template in Office Open XML format.
",
     SortOrder = 2)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.xml -TemplateImagePreviewUrl ""Full URL of the Image Preview""",
     Remarks = @"Sets the DisplayName property of a provisioning template in XML format.
",
     SortOrder = 3)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.pnp -TemplateImagePreviewUrl ""Full URL of the Image Preview""",
     Remarks = @"Sets the DisplayName property of a provisioning template in Office Open XML format.
",
     SortOrder = 4)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.xml -TemplateProperties @{""Property1"" = ""Test Value 1""; ""Property2""=""Test Value 2""}",
     Remarks = @"Sets the DisplayName property of a provisioning template in XML format.
",
     SortOrder = 5)]
    [CmdletExample(
     Code = @"PS:> Set-SPOProvisioningTemplateMetadata -Path template.pnp -TemplateProperties @{""Property1"" = ""Test Value 1""; ""Property2""=""Test Value 2""}",
     Remarks = @"Sets the DisplayName property of a provisioning template in Office Open XML format.
",
     SortOrder = 6)]


    public class SetProvisioningTemplateMetadata : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, HelpMessage = "Path to the xml or pnp file containing the provisioning template.")]
        public string Path;

        [Parameter(Mandatory = false, HelpMessage = "It can be used to specify the DisplayName of the template file that will be updated.")]
        public string TemplateDisplayName;

        [Parameter(Mandatory = false, HelpMessage = "It can be used to specify the ImagePreviewUrl of the template file that will be updated.")]
        public string TemplateImagePreviewUrl;

        [Parameter(Mandatory = false, HelpMessage = "It can be used to specify custom Properties for the template file that will be updated.")]
        public Hashtable TemplateProperties;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while extracting a template.")]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.EnsureProperty(w => w.Url);
            bool templateFromFileSystem = !Path.ToLower().StartsWith("http");
            FileConnectorBase fileConnector;
            string templateFileName = System.IO.Path.GetFileName(Path);
            if (templateFromFileSystem)
            {
                if (!System.IO.Path.IsPathRooted(Path))
                {
                    Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
                }
                FileInfo fileInfo = new FileInfo(Path);
                fileConnector = new FileSystemConnector(fileInfo.DirectoryName, "");
            }
            else
            {                
                Uri fileUri = new Uri(Path);
                var webUrl = Microsoft.SharePoint.Client.Web.WebUrlFromFolderUrlDirect(this.ClientContext, fileUri);
                var templateContext = this.ClientContext.Clone(webUrl.ToString());

                string library = Path.ToLower().Replace(templateContext.Url.ToLower(), "").TrimStart('/');
                int idx = library.IndexOf("/");
                library = library.Substring(0, idx);
                fileConnector = new SharePointConnector(templateContext, templateContext.Url, library);
            }
            XMLTemplateProvider provider = null;
            ProvisioningTemplate provisioningTemplate = null;
            Stream stream = fileConnector.GetFileStream(templateFileName);
            var isOpenOfficeFile = IsOpenOfficeFile(stream);
            if (isOpenOfficeFile)
            {
                provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(templateFileName, fileConnector));
                templateFileName = templateFileName.Substring(0, templateFileName.LastIndexOf(".")) + ".xml";
            }
            else
            {
                if (templateFromFileSystem)
                {
                    provider = new XMLFileSystemTemplateProvider(fileConnector.Parameters[FileConnectorBase.CONNECTIONSTRING] + "", "");
                }
                else
                {
                    throw new NotSupportedException("Only .pnp package files are supported from a SharePoint library");
                }
            }
            provisioningTemplate = provider.GetTemplate(templateFileName, TemplateProviderExtensions);

            if (provisioningTemplate == null) return;

            GetProvisioningTemplate.SetTemplateMetadata(provisioningTemplate, TemplateDisplayName, TemplateImagePreviewUrl, TemplateProperties);

            provider.SaveAs(provisioningTemplate, templateFileName, TemplateProviderExtensions);
        }

        private bool IsOpenOfficeFile(Stream stream)
        {
            bool istrue = false;
            // SIG 50 4B 03 04 14 00

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
            return istrue;
        }
    }
}
