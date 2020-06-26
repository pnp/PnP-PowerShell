using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Taxonomy
{

    [TestClass]
    public class SetTaxonomyFieldValueTests
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
        public void SetPnPTaxonomyFieldValueTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPTaxonomyFieldValue",new CommandParameter("ListItem", "null"),new CommandParameter("InternalFieldName", "null"),new CommandParameter("TermId", "null"),new CommandParameter("Label", "null"),new CommandParameter("TermPath", "null"),new CommandParameter("Terms", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            