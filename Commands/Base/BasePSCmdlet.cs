using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base
{
    public class BasePSCmdlet : PSCmdlet
    {
        private Assembly newtonsoftAssembly;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            FixAssemblyResolving();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            System.AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }

        private void FixAssemblyResolving()
        {
            newtonsoftAssembly = System.Reflection.Assembly.LoadFrom(Path.Combine(AssemblyDirectory, "NewtonSoft.Json.dll"));
            System.AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

        }

        private string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("Newtonsoft.Json"))
            {
                return newtonsoftAssembly;
            }
            foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }
            return null;
        }

        public bool ParameterSpecified(string parameterName)
        {
            return MyInvocation.BoundParameters.ContainsKey(parameterName);
        }
    }
}
