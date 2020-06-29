using Microsoft.SharePoint.Client;
using System;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class TeamTabPipeBind
    {
        private readonly Guid _id;
        private readonly string _displayName;

        public TeamTabPipeBind()
        {
            _id = Guid.Empty;
        }

        public TeamTabPipeBind(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input));
            }
            if (Guid.TryParse(input, out Guid tabId))
            {
                _id = tabId;
            }
            else
            {
                _displayName = input;
            }
        }


        public Guid Id => _id;

        public string DisplayName => _displayName;
    }
}
