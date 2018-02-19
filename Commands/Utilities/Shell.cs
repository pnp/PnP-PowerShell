using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    public static class Shell
    {
        public static string Bash(string cmd)
        {
            string result = Run("/bin/bash", $@"-c ""{cmd}""");
            return result;
        }

        public static string Bat(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            string result = Run("cmd.exe", $@"/c ""{escapedArgs}""");
            return result;
        }


        private static string Run(string filename, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}
