using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Provisioning.Tenant
{

    [TestClass]
    public class NewTenantSequenceTeamNoGroupSubSiteTests
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
        public void NewPnPTenantSequenceTeamNoGroupSubSiteTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("New-PnPTenantSequenceTeamNoGroupSubSite",new CommandParameter("Url", "null"),new CommandParameter("Title", "null"),new CommandParameter("TimeZoneId", "null"),new CommandParameter("Language", "null"),new CommandParameter("Description", "null"),new CommandParameter("TemplateIds", "null"),new CommandParameter("QuickLaunchDisabled", "null"),new CommandParameter("UseDifferentPermissionsFromParentSite", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            