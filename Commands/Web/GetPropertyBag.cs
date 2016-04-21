using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOPropertyBag")]
    [CmdletHelp("Returns the property bag values.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
       Code = @"PS:> Get-SPOPropertyBag",
       Remarks = "This will return all web property bag values",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> Get-SPOPropertyBag -Key MyKey",
       Remarks = "This will return the value of the key MyKey from the web property bag",
       SortOrder = 2)]
    [CmdletExample(
       Code = @"PS:> Get-SPOPropertyBag -Folder /MyFolder",
       Remarks = "This will return all property bag values for the folder MyFolder which is located in the root of the current web",
       SortOrder = 3)]
    [CmdletExample(
       Code = @"PS:> Get-SPOPropertyBag -Folder /MyFolder -Key vti_mykey",
       Remarks = "This will return the value of the key vti_mykey from the folder MyFolder which is located in the root of the current web",
       SortOrder = 4)]
    [CmdletExample(
     Code = @"PS:> Get-SPOPropertyBag -Folder / -Key vti_mykey",
     Remarks = "This will return the value of the key vti_mykey from the root folder of the current web",
     SortOrder = 5)]
    public class GetPropertyBag : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public string Key = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Site relative url of the folder. See examples for use.")]
        public string Folder = string.Empty;

        protected override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Folder))
            {
                if (!string.IsNullOrEmpty(Key))
                {
                    WriteObject(SelectedWeb.GetPropertyBagValueString(Key, string.Empty));
                }
                else
                {
                    SelectedWeb.EnsureProperty(w => w.AllProperties);
                    
                    var values = SelectedWeb.AllProperties.FieldValues.Select(x => new PropertyBagValue() { Key = x.Key, Value = x.Value });
                    WriteObject(values, true);
                }
            }
            else
            {
                // Folder Property Bag

                SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
                
                var folderUrl = UrlUtility.Combine(SelectedWeb.ServerRelativeUrl, Folder);
                var folder = SelectedWeb.GetFolderByServerRelativeUrl(folderUrl);

                folder.EnsureProperty(f => f.Properties);
                
                if (!string.IsNullOrEmpty(Key))
                {
                    var value = folder.Properties.FieldValues.FirstOrDefault(x => x.Key == Key);
                    WriteObject(value.Value, true);
                }
                else
                {
                    var values = folder.Properties.FieldValues.Select(x => new PropertyBagValue() { Key = x.Key, Value = x.Value });
                    WriteObject(values, true);
                }

            }
        }
    }

    public class PropertyBagValue
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
