using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model.Teams;
using System;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class TeamPipeBind
    {
        private Team team;
        private string groupId;

        public TeamPipeBind(Guid id)
        {
            groupId = id.ToString();
        }

        public TeamPipeBind(string stringId)
        {
            if(Guid.TryParse(stringId, out Guid guidId))
            {
                groupId = guidId.ToString();
            } else
            {
                throw new ArgumentException("ID is not in correct format, needs to be a GUID");
            }
        }

        public TeamPipeBind(Team team)
        {
            this.team = team;
        }

        internal string GetTeamId()
        {
            if (team != null)
            {
                return team.GroupId;
            }
            else
            {
                return groupId;
            }
        }
    }
}
