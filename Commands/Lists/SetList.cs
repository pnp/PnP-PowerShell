using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Lists
{
    [Cmdlet(VerbsCommon.Set, "SPOList")]
    [CmdletHelp("Updates list settings",
        Category = CmdletHelpCategory.Lists)]
    [CmdletExample(
        Code = @"Set-SPOList -Identity ""Demo List"" -EnableContentTypes $true", 
        Remarks = "Switches the Enable Content Type switch on the list",
        SortOrder = 1)]
    public class SetList : SPOWebCmdlet
    {
        [Parameter(Mandatory=true, HelpMessage = "The ID, Title or Url of the list.")]
        public ListPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Set to $true to enable content types, set to $false to disable content types")]
        public bool EnableContentTypes;

        [Parameter(Mandatory = false, HelpMessage = "If used the security inheritance is broken for this list")]
        public SwitchParameter BreakRoleInheritance;

        [Parameter(Mandatory = false, HelpMessage = "If used the roles are copied from the above web")]
        public SwitchParameter CopyRoleAssignments;

        [Parameter(Mandatory = false, HelpMessage = "If used the unique permissions are cleared from child objects and they can inherit role assignments from this object")]
        public SwitchParameter ClearSubscopes;

        [Parameter(Mandatory = false, HelpMessage = "The title of ")]
        public string Title = string.Empty;

        protected override void ExecuteCmdlet()
        {
            var list = Identity.GetList(SelectedWeb);

            if(list != null)
            {
                if(BreakRoleInheritance)
                {
                    list.BreakRoleInheritance(CopyRoleAssignments, ClearSubscopes);
                    list.Update();
                    ClientContext.ExecuteQueryRetry();
                }

                if (!string.IsNullOrEmpty(Title))
                {
                    list.Title = Title;
                    list.Update();
                    ClientContext.ExecuteQueryRetry();
                }

                if (list.ContentTypesEnabled != EnableContentTypes)
                {
                    list.ContentTypesEnabled = EnableContentTypes;
                    list.Update();
                    ClientContext.ExecuteQueryRetry();
                }
            }
        }
    }
}
