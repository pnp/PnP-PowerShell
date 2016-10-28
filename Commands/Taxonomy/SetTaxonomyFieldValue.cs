using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Taxonomy
{
    [Cmdlet(VerbsCommon.Set, "PnPTaxonomyFieldValue", DefaultParameterSetName = "ITEM")]
    [CmdletAlias("Set-SPOTaxonomyFieldValue")]
    [CmdletHelp("Sets a taxonomy term value in a listitem field",
        Category = CmdletHelpCategory.Taxonomy)]
    [CmdletExample(
        Code = @"PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermId 863b832b-6818-4e6a-966d-2d3ee057931c",
        Remarks = @"Sets the field called 'Department' to the value of the term with the ID specified",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPTaxonomyFieldValue -ListItem $item -InternalFieldName 'Department' -TermPath 'CORPORATE|DEPARTMENTS|HR'",
        Remarks = @"Sets the field called 'Department' to the term called HR which is located in the DEPARTMENTS termset, which in turn is located in the CORPORATE termgroup.",
        SortOrder = 2)]
    public class SetTaxonomyFieldValue : SPOCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ParameterAttribute.AllParameterSets, HelpMessage = "The list item to set the field value to")]
        public ListItem ListItem;

        [Parameter(Mandatory = true, ParameterSetName = ParameterAttribute.AllParameterSets, HelpMessage = "The internal name of the field")]
        public string InternalFieldName;

        [Parameter(Mandatory = true, ParameterSetName = "ITEM", HelpMessage = "The Id of the Term")]
        public GuidPipeBind TermId;

        [Parameter(Mandatory = false, ParameterSetName = "ITEM", HelpMessage = "The Label value of the term")]
        public string Label;

        [Parameter(Mandatory = true, ParameterSetName = "PATH", HelpMessage = "A path in the form of GROUPLABEL|TERMSETLABEL|TERMLABEL")]
        public string TermPath;

        protected override void ExecuteCmdlet()
        {
            Field field = ListItem.ParentList.Fields.GetByInternalNameOrTitle(InternalFieldName);
            ListItem.Context.Load(field);
            ListItem.Context.ExecuteQueryRetry();

            switch (ParameterSetName)
            {
                case "ITEM":
                    {
                        ListItem.SetTaxonomyFieldValue(field.Id, Label, TermId.Id);
                        break;
                    }
                case "PATH":
                    {
                        ListItem.SetTaxonomyFieldValueByTermPath(TermPath, field.Id);
                        break;
                    }
            }
        }
    }

}
