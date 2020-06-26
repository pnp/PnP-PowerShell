using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Taxonomy
{

    [TestClass]
    public class NewTermTests
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
        public void NewPnPTermTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("New-PnPTerm",new CommandParameter("Name", "null"),new CommandParameter("Id", "null"),new CommandParameter("Lcid", "null"),new CommandParameter("TermSet", "null"),new CommandParameter("TermGroup", "null"),new CommandParameter("Description", "null"),new CommandParameter("CustomProperties", "null"),new CommandParameter("LocalCustomProperties", "null"),new CommandParameter("TermStore", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            