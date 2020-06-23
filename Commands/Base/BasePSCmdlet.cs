using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Cmdlets
    /// </summary>
    public class BasePSCmdlet : PSCmdlet
    {
        private Assembly newtonsoftAssembly;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            FixAssemblyResolving();

            // Throw warning if an old *-SPO* cmdlet is being used
            if (MyInvocation.InvocationName.ToUpper().IndexOf("-SPO", StringComparison.Ordinal) > -1)
            {
                WriteWarning($"PnP Cmdlets starting with the SPO Prefix have been deprecated since the June 2017 release. Please update your scripts and use {MyInvocation.MyCommand.Name} instead.");
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }

        private void FixAssemblyResolving()
        {
            var newtonsoftAssemblyByLocation = Path.Combine(AssemblyDirectoryFromLocation, "Newtonsoft.Json.dll");
            if (File.Exists(newtonsoftAssemblyByLocation))
            {
                // Local run, network run, etc.
                newtonsoftAssembly = Assembly.LoadFrom(newtonsoftAssemblyByLocation);
            }
            else
            {
                // Running from Azure Function
                var newtonsoftAssemblyByCodeBase = Path.Combine(AssemblyDirectoryFromCodeBase, "Newtonsoft.Json.dll");
                newtonsoftAssembly = Assembly.LoadFrom(newtonsoftAssemblyByCodeBase);
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private string AssemblyDirectoryFromLocation
        {
            get
            {
                var location = Assembly.GetExecutingAssembly().Location;
                var escapedLocation = Uri.UnescapeDataString(location);
                return Path.GetDirectoryName(escapedLocation);
            }
        }

        private string AssemblyDirectoryFromCodeBase
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("NewtonSoft.Json", StringComparison.InvariantCultureIgnoreCase))
            {
                return newtonsoftAssembly;
            }
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a parameter with the provided name has been provided in the execution command
        /// </summary>
        /// <param name="parameterName">Name of the parameter to validate if it has been provided in the execution command</param>
        /// <returns>True if a parameter with the provided name is present, false if it is not</returns>
        public bool ParameterSpecified(string parameterName)
        {
            return MyInvocation.BoundParameters.ContainsKey(parameterName);
        }

        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            ExecuteCmdlet();
        }
    }
}
