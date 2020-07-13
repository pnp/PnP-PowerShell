using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    public static class Clipboard
    {
        public static void Copy(string val)
        {
#if !NETSTANDARD2_1
            System.Windows.Forms.Clipboard.SetText(val);
#else
            var tempfile = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(tempfile, val);
            if (OperatingSystem.IsWindows())
            {
                var cmd = $"clip < {tempfile}";
                Shell.Bat(cmd);
            }

            if (OperatingSystem.IsMacOS())
            {
                var cmd = $"pbcopy < {tempfile}";
                Shell.Bash(cmd);
            }
            System.IO.File.Delete(tempfile);
#endif
        }

        public static void CopyNew(string value)
        {
            Exception threadEx = null;
            Thread staThread = new Thread(

             delegate ()
             {
                 try
                 {
                     System.Windows.Forms.Clipboard.SetText(value);
                 }

                 catch (Exception ex)
                 {
                     threadEx = ex;
                 }
             });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }
    }
}
