using SharePointPnP.PowerShell.Commands.Model.Teams;
using SharePointPnP.PowerShell.Commands.Utilities.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    internal static class TeamsUtility
    {
        private const int PageSize = 100;

        #region Team
        private static List<Group> GetGroupsWithTeam(HttpClient httpClient, string accessToken, GroupVisibility visibility = GroupVisibility.NotSpecified)
        {
            List<Group> groups = new List<Group>();
            string url = string.Empty;
            var collection = GraphHelper.GetAsync<GraphCollection<Group>>(httpClient, $"beta/groups?$filter=resourceProvisioningOptions/Any(x:x eq 'Team')&$select=Id,DisplayName,MailNickName,Description,Visibility&$top={PageSize}", accessToken).GetAwaiter().GetResult(); ;
            if(collection != null)
            {
                groups.AddRange(collection.Items);
                while(!string.IsNullOrEmpty(collection.NextLink))
                {
                    collection = GraphHelper.GetAsync<GraphCollection<Group>>(httpClient, collection.NextLink, accessToken).GetAwaiter().GetResult();
                    groups.AddRange(collection.Items);
                }
            }
            if (visibility != GroupVisibility.NotSpecified)
            {
                return groups.Where(g => g.Visibility == visibility).ToList();
            }
            else
            {
                return groups;
            }
        }

        public static List<Team> GetTeams(string accessToken, HttpClient httpClient, GroupVisibility visibility = GroupVisibility.NotSpecified)
        {
            List<Team> teams = new List<Team>();

            var groups = GetGroupsWithTeam(httpClient, accessToken, visibility);
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
            } else
            {
                return null;
            }
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
                } else
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
            }
        }
        #endregion

        #region Channel
        public static IEnumerable<TeamChannel> GetChannels(string accessToken, HttpClient httpClient, string groupId)
        {
            var collection = GraphHelper.GetAsync<GraphCollection<TeamChannel>>(httpClient, $"v1.0/teams/{groupId}/channels", accessToken).GetAwaiter().GetResult();
                if(collection != null)
            {
                return collection.Items;
            } else
            {
                return null;
            }
        }

        public static bool DeleteChannel(string accessToken, HttpClient httpClient, string groupId, string displayName)
        {
            // find the channel
            var channels = GetChannels(accessToken, httpClient, groupId);
            var channel = channels.FirstOrDefault(c => c.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase));
            if (channel != null)
            {
                return GraphHelper.DeleteAsync(httpClient, $"v1.0/teams/{groupId}/channels/{channel.Id}", accessToken).GetAwaiter().GetResult();
            } else
            {
                return false;
            }
        }

        public static TeamChannel AddChannel(string accessToken, HttpClient httpClient, string groupId, string displayName, string description)
        {
            var channel = new TeamChannel()
            {
                Description = description,
                DisplayName = displayName,
            };
            return GraphHelper.PostAsync<TeamChannel>(httpClient, $"v1.0/teams/{groupId}/channels", channel, accessToken).GetAwaiter().GetResult();
        }
        #endregion
    }
}
