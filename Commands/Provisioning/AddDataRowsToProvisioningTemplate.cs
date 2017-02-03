using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet("Add", "PnPDataRowsToProvisioningTemplate")]
    
    [CmdletHelp("Adds datarows to a list inside a PnP Provisioning Template",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Add-PnPDataRowsToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Query '<View></View>' -Fields 'Title','Choice'",
       Remarks = "Adds datarows to a list in an in-memory PnP Provisioning Template",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> Add-PnPDataRowsToProvisioningTemplate -Path template.pnp -List 'PnPTestList' -Query '<View></View>' -Fields 'Title','Choice' -IncludeSecurity",
      Remarks = "Adds datarows to a list in an in-memory PnP Provisioning Template",
       SortOrder = 2)]
    public class AddDataRowsToProvisioningTemplate : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Filename of the .PNP Open XML provisioning template to read from, optionally including full path.")]
        public string Path;

        [Parameter(Mandatory = true, HelpMessage = "The list to query")]
        public ListPipeBind List;

        [Parameter(Mandatory = true, HelpMessage = "The CAML query to execute against the list")]
        public string Query;

        [Parameter(Mandatory = false, HelpMessage = "The fields to retrieve. If not specified all fields will be loaded in the returned list object.")]
        public string[] Fields;

        [Parameter(Mandatory = false, Position = 5, HelpMessage = "A switch to include ObjectSecurity information.")]
        public SwitchParameter IncludeSecurity;

        [Parameter(Mandatory = false, Position = 4, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while loading the template." )]
        public ITemplateProviderExtension[] TemplateProviderExtensions;



        protected override void ExecuteCmdlet()
        {


            if (!System.IO.Path.IsPathRooted(Path))
            {
                Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
            }

            var template = LoadProvisioningTemplate
                    .LoadProvisioningTemplateFromFile(Path,
                    TemplateProviderExtensions);

            if (template == null)
            {
                throw new ApplicationException("Invalid template file!");
            }
            //We will remove a list if it's found so we can get the list

            ListInstance listInstance = template.Lists.Find(l => l.Title == List.Title);
            if (listInstance == null)
            {
                throw new ApplicationException("List does not exist in the template file!");
            }

            List spList = List.GetList(SelectedWeb);
            ClientContext.Load(spList, l => l.RootFolder, l => l.HasUniqueRoleAssignments);
            ClientContext.ExecuteQueryRetry();

            CamlQuery query = new CamlQuery();

            var viewFieldsStringBuilder = new StringBuilder();
            if (Fields != null)
            {
                viewFieldsStringBuilder.Append("<ViewFields>");
                foreach (var field in Fields)
                {
                    viewFieldsStringBuilder.AppendFormat("<FieldRef Name='{0}'/>", field);
                }
                viewFieldsStringBuilder.Append("</ViewFields>");
            }

            query.ViewXml = string.Format("<View>{0}{1}</View>", Query, viewFieldsStringBuilder);
            var listItems = spList.GetItems(query);

            ClientContext.Load(listItems, lI => lI.Include(l => l.HasUniqueRoleAssignments, l => l.ContentType.StringId));
            ClientContext.ExecuteQueryRetry();

            Microsoft.SharePoint.Client.FieldCollection fieldCollection = spList.Fields;
            ClientContext.Load(fieldCollection, fs => fs.Include(f => f.InternalName, f => f.FieldTypeKind));
            ClientContext.ExecuteQueryRetry();

            var rows = new DataRowCollection(template);
            foreach (var listItem in listItems)
            {
                //Make sure we don't pull Folders.. Of course this won't work
                if (listItem.ServerObjectIsNull == false)
                {

                    ClientContext.Load(listItem);
                    ClientContext.ExecuteQueryRetry();
                    if (!(listItem.FileSystemObjectType == FileSystemObjectType.Folder))
                    {
                        DataRow row = new DataRow();
                        if (IncludeSecurity && listItem.HasUniqueRoleAssignments)
                        {
                            row.Security.ClearSubscopes = true;
                            row.Security.CopyRoleAssignments = false;

                            var roleAssignments = listItem.RoleAssignments;
                            ClientContext.Load(roleAssignments);
                            ClientContext.ExecuteQueryRetry();

                            ClientContext.Load(roleAssignments, r => r.Include(a => a.Member.LoginName, a => a.Member, a => a.RoleDefinitionBindings));
                            ClientContext.ExecuteQueryRetry();

                            foreach (var roleAssignment in roleAssignments)
                            {
                                var principalName = roleAssignment.Member.LoginName;
                                var roleBindings = roleAssignment.RoleDefinitionBindings;
                                foreach (var roleBinding in roleBindings)
                                {
                                    row.Security.RoleAssignments.Add(new OfficeDevPnP.Core.Framework.Provisioning.Model.RoleAssignment() { Principal = principalName, RoleDefinition = roleBinding.Name });
                                }
                            }
                        }
                        if (Fields != null)
                        {
                            foreach (var field in Fields)
                            {
                                Microsoft.SharePoint.Client.Field dataField = fieldCollection.FirstOrDefault(f => f.InternalName == field);

                                if (dataField != null)
                                {
                                    var defaultFieldValue = listItem[field] as string;
                                    row.Values.Add(field, defaultFieldValue);

                                }


                            }
                        }
                        else
                        {
                            //All fields are added
                            foreach (var field in fieldCollection)
                            {
                                var fldKey = (from f in listItem.FieldValues.Keys where f == field.InternalName select f).FirstOrDefault();
                                if (!string.IsNullOrEmpty(fldKey))
                                {
                                    var fieldValue = listItem[field.InternalName] as string;
                                    row.Values.Add(field.InternalName, fieldValue);
                                }
                            }
                        }

                        rows.Add(row);
                    }
                }
            }
            template.Lists.Remove(listInstance);
            listInstance.DataRows.AddRange(rows);
            template.Lists.Add(listInstance);

            var outFileName = System.IO.Path.GetFileName(Path);
            var outPath = new FileInfo(Path).DirectoryName;

            var fileSystemConnector = new FileSystemConnector(outPath, "");
            var formatter = XMLPnPSchemaFormatter.LatestFormatter;
            var extension = new FileInfo(Path).Extension.ToLowerInvariant();
            if (extension == ".pnp")
            {
                XMLTemplateProvider provider = new XMLOpenXMLTemplateProvider(new OpenXMLConnector(Path, fileSystemConnector));
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
