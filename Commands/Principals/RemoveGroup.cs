using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Principals
{
    [Cmdlet(VerbsCommon.Remove, "SPOGroup", DefaultParameterSetName = "All")]
    [CmdletHelp("Removes a group.",
        Category = CmdletHelpCategory.Principals)]
    [CmdletExample(
        Code = @"PS:> Remove-SPOGroup -Identity ""My Users""",
        SortOrder = 1)]
    public class RemoveGroup : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public GroupPipeBind Identity = new GroupPipeBind();

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            Group group = Identity.GetGroup(SelectedWeb);
            if (Force || ShouldContinue(string.Format(Properties.Resources.RemoveGroup0, group.Title), Properties.Resources.Confirm))
            {
                SelectedWeb.SiteGroups.Remove(group);

                ClientContext.ExecuteQueryRetry();
            }
        }
    }



}
