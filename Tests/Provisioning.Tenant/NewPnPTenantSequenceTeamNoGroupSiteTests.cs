using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Provisioning.Tenant
{

    [TestClass]
    public class NewTenantSequenceTeamNoGroupSiteTests
    {
        #region Test Setup/CleanUp

        [TestInitialize]
        public void Initialize()
        {
            using (var scope = new PSTestScope())
            {
                // Example
                // scope.ExecuteCommand("cmdlet", new CommandParameter("param1", prop));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var scope = new PSTestScope())
            {
                try
                {

                }
                catch (Exception)
                {
                    // Describe Exception
                }
            }
        }

        #endregion

        #region Scaffolded Cmdlet Tests

        

        //TODO: This is a scaffold of the cmdlet - complete the unit test
        //[TestMethod]
        public void NewPnPTenantSequenceTeamNoGroupSiteTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("New-PnPTenantSequenceTeamNoGroupSite",new CommandParameter("Url", "null"),new CommandParameter("Title", "null"),new CommandParameter("TimeZoneId", "null"),new CommandParameter("Language", "null"),new CommandParameter("Owner", "null"),new CommandParameter("Description", "null"),new CommandParameter("HubSite", "null"),new CommandParameter("TemplateIds", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            