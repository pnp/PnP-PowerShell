#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPADUser")]
    [CmdletHelp("Gets users from Azure Active Directory. Requires the Azure Active Directory application permission 'User.Read.All'.",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPADUser",
       Remarks = "Retrieves all users from Azure Active Directory",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPADUser -Identity 328c7693-5524-44ac-a946-73e02d6b0f98",
       Remarks = "Retrieves the user from Azure Active Directory with the id 328c7693-5524-44ac-a946-73e02d6b0f98",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPADUser -Filter \"accountEnabled eq false\"",
       Remarks = "Retrieves all the disabled users from Azure Active Directory",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Get-PnPADUser -Filter \"startswith(DisplayName, 'John')\" -OrderBy \"DisplayName\"",
       Remarks = "Retrieves all the users from Azure Active Directory of which their DisplayName starts with 'John' and sort the results by the DisplayName",
       SortOrder = 4)]
    public class GetADUser : PnPGraphCmdlet
    {
        const string ParameterSet_BYID = "Return by specific ID";
        const string ParameterSet_LIST = "Return a list";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_BYID, HelpMessage = "Returns the user with the provided user id")]
        public string Identity;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LIST, HelpMessage = "Includes a filter to the retrieval of the users. Use OData instructions to construct the filter, i.e. \"startswith(DisplayName, 'John')\".")]
        public string Filter;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LIST, HelpMessage = "Includes a custom sorting instruction to the retrieval of the users. Use OData syntax to construct the orderby, i.e. \"DisplayName desc\".")]
        public string OrderBy;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Identity)))
            {
                OfficeDevPnP.Core.Framework.Graph.Model.User user = OfficeDevPnP.Core.Framework.Graph.UsersUtility.GetUser(AccessToken, System.Guid.Parse(Identity));
                WriteObject(user);
            }
            else
            {
                List<OfficeDevPnP.Core.Framework.Graph.Model.User> users = OfficeDevPnP.Core.Framework.Graph.UsersUtility.ListUsers(AccessToken, Filter, OrderBy);
                WriteObject(users, true);
            }
        }
    }
}
#endif