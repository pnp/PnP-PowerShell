using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Extensibility
{

    [TestClass]
    public class NewExtensibilityHandlerObjectTests
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
        public void NewPnPExtensibilityHandlerObjectTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("New-PnPExtensibilityHandlerObject",new CommandParameter("Assembly", "null"),new CommandParameter("Type", "null"),new CommandParameter("Configuration", "null"),new CommandParameter("Disabled", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            