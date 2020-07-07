using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharePointPnP.PowerShell.Commands.Model.Teams;
using SharePointPnP.PowerShell.Commands.Site;
using SharePointPnP.PowerShell.Commands.Utilities.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
#if !NETSTANDARD2_1
using System.Web;
#endif

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    internal static class TeamsUtility
    {
        private const int PageSize = 100;

        #region Team
        public static List<Group> GetGroupsWithTeam(HttpClient httpClient, string accessToken)
        {
            List<Group> groups = new List<Group>();
            string url = string.Empty;
            var collection = GraphHelper.GetAsync<GraphCollection<Group>>(httpClient, $"beta/groups?$filter=resourceProvisioningOptions/Any(x:x eq 'Team')&$select=Id,DisplayName,MailNickName,Description,Visibility&$top={PageSize}", accessToken).GetAwaiter().GetResult(); ;
            if (collection != null)
            {
                groups.AddRange(collection.Items);
                while (!string.IsNullOrEmpty(collection.NextLink))
                {
                    collection = GraphHelper.GetAsync<GraphCollection<Group>>(httpClient, collection.NextLink, accessToken).GetAwaiter().GetResult();
                    groups.AddRange(collection.Items);
                }
            }
            return groups;
        }

        public static Group GetGroupWithTeam(HttpClient httpClient, string accessToken, string mailNickname)
        {
            return GraphHelper.GetAsync<Group>(httpClient, $"beta/groups?$filter=(resourceProvisioningOptions/Any(x:x eq 'Team') and mailNickname eq '{mailNickname}')&$select=Id,DisplayName,MailNickName,Description,Visibility", accessToken).GetAwaiter().GetResult();

        }
        public static List<Team> GetTeams(string accessToken, HttpClient httpClient)
        {
            List<Team> teams = new List<Team>();

            var groups = GetGroupsWithTeam(httpClient, accessToken);
            foreach (var group in groups)
            {
                Team team = ParseTeamJson(accessToken, httpClient, group.Id);

                if (team != null)
                {
                    team.DisplayName = group.DisplayName;
                    team.MailNickname = group.MailNickname;
                    team.Visibility = group.Visibility;
                    teams.Add(team);
                }
            }
            return teams;
        }

        public static Team GetTeam(string accessToken, HttpClient httpClient, string groupId)
        {
            // get the group
            var group = GraphHelper.GetAsync<Group>(httpClient, $"v1.0/groups/{groupId}?$select=Id,DisplayName,MailNickName,Description,Visibility", accessToken).GetAwaiter().GetResult();

            Team team = ParseTeamJson(accessToken, httpClient, group.Id);
            if (team != null)
            {
                team.DisplayName = group.DisplayName;
                team.MailNickname = group.MailNickname;
                team.Visibility = group.Visibility;
                return team;
            }
            else
            {
                return null;
            }
        }

        public static HttpResponseMessage DeleteTeam(string accessToken, HttpClient httpClient, string groupId)
        {
            return GraphHelper.DeleteAsync(httpClient, $"v1.0/groups/{groupId}", accessToken).GetAwaiter().GetResult();
        }

        private static Team ParseTeamJson(string accessToken, HttpClient httpClient, string groupId)
        {
            // Get Settings
            try
            {
                var team = GraphHelper.GetAsync<Team>(httpClient, $"v1.0/teams/{groupId}", accessToken).GetAwaiter().GetResult();
                if (team != null)
                {
                    team.GroupId = groupId;
                    return team;
                }
                else
                {
                    return null;
                }

                //team = GetTeamChannels(configuration, accessToken, groupId, team, scope);
                //team = GetTeamApps(accessToken, groupId, team, scope);
                //team = GetTeamSecurity(accessToken, groupId, team, scope);
                //GetTeamPhoto(configuration, accessToken, groupId, team, scope);
            }
            catch (ApplicationException ex)
            {
#if !NETSTANDARD2_1
                if (ex.InnerException is HttpException)
                {
                    if (((HttpException)ex.InnerException).GetHttpCode() == 404)
                    {
                        // no team, swallow
                        return null;
                    }
                    else
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw ex;
                }
#else
                // untested change
                if (ex.Message.StartsWith("404"))
                {
                    // no team, swallow
                }
                else
                {
                    throw ex;
                }
#endif
                return null;
            }
        }

        public static Team NewTeam(string accessToken, HttpClient httpClient, string groupId, string displayName, string description, string classification, string mailNickname, string owner, GroupVisibility visibility, TeamCreationInformation teamCI)
        {
            Group group = null;
            Team returnTeam = null;
            // Create group
            if (string.IsNullOrEmpty(groupId))
            {
                group = CreateGroup(accessToken, httpClient, displayName, description, classification, mailNickname, owner, visibility);
            }
            else
            {
                group = GraphHelper.GetAsync<Group>(httpClient, $"v1.0/groups/{groupId}", accessToken).GetAwaiter().GetResult();
                if (group == null)
                {
                    throw new PSArgumentException($"Cannot find group with id {groupId}");
                }
                teamCI.Visibility = group.Visibility;
                teamCI.Description = group.Description;
            }
            if (group != null)
            {
                Team team = teamCI.ToTeam();
                var teamSettings = GraphHelper.PutAsync(httpClient, $"v1.0/groups/{group.Id}/team", team, accessToken).GetAwaiter().GetResult();
                if (teamSettings != null)
                {
                    returnTeam = TeamsUtility.GetTeam(accessToken, httpClient, group.Id);
                }
            }
            return returnTeam;
        }

        private static Group CreateGroup(string accessToken, HttpClient httpClient, string displayName, string description, string classification, string mailNickname, string owner, GroupVisibility visibility)
        {
            Group group = new Group();
            // get the owner if no owner was specified
            var ownerId = string.Empty;
            if (string.IsNullOrEmpty(owner))
            {
                var user = GraphHelper.GetAsync<User>(httpClient, "v1.0/me?$select=Id", accessToken).GetAwaiter().GetResult();
                ownerId = user.Id;
            }
            else
            {
                var user = GraphHelper.GetAsync<User>(httpClient, $"v1.0/users/{owner}?$select=Id", accessToken).GetAwaiter().GetResult();
                if (user != null)
                {
                    ownerId = user.Id;
                }
                else
                {
                    // find the user in the organization
                    var collection = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, "v1.0/myorganization/users?$filter=mail eq '{owner}'&$select=Id", accessToken).GetAwaiter().GetResult();
                    if (collection != null)
                    {
                        if (collection.Items.Any())
                        {
                            ownerId = collection.Items.First().Id;
                        }
                    }
                }
            }

            group.DisplayName = displayName;
            group.Description = description;
            group.Classification = classification;
            group.MailEnabled = true;
            group.MailNickname = mailNickname ?? CreateAlias(httpClient, accessToken);
            group.GroupTypes = new List<string>() { "Unified" };
            group.SecurityEnabled = false;
            group.Owners = new List<string>() { $"https://graph.microsoft.com/v1.0/users/{ownerId}" };
            group.Members = new List<string>() { $"https://graph.microsoft.com/v1.0/users/{ownerId}" };
            group.Visibility = visibility == GroupVisibility.NotSpecified ? GroupVisibility.Private : visibility;

            return GraphHelper.PostAsync<Group>(httpClient, "v1.0/groups", group, accessToken).GetAwaiter().GetResult();

        }

        private static string CreateAlias(HttpClient httpClient, string accessToken)
        {
            var guid = Guid.NewGuid().ToString();
            var teamName = string.Empty;
            // check if the group exists
            do
            {
                var teamNameTemp = $"msteams_{guid.Substring(0, 8)}{guid.Substring(9, 4)}";
                var collection = GraphHelper.GetAsync<GraphCollection<Group>>(httpClient, $"v1.0/groups?$filter=groupTypes/any(c:c+eq+'Unified') and (mailNickname eq '{teamNameTemp}')", accessToken).GetAwaiter().GetResult();
                if (collection != null)
                {
                    if (!collection.Items.Any()) teamName = teamNameTemp;
                }

            } while (teamName == string.Empty);
            return teamName;
        }

        public static Team UpdateTeam(HttpClient httpClient, string accessToken, string groupId, Team team)
        {
            return GraphHelper.PatchAsync<Team>(httpClient, accessToken, $"v1.0/teams/{groupId}", team).GetAwaiter().GetResult();
        }

        public static Group UpdateGroup(HttpClient httpClient, string accessToken, string groupId, Group group)
        {
            return GraphHelper.PatchAsync<Group>(httpClient, accessToken, $"v1.0/groups/{groupId}", group).GetAwaiter().GetResult();
        }

        public static void SetTeamPicture(HttpClient httpClient, string accessToken, string groupId, byte[] bytes, string contentType)
        {
            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            GraphHelper.PutAsync<string>(httpClient, $"v1.0/groups/{groupId}/photo/$value", accessToken, byteArrayContent).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage SetTeamArchivedState(HttpClient httpClient, string accessToken, string groupId, bool archived, bool? setSiteReadOnly)
        {
            if (archived)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(setSiteReadOnly.HasValue ? new { shouldSetSpoSiteReadOnlyForMembers = setSiteReadOnly } : null));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return GraphHelper.PostAsync(httpClient, $"v1.0/teams/{groupId}/archive", accessToken, content).GetAwaiter().GetResult();
            }
            else
            {
                StringContent content = new StringContent("");
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return GraphHelper.PostAsync(httpClient, $"v1.0/teams/{groupId}/unarchive", accessToken, content).GetAwaiter().GetResult();
            }
        }
        #endregion

        #region Users
        public static void AddUser(HttpClient httpClient, string accessToken, string groupId, string upn, string role)
        {
            var user = GraphHelper.GetAsync<User>(httpClient, $"v1.0/users/{upn}", accessToken).GetAwaiter().GetResult();

            // check if the user is a member
            bool isMember = false;
            try
            {
                var members = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, $"v1.0/groups/{groupId}/members?$filter=Id eq '{user.Id}'&$select=Id", accessToken).GetAwaiter().GetResult();
                isMember = members.Items.Any();
            }
            catch (GraphException)
            { }

            bool isOwner = false;
            try
            {
                var owners = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, $"v1.0/groups/{groupId}/owners?$filter=Id eq '{user.Id}'&$select=Id", accessToken).GetAwaiter().GetResult();
                isOwner = owners.Items.Any();
            }
            catch (GraphException)
            {

            }

            var value = new Dictionary<string, object>
            {
                {
                    "@odata.id",
                    $"https://graph.microsoft.com/v1.0/directoryObjects/{user.Id}"
                }
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(value));
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            if (role == "Owner")
            {
                if (!isMember)
                {
                    GraphHelper.PostAsync(httpClient, $"v1.0/groups/{groupId}/members/$ref", accessToken, stringContent).GetAwaiter().GetResult();
                }
                GraphHelper.PostAsync(httpClient, $"v1.0/groups/{groupId}/owners/$ref", accessToken, stringContent).GetAwaiter().GetResult();
            }
            else
            {
                GraphHelper.PostAsync(httpClient, $"v1.0/groups/{groupId}/members/$ref", accessToken, stringContent).GetAwaiter().GetResult();
            }
        }

        public static List<User> GetUsers(HttpClient httpClient, string accessToken, string groupId, string role)
        {
            var selectedRole = role != null ? role.ToLower() : null;
            var owners = new List<User>();
            var guests = new List<User>();
            var members = new List<User>();
            if (selectedRole != "guest")
            {
                owners = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, $"v1.0/groups/{groupId}/owners?$select=Id,displayName,userPrincipalName,userType", accessToken).GetAwaiter().GetResult().Items.Select(t => new User()
                {
                    Id = t.Id,
                    DisplayName = t.DisplayName,
                    UserPrincipalName = t.UserPrincipalName,
                    UserType = "Owner"
                }).ToList();
            }
            if (selectedRole != "owner")
            {
                var users = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, $"v1.0/groups/{groupId}/members?$select=Id,displayName,userPrincipalName,userType", accessToken).GetAwaiter().GetResult().Items;
                HashSet<string> hashSet = new HashSet<string>(owners.Select(u => u.Id));
                foreach (var user in users)
                {
                    if (!hashSet.Contains(user.Id))
                    {
                        if (user.UserType != null && user.UserType.ToLower().Equals("guest"))
                        {
                            guests.Add(new User() { DisplayName = user.DisplayName, Id = user.Id, UserPrincipalName = user.UserPrincipalName, UserType = "Guest" });
                        }
                        else
                        {
                            members.Add(new User() { DisplayName = user.DisplayName, Id = user.Id, UserPrincipalName = user.UserPrincipalName, UserType = "Member" });
                        }
                    }
                }
            }
            var finalList = new List<User>();
            if (string.IsNullOrEmpty(selectedRole))
            {
                finalList.AddRange(owners);
                finalList.AddRange(members);
                finalList.AddRange(guests);
            }
            else if (selectedRole == "owner")
            {
                finalList.AddRange(owners);
            }
            else if (selectedRole == "member")
            {
                finalList.AddRange(members);
            }
            else if (selectedRole == "guest")
            {
                finalList.AddRange(guests);
            }
            return finalList;
        }

        public static void DeleteUser(HttpClient httpClient, string accessToken, string groupId, string upn, string role)
        {
            var user = GraphHelper.GetAsync<User>(httpClient, $"v1.0/users/{upn}?$select=Id", accessToken).GetAwaiter().GetResult();
            if (user != null)
            {
                // check if the user is an owner
                var owners = GraphHelper.GetAsync<GraphCollection<User>>(httpClient, $"v1.0/groups/{groupId}/owners?$select=Id", accessToken).GetAwaiter().GetResult();
                if (owners.Items.Any() && owners.Items.FirstOrDefault(u => u.Id.Equals(user.Id, StringComparison.OrdinalIgnoreCase)) != null)
                {
                    if (owners.Items.Count() == 1)
                    {
                        throw new PSInvalidOperationException("Last owner cannot be removed");
                    }
                    GraphHelper.DeleteAsync(httpClient, $"v1.0/groups/{groupId}/owners/{user.Id}/$ref", accessToken).GetAwaiter().GetResult();
                }
                if (!role.Equals("owner", StringComparison.OrdinalIgnoreCase))
                {
                    GraphHelper.DeleteAsync(httpClient, $"v1.0/groups/{groupId}/members/{user.Id}/$ref", accessToken).GetAwaiter().GetResult();
                }
            }
        }

        #endregion

        #region Channel
        public static IEnumerable<TeamChannel> GetChannels(string accessToken, HttpClient httpClient, string groupId)
        {
            var collection = GraphHelper.GetAsync<GraphCollection<TeamChannel>>(httpClient, $"beta/teams/{groupId}/channels", accessToken).GetAwaiter().GetResult();
            if (collection != null)
            {
                return collection.Items;
            }
            else
            {
                return null;
            }
        }

        public static HttpResponseMessage DeleteChannel(string accessToken, HttpClient httpClient, string groupId, string channelId)
        {
            return GraphHelper.DeleteAsync(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}", accessToken).GetAwaiter().GetResult();
        }

        public static TeamChannel AddChannel(string accessToken, HttpClient httpClient, string groupId, string displayName, string description, bool isPrivate)
        {
            var channel = new TeamChannel()
            {
                Description = description,
                DisplayName = displayName,
            };
            if (isPrivate)
            {
                channel.MembershipType = "private";
            }
            return GraphHelper.PostAsync<TeamChannel>(httpClient, $"beta/teams/{groupId}/channels", channel, accessToken).GetAwaiter().GetResult();
        }

        public static void PostMessage(HttpClient httpClient, string accessToken, string groupId, string channelId, TeamChannelMessage message)
        {
            GraphHelper.PostAsync(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}/messages", message, accessToken).GetAwaiter().GetResult();
        }

        public static List<TeamChannelMessage> GetMessages(HttpClient httpClient, string accessToken, string groupId, string channelId, bool includeDeleted = false)
        {
            List<TeamChannelMessage> messages = new List<TeamChannelMessage>();
            var collection = GraphHelper.GetAsync<GraphCollection<TeamChannelMessage>>(httpClient, $"beta/teams/{groupId}/channels/{channelId}/messages", accessToken).GetAwaiter().GetResult();
            if (collection != null)
            {
                messages.AddRange(collection.Items);
                while (collection != null && !string.IsNullOrEmpty(collection.NextLink))
                {
                    collection = GraphHelper.GetAsync<GraphCollection<TeamChannelMessage>>(httpClient, collection.NextLink, accessToken).GetAwaiter().GetResult();
                    if (collection != null)
                    {
                        messages.AddRange(collection.Items);
                    }
                }
            }
            if (includeDeleted)
            {
                return messages;
            }
            else
            {
                return messages.Where(m => !m.DeletedDateTime.HasValue).ToList();
            }
        }

        public static TeamChannel UpdateChannel(HttpClient httpClient, string accessToken, string groupId, string channelId, TeamChannel channel)
        {
            return GraphHelper.PatchAsync(httpClient, accessToken, $"beta/teams/{groupId}/channels/{channelId}", channel).GetAwaiter().GetResult();
        }
        #endregion

        #region Tabs
        public static IEnumerable<TeamTab> GetTabs(string accessToken, HttpClient httpClient, string groupId, string channelId)
        {
            var collection = GraphHelper.GetAsync<GraphCollection<TeamTab>>(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}/tabs", accessToken).GetAwaiter().GetResult();
            if (collection != null)
            {
                return collection.Items;
            }
            return null;
        }

        public static TeamTab GetTab(string accessToken, HttpClient httpClient, string groupId, string channelId, string tabId)
        {
            return GraphHelper.GetAsync<TeamTab>(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}/tabs/{tabId}", accessToken).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage DeleteTab(string accessToken, HttpClient httpClient, string groupId, string channelId, string tabId)
        {
            return GraphHelper.DeleteAsync(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}/tabs/{tabId}", accessToken).GetAwaiter().GetResult();
        }

        public static void UpdateTab(HttpClient httpClient, string accessToken, string groupId, string channelId, TeamTab tab)
        {
            tab.Configuration = null;
            GraphHelper.PatchAsync(httpClient, accessToken, $"v1.0/teams/{groupId}/channels/{channelId}/tabs/{tab.Id}", tab).GetAwaiter().GetResult();
        }

        public static TeamTab AddTab(HttpClient httpClient, string accessToken, string groupId, string channelId, string displayName, TeamTabType tabType, string teamsAppId, string entityId, string contentUrl, string removeUrl, string websiteUrl)
        {
            TeamTab tab = new TeamTab();
            tab.Configuration = new TeamTabConfiguration();
            switch (tabType)
            {
                case TeamTabType.Custom:
                    {
                        tab.TeamsAppId = teamsAppId;
                        tab.Configuration.EntityId = entityId;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = removeUrl;
                        tab.Configuration.WebsiteUrl = websiteUrl;
                        break;
                    }
                case TeamTabType.DocumentLibrary:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.files.sharepoint";
                        tab.Configuration.EntityId = "";
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = null;
                        break;
                    }
                case TeamTabType.WebSite:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.web";
                        tab.Configuration.EntityId = null;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = contentUrl;
                        break;
                    }
                case TeamTabType.Word:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.file.staticviewer.word";
                        tab.Configuration.EntityId = entityId;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = null;
                        break;
                    }
                case TeamTabType.Excel:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.file.staticviewer.excel";
                        tab.Configuration.EntityId = entityId;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = null;
                        break;
                    }
                case TeamTabType.PowerPoint:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.file.staticviewer.powerpoint";
                        tab.Configuration.EntityId = entityId;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = null;
                        break;
                    }
                case TeamTabType.PDF:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.file.staticviewer.pdf";
                        tab.Configuration.EntityId = entityId;
                        tab.Configuration.ContentUrl = contentUrl;
                        tab.Configuration.RemoveUrl = null;
                        tab.Configuration.WebsiteUrl = null;
                        break;
                    }
                case TeamTabType.Wiki:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.wiki";
                        break;
                    }
                case TeamTabType.Planner:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.planner";
                        break;
                    }
                case TeamTabType.MicrosoftStream:
                    {
                        tab.TeamsAppId = "com.microsoftstream.embed.skypeteamstab";
                        break;
                    }
                case TeamTabType.MicrosoftForms:
                    {
                        tab.TeamsAppId = "81fef3a6-72aa-4648-a763-de824aeafb7d";
                        break;
                    }
                case TeamTabType.OneNote:
                    {
                        tab.TeamsAppId = "0d820ecd-def2-4297-adad-78056cde7c78";
                        break;
                    }
                case TeamTabType.PowerBI:
                    {
                        tab.TeamsAppId = "com.microsoft.teamspace.tab.powerbi";
                        break;
                    }
                case TeamTabType.SharePointPageAndList:
                    {
                        tab.TeamsAppId = "2a527703-1f6f-4559-a332-d8a7d288cd88";
                        break;
                    }
            }
            tab.DisplayName = displayName;
            tab.TeamsApp = $"https://graph.microsoft.com/v1.0/appCatalogs/teamsApps/{tab.TeamsAppId}";
            return GraphHelper.PostAsync<TeamTab>(httpClient, $"v1.0/teams/{groupId}/channels/{channelId}/tabs", tab, accessToken).GetAwaiter().GetResult();
        }
        #endregion

        #region Apps
        public static IEnumerable<TeamApp> GetApps(string accessToken, HttpClient httpClient)
        {
            var collection = GraphHelper.GetAsync<GraphCollection<TeamApp>>(httpClient, $"v1.0/appCatalogs/teamsApps", accessToken).GetAwaiter().GetResult();
            if (collection != null)
            {
                return collection.Items;
            }
            return null;
        }

        public static TeamApp AddApp(HttpClient httpClient, string accessToken, byte[] bytes)
        {
            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
            var response = GraphHelper.PostAsync(httpClient, "v1.0/appCatalogs/teamsApps", accessToken, byteArrayContent).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                if (GraphHelper.TryGetGraphException(response, out GraphException exception))
                {
                    throw exception;
                }
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<TeamApp>(content);
            }
            return null;
        }

        public static HttpResponseMessage UpdateApp(HttpClient httpClient, string accessToken, byte[] bytes, string appId)
        {
            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
            return GraphHelper.PutAsync(httpClient, $"v1.0/appCatalogs/teamsApps/{appId}", accessToken, byteArrayContent).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage DeleteApp(HttpClient httpClient, string accessToken, string appId)
        {
            return GraphHelper.DeleteAsync(httpClient, $"v1.0/appCatalogs/teamsApps/{appId}", accessToken).GetAwaiter().GetResult();
        }
        #endregion
    }
}