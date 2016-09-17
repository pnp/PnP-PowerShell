using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Lists
{
    [Cmdlet(VerbsCommon.Remove, "SPOList", SupportsShouldProcess = true)]
    [CmdletHelp("Deletes a list",
        Category = CmdletHelpCategory.Lists)]
    [CmdletExample(
        Code = "PS:> Remove-SPOList -Title Announcements",
        SortOrder = 1)]
    [CmdletExample(
        Code = "PS:> Remove-SPOList -Title Announcements -force",
        SortOrder = 2)]
    public class RemoveList : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID or Title of the list.")]
        public ListPipeBind Identity = new ListPipeBind();

        [Parameter(Mandatory = false, HelpMessage = "Overwrites the output file if it exists.")]
        public SwitchParameter Force;
        protected override void ExecuteCmdlet()
        {
            if (Identity != null)
            {
                var list = Identity.GetList(SelectedWeb);
                if (list != null)
                {
                    if (Force || ShouldContinue(Properties.Resources.RemoveList, Properties.Resources.Confirm))
                    {
                        list.DeleteObject();
                        ClientContext.ExecuteQueryRetry();
                    }
                }
            }
        }
    }

}
