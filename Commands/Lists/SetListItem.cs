using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
// IMPORTANT: If you make changes to this cmdlet, also make the similar/same changes to the Add-PnPListItem Cmdlet

namespace SharePointPnP.PowerShell.Commands.Lists
{
    [Cmdlet(VerbsCommon.Set, "PnPListItem")]
    [CmdletHelp("Updates a list item",
        Category = CmdletHelpCategory.Lists,
        OutputType = typeof(ListItem),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.listitem.aspx")]
    [CmdletExample(
        Code = @"Set-PnPListItem -List ""Demo List"" -Identity 1 -Values @{""Title"" = ""Test Title""; ""Category""=""Test Category""}",
        Remarks = @"Sets fields value in the list item with ID 1 in the ""Demo List"". It sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"Set-PnPListItem -List ""Demo List"" -Identity 1 -ContentType ""Company"" -Values @{""Title"" = ""Test Title""; ""Category""=""Test Category""}",
        Remarks = @"Sets fields value in the list item with ID 1 in the ""Demo List"". It sets the content type of the item to ""Company"" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"Set-PnPListItem -List ""Demo List"" -Identity $item -Values @{""Title"" = ""Test Title""; ""Category""=""Test Category""}",
        Remarks = @"Sets fields value in the list item which has been retrieved by for instance Get-PnPListItem. It sets the content type of the item to ""Company"" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.",
        SortOrder = 3)]
    public class SetListItem : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID, Title or Url of the list.")]
        public ListPipeBind List;

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The ID of the listitem, or actual ListItem object")]
        public ListItemPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Specify either the name, ID or an actual content type")]
        public ContentTypePipeBind ContentType;

        [Parameter(Mandatory = false, HelpMessage = "Use the internal names of the fields when specifying field names." +
                                                    "\n\nSingle line of text: -Values @{\"TextField\" = \"Title New\"}" +
                                                    "\n\nMultiple lines of text: -Values @{\"MultiTextField\" = \"New text\\n\\nMore text\"}" +
                                                    "\n\nRich text: -Values @{\"MultiTextField\" = \"<strong>New</strong> text\"}" +
            "\n\nChoice: -Values @{\"ChoiceField\" = \"Value 1\"}" +
            "\n\nNumber: -Values @{\"NumberField\" = \"10\"}" +
            "\n\nCurrency: -Values @{\"NumberField\" = \"10\"}" +
            "\n\nCurrency: -Values @{\"CurrencyField\" = \"10\"}" +
            "\n\nDate and Time: -Values @{\"DateAndTimeField\" = \"03/13/2015 14:16\"}" +
            "\n\nLookup (id of lookup value): -Values @{\"LookupField\" = \"2\"}" +
            "\n\nMulti value lookup (id of lookup values as array 1): -Values @{\"MultiLookupField\" = \"1\",\"2\"}" +
            "\n\nMulti value lookup (id of lookup values as array 2): -Values @{\"MultiLookupField\" = 1,2}" +
            "\n\nMulti value lookup (id of lookup values as string): -Values @{\"MultiLookupField\" = \"1,2\"}" +
            "\n\nYes/No: -Values @{\"YesNoField\" = $false}" +
            "\n\nPerson/Group (id of user/group in Site User Info List or email of the user, seperate multiple values with a comma): -Values @{\"PersonField\" = \"user1@domain.com\",\"21\"}" +
            "\n\nManaged Metadata (single value with path to term): -Values @{\"MetadataField\" = \"CORPORATE|DEPARTMENTS|FINANCE\"}" +
            "\n\nManaged Metadata (single value with id of term): -Values @{\"MetadataField\" = \"fe40a95b-2144-4fa2-b82a-0b3d0299d818\"} with Id of term" +
            "\n\nManaged Metadata (multiple values with paths to terms): -Values @{\"MetadataField\" = (\"CORPORATE|DEPARTMENTS|FINANCE\",\"CORPORATE|DEPARTMENTS|HR\")}" +
            "\n\nManaged Metadata (multiple values with ids of terms): -Values @{\"MetadataField\" = (\"fe40a95b-2144-4fa2-b82a-0b3d0299d818\",\"52d88107-c2a8-4bf0-adfa-04bc2305b593\")}" +
            "\n\nHyperlink or Picture: -Values @{\"HyperlinkField\" = \"https://github.com/OfficeDev/, OfficePnp\"}")]
        public Hashtable Values;

#if !ONPREMISES
        [Parameter(Mandatory = false, HelpMessage = "Update the item without creating a new version.")]
        public SwitchParameter SystemUpdate;
#endif

        protected override void ExecuteCmdlet()
        {
            List list = null;
            if (List != null)
            {
                list = List.GetList(SelectedWeb);
            }
            if (list != null)
            {
                var item = Identity.GetListItem(list);

                if (ContentType != null)
                {
                    ContentType ct = null;
                    if (ContentType.ContentType == null)
                    {
                        if (ContentType.Id != null)
                        {
                            ct = SelectedWeb.GetContentTypeById(ContentType.Id, true);
                        }
                        else if (ContentType.Name != null)
                        {
                            ct = SelectedWeb.GetContentTypeByName(ContentType.Name, true);
                        }
                    }
                    else
                    {
                        ct = ContentType.ContentType;
                    }
                    if (ct != null)
                    {
                        ct.EnsureProperty(w => w.StringId);

                        item["ContentTypeId"] = ct.StringId;
                        item.Update();
                        ClientContext.ExecuteQueryRetry();
                    }
                }
                if (Values != null)
                {
#if !ONPREMISES
                    item = ListItemHelper.UpdateListItem(item, Values, SystemUpdate, (warning) =>
                      {
                          WriteWarning(warning);
                      },
                      (terminatingErrorMessage,terminatingErrorCode) =>
                      {
                          ThrowTerminatingError(new ErrorRecord(new Exception(terminatingErrorMessage), terminatingErrorCode, ErrorCategory.InvalidData, this));
                      }
                      );
#else
                    item = ListItemHelper.UpdateListItem(item, Values, false, (warning) =>
                      {
                          WriteWarning(warning);
                      },
                      (terminatingErrorMessage,terminatingErrorCode) =>
                      {
                          ThrowTerminatingError(new ErrorRecord(new Exception(terminatingErrorMessage), terminatingErrorCode, ErrorCategory.InvalidData, this));
                      }
                      );
#endif
                }
                WriteObject(item);
            }
        }
    }
}