#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPAADUser", DefaultParameterSetName = ParameterSet_LIST)]
    [CmdletHelp("Gets users from Azure Active Directory. Requires the Azure Active Directory application permission 'User.Read.All'.",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPAADUser",
       Remarks = "Retrieves all users from Azure Active Directory",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPAADUser -Identity 328c7693-5524-44ac-a946-73e02d6b0f98",
       Remarks = "Retrieves the user from Azure Active Directory with the id 328c7693-5524-44ac-a946-73e02d6b0f98",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPAADUser -Identity john@contoso.com",
       Remarks = "Retrieves the user from Azure Active Directory with the user principal name john@contoso.com",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Get-PnPAADUser -Filter \"accountEnabled eq false\"",
       Remarks = "Retrieves all the disabled users from Azure Active Directory",
       SortOrder = 4)]
    [CmdletExample(
       Code = "PS:> Get-PnPAADUser -Filter \"startswith(DisplayName, 'John')\" -OrderBy \"DisplayName\"",
       Remarks = "Retrieves all the users from Azure Active Directory of which their DisplayName starts with 'John' and sort the results by the DisplayName",
       SortOrder = 5)]
    public class GetAADUser : PnPGraphCmdlet
    {
        const string ParameterSet_BYID = "Return by specific ID";
        const string ParameterSet_LIST = "Return a list";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_BYID, HelpMessage = "Returns the user with the provided user id")]
        public string Identity;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LIST, HelpMessage = "Includes a filter to the retrieval of the users. Use OData instructions to construct the filter, i.e. \"startswith(DisplayName, 'John')\".")]
        public string Filter;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LIST, HelpMessage = "Includes a custom sorting instruction to the retrieval of the users. Use OData syntax to construct the orderby, i.e. \"DisplayName desc\".")]
        public string OrderBy;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_BYID, HelpMessage = "Allows providing an array with the property names of specific properties to return. If not provided, the default properties will be returned.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LIST, HelpMessage = "Allows providing an array with the property names of specific properties to return. If not provided, the default properties will be returned.")]
        public string[] Select;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Identity)))
            {
                OfficeDevPnP.Core.Framework.Graph.Model.User user;
                if (Guid.TryParse(Identity, out Guid identityGuid))
                {
                    user = OfficeDevPnP.Core.Framework.Graph.UsersUtility.GetUser(AccessToken, identityGuid);
                }
                else
                {
                    user = OfficeDevPnP.Core.Framework.Graph.UsersUtility.GetUser(AccessToken, Identity, Select);
                }
                WriteObject(user);
            }
            else
            {
                List<OfficeDevPnP.Core.Framework.Graph.Model.User> users = OfficeDevPnP.Core.Framework.Graph.UsersUtility.ListUsers(AccessToken, Filter, OrderBy, Select);
                WriteObject(users, true);
            }
        }
    }
}
#endif