using Microsoft.Graph;
using SharePointPnP.PowerShell.Commands.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Microsoft Graph related cmdlets
    /// </summary>
    public abstract class PnPGraphCmdlet : PSCmdlet
    {
        public String AccessToken
        {
            get
            {
                return (PnPAzureADConnection.AccessToken);
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (String.IsNullOrEmpty(PnPAzureADConnection.AccessToken))
            {
                throw new InvalidOperationException(Resources.NoAzureADAccessToken);
            }
        }

        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            ExecuteCmdlet();
        }
    }
}
