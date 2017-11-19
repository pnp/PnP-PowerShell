using System.Collections;
using System.IO;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.SharePoint.Client.Taxonomy;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet(VerbsCommon.Add, "PnPFile")]
    [CmdletHelp("Uploads a file to Web",
        Category = CmdletHelpCategory.Files,
        OutputType = typeof(Microsoft.SharePoint.Client.File),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.file.aspx")]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -Path c:\temp\company.master -Folder ""_catalogs/masterpage""",
        Remarks = "This will upload the file company.master to the masterpage catalog",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -Path .\displaytemplate.html -Folder ""_catalogs/masterpage/display templates/test""",
        Remarks = "This will upload the file displaytemplate.html to the test folder in the display templates folder. If the test folder does not exist it will create it.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -Path .\sample.doc -Folder ""Shared Documents"" -Values @{Modified=""1/1/2016""}",
        Remarks = "This will upload the file sample.doc to the Shared Documnets folder. After uploading it will set the Modified date to 1/1/2016.",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -FileName sample.doc -Folder ""Shared Documents"" -Stream $fileStream -Values @{Modified=""1/1/2016""}",
        Remarks = "This will add a file sample.doc with the contents of the stream into the Shared Documents folder. After adding it will set the Modified date to 1/1/2016.",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -FileName sample.doc -Folder ""Shared Documents"" -ContentType ""Document"" -Values @{Modified=""1/1/2016""}",
        Remarks = "This will add a file sample.doc to the Shared Documents folder, with a ContentType of 'Documents'. After adding it will set the Modified date to 1/1/2016.",
        SortOrder = 5)]
    [CmdletExample(
        Code = @"PS:> Add-PnPFile -FileName sample.docx -Folder ""Documents"" -Values @{Modified=""1/1/2016""; Created=""1/1/2017""; Editor=23}",
        Remarks = "This will add a file sample.docx to the Documents folder and will set the Modified date to 1/1/2016, Created date to 1/1/2017 and the Modified By field to the user with ID 23. To find out about the proper user ID to relate to a specific user, use Get-PnPUser.",
        SortOrder = 6)]

    public class AddFile : PnPWebCmdlet
    {
        private const string ParameterSet_ASFILE = "Upload file";
        private const string ParameterSet_ASSTREAM = "Upload file from stream";

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_ASFILE, HelpMessage = "The local file path.")]
        public string Path = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "The destination folder in the site")]
        public string Folder = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_ASSTREAM, HelpMessage = "Name for file")]
        public string FileName = string.Empty;
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_ASSTREAM, HelpMessage = "Stream with the file contents")]
        public Stream Stream;


        [Parameter(Mandatory = false, HelpMessage = "If versioning is enabled, this will check out the file first if it exists, upload the file, then check it in again.")]
        public SwitchParameter Checkout;

        [Parameter(Mandatory = false, HelpMessage = "The comment added to the checkin.")]
        public string CheckInComment = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Will auto approve the uploaded file.")]
        public SwitchParameter Approve;

        [Parameter(Mandatory = false, HelpMessage = "The comment added to the approval.")]
        public string ApproveComment = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Will auto publish the file.")]
        public SwitchParameter Publish;

        [Parameter(Mandatory = false, HelpMessage = "The comment added to the publish action.")]
        public string PublishComment = string.Empty;

        [Parameter(Mandatory = false)]
        public SwitchParameter UseWebDav;

        [Parameter(Mandatory = false, HelpMessage = "Use the internal names of the fields when specifying field names")]
        public Hashtable Values;

        [Parameter(Mandatory = false, HelpMessage = "Use to assign a ContentType to the file.")]
        public ContentTypePipeBind ContentType;

        protected override void ExecuteCmdlet()
        {

            if (ParameterSetName == ParameterSet_ASFILE)
            {
                if (!System.IO.Path.IsPathRooted(Path))
                {
                    Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
                }
                FileName = System.IO.Path.GetFileName(Path);
            }

            SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            var folder = SelectedWeb.EnsureFolder(SelectedWeb.RootFolder, Folder);
            var fileUrl = UrlUtility.Combine(folder.ServerRelativeUrl, FileName);

            ContentType targetContentType = null;
            //Check to see if the Content Type exists.. If it doesn't we are going to throw an exception and block this transaction right here.
            if (ContentType != null)
            {

                try
                {
                    var list = SelectedWeb.GetListByUrl(folder.ServerRelativeUrl);


                    if (!string.IsNullOrEmpty(ContentType.Id))
                    {
                        targetContentType = list.GetContentTypeById(ContentType.Id);
                    }
                    else if (!string.IsNullOrEmpty(ContentType.Name))
                    {
                        targetContentType = list.GetContentTypeByName(ContentType.Name);
                    }
                    else if (ContentType.ContentType != null)
                    {
                        targetContentType = ContentType.ContentType;
                    }
                    if (targetContentType == null)
                    {
                        ThrowTerminatingError(new ErrorRecord(new ArgumentException($"Content Type Argument: {ContentType} does not exist in the list: {list.Title}"), "CONTENTTYPEDOESNOTEXIST", ErrorCategory.InvalidArgument, this));
                    }
                }
                catch
                {
                    ThrowTerminatingError(new ErrorRecord(new ArgumentException($"The Folder specified ({folder.ServerRelativeUrl}) does not have a corresponding List, the -ContentType parameter is not valid."), "RELATIVEPATHNOTINLIBRARY", ErrorCategory.InvalidArgument, this));
                }
            }

            // Check if the file exists
            if (Checkout)
            {
                try
                {
                    var existingFile = SelectedWeb.GetFileByServerRelativeUrl(fileUrl);
                    existingFile.EnsureProperty(f => f.Exists);
                    if (existingFile.Exists)
                    {
                        SelectedWeb.CheckOutFile(fileUrl);
                    }
                }
                catch
                { // Swallow exception, file does not exist 
                }
            }
            Microsoft.SharePoint.Client.File file;
            if (ParameterSetName == ParameterSet_ASFILE)
            {

                file = folder.UploadFile(FileName, Path, true);
            }
            else
            {
                file = folder.UploadFile(FileName, Stream, true);
            }

            if (Values != null)
            {
                var item = file.ListItemAllFields;

                SetFieldValues(SelectedWeb, item, Values);


                foreach (var key in Values.Keys)
                {
                    item[key as string] = Values[key];
                }

                item.Update();

                ClientContext.ExecuteQueryRetry();
            }
            if (ContentType != null)
            {
                var item = file.ListItemAllFields;
                item["ContentTypeId"] = targetContentType.Id.StringValue;
                item.Update();
                ClientContext.ExecuteQueryRetry();
            }

            if (Checkout)
                SelectedWeb.CheckInFile(fileUrl, CheckinType.MajorCheckIn, CheckInComment);


            if (Publish)
                SelectedWeb.PublishFile(fileUrl, PublishComment);

            if (Approve)
                SelectedWeb.ApproveFile(fileUrl, ApproveComment);

            WriteObject(file);
        }

        private void SetFieldValues(Web currentWeb, ListItem item, Hashtable valuesToSet)
        {
            var context = currentWeb.Context as ClientContext;
            List list = item.ParentList;
            Hashtable values = valuesToSet ?? new Hashtable();
            // Load all list fields and their types

            var fields = context.LoadQuery(list.Fields.Include(f => f.Id, f => f.InternalName, f => f.Title, f => f.TypeAsString));
            context.ExecuteQueryRetry();

            foreach (var key in values.Keys)
            {
                var field = fields.FirstOrDefault(f => f.InternalName == key as string || f.Title == key as string);
                if (field != null)
                {
                    switch (field.TypeAsString)
                    {
                        case "User":
                        case "UserMulti":
                            {
                                var userValues = new List<FieldUserValue>();

                                var value = values[key];
                                if (value.GetType().IsArray)
                                {
                                    foreach (var arrayItem in value as object[])
                                    {
                                        int userId;
                                        if (!int.TryParse(arrayItem as string, out userId))
                                        {
                                            var user = currentWeb.EnsureUser(arrayItem as string);
                                            context.Load(user);
                                            context.ExecuteQueryRetry();
                                            userValues.Add(new FieldUserValue() { LookupId = user.Id });
                                        }
                                        else
                                        {
                                            userValues.Add(new FieldUserValue() { LookupId = userId });
                                        }
                                    }
                                    item[key as string] = userValues.ToArray();
                                }
                                else
                                {
                                    int userId;
                                    if (!int.TryParse(value as string, out userId))
                                    {
                                        var user = currentWeb.EnsureUser(value as string);
                                        context.Load(user);
                                        context.ExecuteQueryRetry();
                                        item[key as string] = new FieldUserValue() { LookupId = user.Id };
                                    }
                                    else
                                    {
                                        item[key as string] = new FieldUserValue() { LookupId = userId };
                                    }
                                }
#if !ONPREMISES
                                item.SystemUpdate();
#else
                                item.Update();
#endif
                                break;
                            }
                        case "TaxonomyFieldType":
                        case "TaxonomyFieldTypeMulti":
                            {
                                var value = values[key];
                                if (value.GetType().IsArray)
                                {
                                    var taxSession = context.Site.GetTaxonomySession();
                                    var terms = new List<KeyValuePair<Guid, string>>();
                                    foreach (var arrayItem in value as object[])
                                    {
                                        TaxonomyItem taxonomyItem;
                                        Guid termGuid = Guid.Empty;
                                        if (!Guid.TryParse(arrayItem as string, out termGuid))
                                        {
                                            // Assume it's a TermPath
                                            taxonomyItem = context.Site.GetTaxonomyItemByPath(arrayItem as string);
                                        }
                                        else
                                        {
                                            taxonomyItem = taxSession.GetTerm(termGuid);
                                            context.Load(taxonomyItem);
                                            context.ExecuteQueryRetry();
                                        }



                                        terms.Add(new KeyValuePair<Guid, string>(taxonomyItem.Id, taxonomyItem.Name));
                                    }

                                    TaxonomyField taxField = context.CastTo<TaxonomyField>(field);

                                    taxField.EnsureProperty(tf => tf.AllowMultipleValues);

                                    if (taxField.AllowMultipleValues)
                                    {
                                        var termValuesString = String.Empty;
                                        foreach (var term in terms)
                                        {
                                            termValuesString += "-1;#" + term.Value + "|" + term.Key.ToString("D") + ";#";
                                        }

                                        termValuesString = termValuesString.Substring(0, termValuesString.Length - 2);

                                        var newTaxFieldValue = new TaxonomyFieldValueCollection(context, termValuesString, taxField);
                                        taxField.SetFieldValueByValueCollection(item, newTaxFieldValue);
#if !ONPREMISES
                                        item.SystemUpdate();
#else
                                        item.Update();
#endif
                                        context.ExecuteQueryRetry();
                                    }
                                    else
                                    {
                                        WriteWarning($@"You are trying to set multiple values in a single value field. Skipping values for field ""{field.InternalName}""");
                                    }
                                }
                                else
                                {
                                    Guid termGuid = Guid.Empty;
                                    if (!Guid.TryParse(value as string, out termGuid))
                                    {
                                        // Assume it's a TermPath
                                        var taxonomyItem = context.Site.GetTaxonomyItemByPath(value as string);
                                        termGuid = taxonomyItem.Id;
                                    }
                                    item[key as string] = termGuid.ToString();
                                }
#if !ONPREMISES
                                item.SystemUpdate();
#else
                                        item.Update();
#endif
                                break;
                            }
                        case "Lookup":
                        case "LookupMulti":
                            {
                                int[] multiValue;
                                if (values[key] is Array)
                                {
                                    var arr = (object[])values[key];
                                    multiValue = new int[arr.Length];
                                    for (int i = 0; i < arr.Length; i++)
                                    {
                                        multiValue[i] = int.Parse(arr[i].ToString());
                                    }
                                }
                                else
                                {
                                    string valStr = values[key].ToString();
                                    multiValue = valStr.Split(',', ';').Select(int.Parse).ToArray();
                                }

                                var newVals = multiValue.Select(id => new FieldLookupValue { LookupId = id }).ToArray();

                                FieldLookup lookupField = context.CastTo<FieldLookup>(field);
                                lookupField.EnsureProperty(lf => lf.AllowMultipleValues);
                                if (!lookupField.AllowMultipleValues && newVals.Length > 1)
                                {
                                    WriteWarning($@"You are trying to set multiple values in a single value field. Skipping values for field ""{field.InternalName}""");
                                }

                                item[key as string] = newVals;
#if !ONPREMISES
                                item.SystemUpdate();
#else
                                        item.Update();
#endif
                                break;
                            }
                        default:
                            {
                                item[key as string] = values[key];
#if !ONPREMISES
                                item.SystemUpdate();
#else
                                item.Update();
#endif
                                break;
                            }
                    }
                }
                else
                {
                    ThrowTerminatingError(new ErrorRecord(new Exception("Field not present in list"), "FIELDNOTINLIST", ErrorCategory.InvalidData, key));
                }
            }
        }
    }
}
