#if !ONPREMISES

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    internal static class ModernPagesUtilities
    {
        private static int PageCount = 0;

        private const string DefaultPageName = "Page {0}.aspx";

        public static string EnsurePageName(string pageName, bool defaultName=true)
        {
            if (string.IsNullOrEmpty(pageName))
                return defaultName
                    ? string.Format(DefaultPageName, ++PageCount)
                    : null;

            if (!pageName.EndsWith(".aspx"))
                pageName += ".aspx";

            return pageName;
        }
    }
}
#endif
