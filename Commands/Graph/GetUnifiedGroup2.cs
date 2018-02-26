using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities.REST;
using SharePointPnP.PowerShell.Commands.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using SharePointPnP.PowerShell.Commands.Utilities.Graph;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPUnifiedGroup2")]
    [CmdletHelp("Gets one Office 365 Group (aka Unified Group) or a list of Office 365 Groups",
        Category = CmdletHelpCategory.Graph, 
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup",
       Remarks = "Retrieves all the Office 365 Groups",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupId",
       Remarks = "Retrieves a specific Office 365 Group based on its ID",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupDisplayName",
       Remarks = "Retrieves a specific or list of Office 365 Groups that start with the given DisplayName",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $groupSiteMailNickName",
       Remarks = "Retrieves a specific or list of Office 365 Groups for which the email starts with the provided mail nickName",
       SortOrder = 4)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroup -Identity $group",
       Remarks = "Retrieves a specific Office 365 Group based on its object instance",
       SortOrder = 5)]
    public class GetUnifiedGroup2 : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The Identity of the Office 365 Group.")]
        public UnifiedGroupPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Exclude fetching the site URL for Office 365 Groups. This speeds up large listings.")]
        public SwitchParameter ExcludeSiteUrl;

        protected override void ExecuteCmdlet()
        {
            UnifiedGroupEntity group = null;

            if (Identity != null)
            {
            //    group = Identity.GetGroup(AccessToken);
            }
            else
            {
                var entities = GraphHelper.ExecuteGetRequest<ResponseCollection<GraphObject>>(SPOnlineConnection.CurrentConnection.AccessToken, "v1.0/groups?$filter=groupTypes/any(gt : gt eq 'Unified')&$select=id,displayName,mailNickname,description,mail").Items;
                var groups = new List<UnifiedGroupEntity>();
                foreach(var entity in entities)
                {
                    var unifiedGroup = new UnifiedGroupEntity()
                    {
                        GroupId = entity.Id.ToString(),
                        DisplayName = entity.Values["displayName"] as string,
                        MailNickname = entity.Values["mailNickname"] as string,
                        Description = entity.Values["description"] as string,
                        Mail = entity.Values["mail"] as string
                    };
                    var drive = GraphHelper.ExecuteGetRequest<GraphObject>(SPOnlineConnection.CurrentConnection.AccessToken, $"v1.0/groups/{entity.Id}/drive/root/webUrl");
                    var url = drive.Values["value"].ToString();
                    unifiedGroup.SiteUrl = url.Substring(0, url.LastIndexOf('/'));

                    groups.Add(unifiedGroup);
                }
                WriteObject(groups, true);
              
            }

            if (group != null)
            {
                WriteObject(group);
            }
        }
    }
}
