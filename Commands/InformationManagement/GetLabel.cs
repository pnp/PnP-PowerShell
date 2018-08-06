#if !ONPREMISES
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.InformationManagement
{
    [Cmdlet(VerbsCommon.Get, "PnPLabel")]
    [CmdletHelp("Gets the label/tag of the specfied list or library (if applicable)", Category = CmdletHelpCategory.InformationManagement, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> Get-PnPLabel -List ""Demo List""",
       Remarks = @"This gets the label which is set to a list or a library.", SortOrder = 1)]

    public class GetListComplianceTag : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID or Url of the list.")]
        public ListPipeBind List;

        protected override void ExecuteCmdlet()
        {
            var list = List.GetList(SelectedWeb);
            if (list != null)
            {
                var listUrl = list.RootFolder.ServerRelativeUrl;
                var label = Microsoft.SharePoint.Client.CompliancePolicy.SPPolicyStoreProxy.GetListComplianceTag(ClientContext, listUrl);
                ClientContext.ExecuteQueryRetry();

                if (label.Value == null)
                {
                    WriteWarning("No label found for the specified library.");
                }
                else
                {
                    WriteObject("The label '" + label.Value.TagName + "' is set to the specified list or library. ");
                    // There is no property yet that exposes if the SyncToItems is set or not.. :(
                    WriteObject("Block deletion: " + label.Value.BlockDelete.ToString());
                    WriteObject("Block editing: " + label.Value.BlockEdit.ToString());
                }
            }
            else
            {
                WriteWarning("List or library not found.");
            }
        }
    }
}
#endif