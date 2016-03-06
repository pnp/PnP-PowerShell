using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands.WebParts
{
    [Cmdlet(VerbsCommon.Get, "SPOWebPartXml")]
    [CmdletHelp("Returns the webpart XML of a webpart registered on a site",
        Category = CmdletHelpCategory.WebParts)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWebPartXml -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -Identity a2875399-d6ff-43a0-96da-be6ae5875f82",
        Remarks = @"Returns the webpart XML for a given webpart on a page.", SortOrder = 1)]
    public class GetWebPartXml : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Full server relative url of the webpart page, e.g. /sites/mysite/sitepages/home.aspx")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Id or title of the webpart. Use Get-SPOWebPart to retrieve all webpart Ids")]
        public WebPartPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }

            Guid id = Guid.Empty;
            if (Identity.Id == Guid.Empty)
            {
                var wp = SelectedWeb.GetWebParts(ServerRelativePageUrl).FirstOrDefault(wps => wps.WebPart.Title == Identity.Title);
                if (wp != null)
                {
                    id = wp.Id;
                }
                else
                {
                    throw new Exception(string.Format("Web Part with title '{0}' cannot be found on page with URL {1}", Identity.Title, ServerRelativePageUrl));
                }
            }
            else
            {
                id = Identity.Id;
            }

            var uri = new Uri(ClientContext.Url);

            var hostUri = uri.Host;
            var webUrl = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, SelectedWeb.ServerRelativeUrl);
            var pageUrl = string.Format("{0}://{1}{2}", uri.Scheme, uri.Host, ServerRelativePageUrl);
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/_vti_bin/exportwp.aspx?pageurl={1}&guidstring={2}", webUrl, pageUrl, id.ToString()));

            if (SPOnlineConnection.CurrentConnection.ConnectionType == Enums.ConnectionType.O365)
            {
                var credentials = ClientContext.Credentials as SharePointOnlineCredentials;

                var authCookieValue = credentials.GetAuthenticationCookie(uri);

                Cookie fedAuth = new Cookie()
                {
                    Name = "SPOIDCRL",
                    Value = authCookieValue.TrimStart("SPOIDCRL=".ToCharArray()),
                    Path = "/",
                    Secure = true,
                    HttpOnly = true,
                    Domain = uri.Host
                };
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(fedAuth);
            }
            else
            {
                CredentialCache credentialCache = new CredentialCache();
                credentialCache.Add(new Uri(webUrl), "NTLM", ClientContext.Credentials as NetworkCredential);
                request.Credentials = credentialCache;
            }

            var response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string responseString = reader.ReadToEnd();
                WriteObject(responseString);
            }

        }

    }
}
