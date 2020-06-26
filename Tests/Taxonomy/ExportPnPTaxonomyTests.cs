using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Taxonomy
{

    [TestClass]
    public class ExportTaxonomyTests
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
        public void ExportPnPTaxonomyTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Export-PnPTaxonomy",new CommandParameter("TermSetId", "null"),new CommandParameter("IncludeID", "null"),new CommandParameter("Path", "null"),new CommandParameter("TermStoreName", "null"),new CommandParameter("Force", "null"),new CommandParameter("Delimiter", "null"),new CommandParameter("Lcid", "null"),new CommandParameter("Encoding", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            