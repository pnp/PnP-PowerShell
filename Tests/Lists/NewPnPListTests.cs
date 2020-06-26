using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Lists
{

    [TestClass]
    public class NewListTests
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
        public void NewPnPListTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("New-PnPList",new CommandParameter("Title", "null"),new CommandParameter("Template", "null"),new CommandParameter("Url", "null"),new CommandParameter("Hidden", "null"),new CommandParameter("EnableVersioning", "null"),new CommandParameter("QuickLaunchOptions", "null"),new CommandParameter("EnableContentTypes", "null"),new CommandParameter("OnQuickLaunch", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            