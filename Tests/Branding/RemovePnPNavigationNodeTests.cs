using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Branding
{

    [TestClass]
    public class RemoveNavigationNodeTests
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
        public void RemovePnPNavigationNodeTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Remove-PnPNavigationNode",new CommandParameter("Identity", "null"),new CommandParameter("Location", "null"),new CommandParameter("Title", "null"),new CommandParameter("Header", "null"),new CommandParameter("All", "null"),new CommandParameter("Force", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            