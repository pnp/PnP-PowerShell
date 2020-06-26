using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Fields
{

    [TestClass]
    public class AddTaxonomyFieldTests
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
        public void AddPnPTaxonomyFieldTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPTaxonomyField",new CommandParameter("List", "null"),new CommandParameter("DisplayName", "null"),new CommandParameter("InternalName", "null"),new CommandParameter("TermSetPath", "null"),new CommandParameter("TaxonomyItemId", "null"),new CommandParameter("TermPathDelimiter", "null"),new CommandParameter("Group", "null"),new CommandParameter("Id", "null"),new CommandParameter("AddToDefaultView", "null"),new CommandParameter("MultiValue", "null"),new CommandParameter("Required", "null"),new CommandParameter("FieldOptions", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            