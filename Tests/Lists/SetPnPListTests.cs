using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Lists
{

    [TestClass]
    public class SetListTests
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
        public void SetPnPListTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPList",new CommandParameter("Identity", "null"),new CommandParameter("EnableContentTypes", "null"),new CommandParameter("BreakRoleInheritance", "null"),new CommandParameter("ResetRoleInheritance", "null"),new CommandParameter("CopyRoleAssignments", "null"),new CommandParameter("ClearSubscopes", "null"),new CommandParameter("Title", "null"),new CommandParameter("Description", "null"),new CommandParameter("Hidden", "null"),new CommandParameter("ForceCheckout", "null"),new CommandParameter("ListExperience", "null"),new CommandParameter("EnableAttachments", "null"),new CommandParameter("EnableFolderCreation", "null"),new CommandParameter("EnableVersioning", "null"),new CommandParameter("EnableMinorVersions", "null"),new CommandParameter("MajorVersions", "null"),new CommandParameter("MinorVersions", "null"),new CommandParameter("EnableModeration", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            