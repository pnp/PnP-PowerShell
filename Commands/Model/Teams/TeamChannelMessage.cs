using System;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PnP.PowerShell.Commands.Model.Teams
{
    public partial class TeamChannelMessage
    {
        public string Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public DateTime? LastModifiedDateTime { get; set; }
        public string Importance { get; set; } = "normal";
        public TeamChannelMessageBody Body { get; set; } = new TeamChannelMessageBody();

        public TeamChannelMessageFrom From { get; set; } = new TeamChannelMessageFrom();
    }

    public class TeamChannelMessageFrom
    {
        public User User { get; set; } = new User();
    }

    public class TeamChannelMessageBody
    {
        public string ContentType { get; set; }

        public string Content { get; set; }

    }

    public enum TeamChannelMessageContentType
    {
        Text,
        Html
    }
}
