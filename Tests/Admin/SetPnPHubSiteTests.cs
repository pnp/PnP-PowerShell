using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Admin
{

    [TestClass]
    public class SetHubSiteTests
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
        public void SetPnPHubSiteTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPHubSite",new CommandParameter("Identity", "null"),new CommandParameter("Title", "null"),new CommandParameter("LogoUrl", "null"),new CommandParameter("Description", "null"),new CommandParameter("SiteDesignId", "null"),new CommandParameter("HideNameInNavigation", "null"),new CommandParameter("RequiresJoinApproval", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            