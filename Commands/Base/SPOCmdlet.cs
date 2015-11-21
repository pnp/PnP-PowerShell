using System;
using System.Management.Automation;
using System.Threading;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using OfficeDevPnP.PowerShell.Commands.Base;
using Resources = OfficeDevPnP.PowerShell.Commands.Properties.Resources;
using System.Collections.Generic;

namespace OfficeDevPnP.PowerShell.Commands
{
    public class SPOCmdlet : PSCmdlet
    {
        public ClientContext ClientContext
        {
            get { return SPOnlineConnection.CurrentConnection.Context; }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (SPOnlineConnection.CurrentConnection == null)
            {
                throw new InvalidOperationException(Resources.NoConnection);
            }
            if (ClientContext == null)
            {
                throw new InvalidOperationException(Resources.NoConnection);
            }

        }

        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            SPOnlineConnection.MonitoredScope.LogInfo("Executing {0}", this.MyInvocation.InvocationName);
            try
            {
                if (SPOnlineConnection.CurrentConnection.MinimalHealthScore != -1)
                {
                    int healthScore = Utility.GetHealthScore(SPOnlineConnection.CurrentConnection.Url);
                    if (healthScore <= SPOnlineConnection.CurrentConnection.MinimalHealthScore)
                    {
                        ExecuteCmdlet();
                    }
                    else
                    {
                        if (SPOnlineConnection.CurrentConnection.RetryCount != -1)
                        {
                            int retry = 1;
                            while (retry <= SPOnlineConnection.CurrentConnection.RetryCount)
                            {
                                WriteWarning(string.Format(Resources.Retry0ServerNotHealthyWaiting1seconds, retry, SPOnlineConnection.CurrentConnection.RetryWait, healthScore));
                                Thread.Sleep(SPOnlineConnection.CurrentConnection.RetryWait * 1000);
                                healthScore = Utility.GetHealthScore(SPOnlineConnection.CurrentConnection.Url);
                                if (healthScore <= SPOnlineConnection.CurrentConnection.MinimalHealthScore)
                                {
                                    ExecuteCmdlet();
                                    break;
                                }
                                retry++;
                            }
                            if (retry > SPOnlineConnection.CurrentConnection.RetryCount)
                            {
                                SPOnlineConnection.MonitoredScope.LogError("Health Score not sufficient: requested {0}, actualy {1}", SPOnlineConnection.CurrentConnection.MinimalHealthScore, healthScore);
                                WriteError(new ErrorRecord(new Exception(Resources.HealthScoreNotSufficient), "HALT", ErrorCategory.LimitsExceeded, null));
                            }
                        }
                        else
                        {
                            SPOnlineConnection.MonitoredScope.LogError("Health Score not sufficient: requested {0}, actualy {1}", SPOnlineConnection.CurrentConnection.MinimalHealthScore, healthScore);
                            WriteError(new ErrorRecord(new Exception(Resources.HealthScoreNotSufficient), "HALT", ErrorCategory.LimitsExceeded, null));
                        }
                    }
                }
                else
                {
                    ExecuteCmdlet();
                }
            }
            catch (Exception ex)
            {
                SPOnlineConnection.CurrentConnection.RestoreCachedContext(SPOnlineConnection.CurrentConnection.Url);
                WriteError(new ErrorRecord(ex, "EXCEPTION", ErrorCategory.WriteError, null));
                SPOnlineConnection.MonitoredScope.LogError(ex.Message);
            }
            SPOnlineConnection.MonitoredScope.LogInfo("Finished {0}", this.MyInvocation.InvocationName);
        }

    }
}
