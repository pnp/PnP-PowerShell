using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Principals
{

    [TestClass]
    public class AddAlertTests
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
        public void AddPnPAlertTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPAlert",new CommandParameter("List", "null"),new CommandParameter("Title", "null"),new CommandParameter("User", "null"),new CommandParameter("DeliveryMethod", "null"),new CommandParameter("ChangeType", "null"),new CommandParameter("Frequency", "null"),new CommandParameter("Filter", "null"),new CommandParameter("Time", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            