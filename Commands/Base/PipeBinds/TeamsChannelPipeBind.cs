using Microsoft.Graph;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class TeamsChannelPipeBind
    {
        private readonly string _id;
        private readonly string _displayName;
        public TeamsChannelPipeBind()
        {

        }

        public TeamsChannelPipeBind(string input)
        {
            // check if it's a channel id
            if (input.EndsWith("@tread.skype") && input.Substring(2, 1) == ":")
            {
                _id = input;
            }
            else
            {
                _displayName = input;
            }
        }

        public TeamsChannelPipeBind(Model.Teams.TeamChannel channel)
        {
            _id = channel.Id;
        }


        public string Id => _id;

        public string GetId(HttpClient httpClient, string accessToken, string groupId)
        {
            if (!string.IsNullOrEmpty(_id))
            {
                return _id;
            }
            else
            {
                var channels = TeamsUtility.GetChannels(accessToken, httpClient, groupId);
                return channels.FirstOrDefault(c => c.DisplayName.Equals(_displayName, StringComparison.OrdinalIgnoreCase)).Id;
            }
        }

    }
}
