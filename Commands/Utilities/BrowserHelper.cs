#if !NETSTANDARD2_0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    internal static class BrowserHelper
    {
        public static void OpenBrowser(string url, System.Drawing.Icon icon = null)
        {
            var thread = new Thread(() =>
            {
                var form = new System.Windows.Forms.Form();
                if (icon != null)
                {
                    form.Icon = icon;
                }
                var browser = new System.Windows.Forms.WebBrowser
                {
                    ScriptErrorsSuppressed = true,
                    Dock = DockStyle.Fill
                };

                form.SuspendLayout();
                form.Width = 450;
                form.Height = 600;
                form.Text = $"Authenticate";
                form.Controls.Add(browser);
                form.ResumeLayout(false);
                browser.Navigated += (sender, args) =>
                {
                    if (browser.Url.Equals("https://login.microsoftonline.com/common/login") || browser.Url.ToString().ToLower().StartsWith("https://login.microsoftonline.com/common/reprocess"))
                    {
                        form.Close();
                    }
                };
                browser.Navigate(url);

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