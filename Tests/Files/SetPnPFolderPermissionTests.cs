using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Files
{

    [TestClass]
    public class SetFolderPermissionTests
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
        public void SetPnPFolderPermissionTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPFolderPermission",new CommandParameter("List", "null"),new CommandParameter("Identity", "null"),new CommandParameter("Group", "null"),new CommandParameter("User", "null"),new CommandParameter("AddRole", "null"),new CommandParameter("RemoveRole", "null"),new CommandParameter("ClearExisting", "null"),new CommandParameter("InheritPermissions", "null"),new CommandParameter("SystemUpdate", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            