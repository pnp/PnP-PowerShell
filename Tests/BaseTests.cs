using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using OfficeDevPnP.PowerShell.Commands.Base;
using OfficeDevPnP.PowerShell.Tests;
using System.Configuration;

namespace OfficeDevPnP.PowerShell.Tests
{
    [TestClass]
    public class BaseTests
    {
        [TestMethod]
        public void ConnectSPOnlineTest1()
        {
            using (var scope = new PSTestScope(false))
            {
                var results = scope.ExecuteCommand("Connect-SPOnline", new CommandParameter("Url", ConfigurationManager.AppSettings["SPODevSiteUrl"]));
                Assert.IsTrue(results.Count == 0);
            }
        }

        [TestMethod]
        public void ConnectSPOnlineTest2()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Get-SPOContext");

                Assert.IsTrue(results.Count == 1);
                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.ClientContext));

            }
        }

      
    }
}
