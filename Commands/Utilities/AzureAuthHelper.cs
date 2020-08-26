#if !PNPPSCORE
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Azure.ActiveDirectory.GraphClient.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PnP.PowerShell.Commands.Utilities
{
    public static class AzureAuthHelper
    {
        private static string CLIENTID = "1950a258-227b-4e31-a9cf-717495945fc2"; // Well-known Azure Management App Id
        internal static async Task<string> AuthenticateAsync(string tenantId, string loginEndPoint = "https://login.microsoftonline.com" )
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                throw new ArgumentException($"{nameof(tenantId)} is required");
            }

            var authority = $"{loginEndPoint}/{tenantId}";
            var scopes = new string[] { "https://graph.microsoft.com/.default" };
            var app = PublicClientApplicationBuilder.Create(CLIENTID).WithAuthority(authority).Build();
            var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
            return result.AccessToken;
        }

        internal static void OpenConsentFlow(string url, Action<string> messageAction)
        {
            var thread = new Thread(() =>
            {
                var maxRetry = 5;
                var retryCount = 0;
                var form = new System.Windows.Forms.Form();
                var browser = new System.Windows.Forms.WebBrowser
                {
                    ScriptErrorsSuppressed = true,
                    Dock = DockStyle.Fill
                };

                form.SuspendLayout();
                form.Width = 1024;
                form.Height = 800;
                form.Text = $"Consent";
                form.Controls.Add(browser);
                form.ResumeLayout(false);

                browser.Navigate(url);

                browser.Navigated += (sender, args) =>
                {
                    if (args.Url.Query.Contains("admin_consent=True"))
                    {
                        form.Close();
                    }
                    if (args.Url.Query.Contains("error="))
                    {
                        var query = HttpUtility.ParseQueryString(args.Url.Query);
                        messageAction?.Invoke(query.Get("error"));
                        retryCount++;
                        
                        if (retryCount < maxRetry)
                        {
                            browser.Navigate(url);
                        }
                    }
                };

                form.Focus();
                form.ShowDialog();
                browser.Dispose();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
#endif