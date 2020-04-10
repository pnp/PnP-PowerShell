using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Framework.Graph.Model;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPTeamsUser")]
    [CmdletHelp("Adds a new user to an existing team. Requires the Azure Active Directory application permission 'Group.ReadWrite.All'.",
        Category = CmdletHelpCategory.Teams,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Add-PnPTeamsChannel -TeamId 27c42116-6645-419a-a66e-e30f762e7607 -DisplayName 'My Test Channel' -Description 'A description'",
       Remarks = "Adds a new channel to the specified team.",
       SortOrder = 1)]
    public class GetTeamsUser : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The Group/Team id of the team to add the channel to.")]
        [Alias("GroupId")]
        public TeamPipeBind TeamId;

        [Parameter(Mandatory = false, HelpMessage = "The name of the channel to add")]
        public string UserPrincipalName;

        [Parameter(Mandatory = false, HelpMessage = "An optional description of the channel")]
        [ValidateSet("Member", "Owner", "Guest")]
        public string Role = "Member";

        protected override void ExecuteCmdlet()
        {
            var results = new List<PSObject>();

            if (JwtUtility.HasScope(AccessToken, "Group.Read.All") || JwtUtility.HasScope(AccessToken, "Group.ReadWrite.All"))
            {
                if (ParameterSpecified(nameof(Role)))
                {
                    List<GraphUser> users = new List<GraphUser>();
                    switch (Role)
                    {
                        case "Member":
                            {
                                var members = TeamsUtility.GetMembers(AccessToken, TeamId.GetTeamId());
                                results.AddRange(from u in members select GetUserObject(u, "Member"));
                                break;
                            }
                        case "Guest":
                            {
                                var members = TeamsUtility.GetMembers(AccessToken, TeamId.GetTeamId());
                                results.AddRange(members.Where(m => m.UserType.Equals("guest", System.StringComparison.OrdinalIgnoreCase)).Select(u => GetUserObject(u, "Guest")));
                                break;
                            }
                        case "Owner":
                            {
                                results.AddRange(TeamsUtility.GetOwners(AccessToken, TeamId.GetTeamId()).Select(u => GetUserObject(u, "Owner")));
                                break;
                            }
                    }

                }
                else
                {
                    var members = TeamsUtility.GetMembers(AccessToken, TeamId.GetTeamId());
                    results.AddRange(members.Where(m => m.UserType.Equals("guest", System.StringComparison.OrdinalIgnoreCase)).Select(u => GetUserObject(u, "Guest")));
                    results.AddRange(members.Where(m => m.UserType.Equals("member", System.StringComparison.OrdinalIgnoreCase)).Select(u => GetUserObject(u, "Member")));
                    var owners = TeamsUtility.GetOwners(AccessToken, TeamId.GetTeamId());
                    results.Add(from u in members select GetUserObject(u, "Owners"))
                    foreach (var owner in owners)
                    {
                        results.Add(GetUserObject(owner, "Owner"));
                    }
                    foreach (var member in members)
                    {
                        results.Add(GetUserObject(member, "Member"));
                    }
                    WriteObject(results, true);
                }
            }
            else
            {
                WriteWarning("The current access token lacks the Group.Read.All permission scope");
            }
        }

        private PSObject GetUserObject(GraphUser user, string role)
        {
            var record = new PSObject();
            record.Properties.Add(new PSVariableProperty(new PSVariable("UserPrincipalName", user.UserPrincipalName)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("DisplayName", user.DisplayName)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("Role", role)));
            return record;
        }
    }
}
