#if !NETSTANDARD2_0
using Microsoft.Graph;
#endif
using SharePointPnP.PowerShell.Commands.Properties;
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
    /// <summary>
    /// Base class for all the PnP Microsoft Graph related cmdlets
    /// </summary>
    public abstract class PnPGraphCmdlet : PSCmdlet
    {
        private Assembly newtonsoftAssembly;
        public String AccessToken
        {
            get
            {
                if (SPOnlineConnection.AuthenticationResult != null)
                {
                    if (SPOnlineConnection.AuthenticationResult.ExpiresOn < DateTimeOffset.Now)
                    {
                        WriteWarning(Resources.MicrosoftGraphOAuthAccessTokenExpired);
                        SPOnlineConnection.AuthenticationResult = null;
                        return (null);
                    }
                    else
                    {
#if !NETSTANDARD2_0
                        return (SPOnlineConnection.AuthenticationResult.Token);
#else
                        return SPOnlineConnection.AuthenticationResult.AccessToken;
#endif
                    }
                }
                else if (SPOnlineConnection.CurrentConnection.AccessToken != null)
                {
                    return SPOnlineConnection.CurrentConnection.AccessToken;
                }
                else
                {
                    ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(Resources.NoAzureADAccessToken), "NO_OAUTH_TOKEN", ErrorCategory.ConnectionError, null));
                    return (null);
                }
            }
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

        private void FixAssemblyResolving()
        {
            newtonsoftAssembly = System.Reflection.Assembly.LoadFrom(Path.Combine(AssemblyDirectory, "NewtonSoft.Json.dll"));
            System.AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

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

        protected override void BeginProcessing()
        {

            base.BeginProcessing();

            FixAssemblyResolving();

#if !NETSTANDARD2_0

            if (SPOnlineConnection.CurrentConnection != null && SPOnlineConnection.CurrentConnection.ConnectionMethod == Model.ConnectionMethod.GraphDeviceLogin)
            {
                if (string.IsNullOrEmpty(SPOnlineConnection.CurrentConnection.AccessToken))
                {
                    throw new InvalidOperationException(Resources.NoAzureADAccessToken);
                }
            }
            else
            {
                if (SPOnlineConnection.AuthenticationResult == null ||
                String.IsNullOrEmpty(SPOnlineConnection.AuthenticationResult.Token))
                {
                    throw new InvalidOperationException(Resources.NoAzureADAccessToken);
                }
            }
#else
            if (SPOnlineConnection.CurrentConnection != null && (SPOnlineConnection.CurrentConnection.ConnectionMethod == Model.ConnectionMethod.GraphDeviceLogin || SPOnlineConnection.CurrentConnection.ConnectionMethod == Model.ConnectionMethod.AccessToken))
            {
                // Graph Connection
                if (string.IsNullOrEmpty(SPOnlineConnection.CurrentConnection.AccessToken))
                {
                    throw new InvalidOperationException(Resources.NoAzureADAccessToken);
                }
            }
            else
            {
                //Normal connection
                if (SPOnlineConnection.AuthenticationResult == null ||
                string.IsNullOrEmpty(SPOnlineConnection.AuthenticationResult.AccessToken))
                {
                    throw new InvalidOperationException(Resources.NoAzureADAccessToken);
                }
            }
#endif
        }

        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            ExecuteCmdlet();
        }

        protected override void EndProcessing()
        {
            System.AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }
    }
}
