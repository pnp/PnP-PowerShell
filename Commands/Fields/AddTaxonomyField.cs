using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client.Taxonomy;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOTaxonomyField")]
    [CmdletHelp("Adds a taxonomy field to a list or as a site column.",
        Category = CmdletHelpCategory.Fields)]
    [CmdletExample(
        Code = @"PS:> Add-SPOTaxonomyField -DisplayName ""Test"" -InternalName ""Test"" -TermSetPath ""TestTermGroup|TestTermSet""",
        Remarks = @"Adds a new taxonomy field called ""Test"" that points to the TestTermSet which is located in the TestTermGroup",
        SortOrder = 1)]
    public class AddTaxonomyField : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ListPipeBind List;

        [Parameter(Mandatory = true, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string DisplayName;

        [Parameter(Mandatory = true, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string InternalName;

        [Parameter(Mandatory = true, ParameterSetName = "Path")]
        public string TermSetPath;

        [Parameter(Mandatory = false, ParameterSetName = "Id")]
        public GuidPipeBind TaxonomyItemId;

        [Parameter(Mandatory = false, ParameterSetName = "Path")]
        public string TermPathDelimiter = "|";

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string Group;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public GuidPipeBind Id = new GuidPipeBind();

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter AddToDefaultView;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter MultiValue;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter Required;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public AddFieldOptions FieldOptions = AddFieldOptions.DefaultValue;


        protected override void ExecuteCmdlet()
        {
            TaxonomyItem taxItem = null;
            Field field;
            if (ParameterSetName == "Path")
            {
                taxItem = ClientContext.Site.GetTaxonomyItemByPath(TermSetPath, TermPathDelimiter);
            }
            else
            {
                var taxSession = ClientContext.Site.GetTaxonomySession();
                var termStore = taxSession.GetDefaultKeywordsTermStore();
                try
                {
                    taxItem = termStore.GetTermSet(TaxonomyItemId.Id);
                }
                catch
                {
                    try
                    {
                        taxItem = termStore.GetTerm(TaxonomyItemId.Id);
                    }
                    catch
                    {
                        throw new Exception(string.Format("Taxonomy Item with Id {0} not found", TaxonomyItemId.Id));
                    }
                }
                taxItem.EnsureProperty(t => t.Id);
            }

            Guid id = Id.Id;
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            TaxonomyFieldCreationInformation fieldCI = new TaxonomyFieldCreationInformation()
            {
                Id = id,
                InternalName = InternalName,
                DisplayName = DisplayName,
                Group = Group,
                TaxonomyItem = taxItem,
                MultiValue = MultiValue,
                Required = Required,
                AddToDefaultView = AddToDefaultView
            };

            if (List != null)
            {
                var list = List.GetList(SelectedWeb);
                field = list.CreateTaxonomyField(fieldCI);
            }
            else
            {
                field = SelectedWeb.CreateTaxonomyField(fieldCI);
            }
            WriteObject(field);
        }

    }

}
