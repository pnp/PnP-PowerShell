using Microsoft.SharePoint.Client;
using System;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class UserPipeBind
    {
        private readonly int _id;
        private readonly string _login;
        private readonly User _user;

        public UserPipeBind()
        {
            _id = 0;
            _login = null;
            _user = null;
        }

        public UserPipeBind(int id)
        {
            _id = id;
        }

        public UserPipeBind(string id)
        {
            if (!int.TryParse(id, out _id))
            {
                _login = id;
            }
        }

        public UserPipeBind(User user)
        {
            _user = user;
        }

        public int Id => _id;

        public string Login => _login;

        public User User => _user;
    }
}
