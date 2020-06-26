using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Branding
{

    [TestClass]
    public class AddCustomActionTests
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
        public void AddPnPCustomActionTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPCustomAction",new CommandParameter("Name", "null"),new CommandParameter("Title", "null"),new CommandParameter("Description", "null"),new CommandParameter("Group", "null"),new CommandParameter("Location", "null"),new CommandParameter("Sequence", "null"),new CommandParameter("Url", "null"),new CommandParameter("ImageUrl", "null"),new CommandParameter("CommandUIExtension", "null"),new CommandParameter("RegistrationId", "null"),new CommandParameter("Rights", "null"),new CommandParameter("RegistrationType", "null"),new CommandParameter("Scope", "null"),new CommandParameter("ClientSideComponentId", "null"),new CommandParameter("ClientSideComponentProperties", "null"),new CommandParameter("ClientSideHostProperties", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            