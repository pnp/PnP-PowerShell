using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.ClientSidePages
{

    [TestClass]
    public class MoveClientSideWebPartTests
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
        public void MovePnPClientSideComponentTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Move-PnPClientSideComponent",new CommandParameter("Page", "null"),new CommandParameter("InstanceId", "null"),new CommandParameter("Section", "null"),new CommandParameter("Column", "null"),new CommandParameter("Position", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            