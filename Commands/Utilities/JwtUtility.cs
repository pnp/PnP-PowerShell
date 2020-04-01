using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    internal static class JwtUtility
    {
        public static bool HasScope(string accessToken, string scope)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var scpClaim = token.Claims.FirstOrDefault(c => c.Type == "scp");
            var rolesClaim = token.Claims.FirstOrDefault(c => c.Type == "roles");
            if(scpClaim != null)
            {
                // delegated token
                return scpClaim.Value.Contains(scope);
            }
            if(rolesClaim != null)
            {
                return rolesClaim.Value.Contains(scope);
            }
            return false;
        }
    }
}
