using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Provisioning.Site
{

    [TestClass]
    public class AddFileToProvisioningTemplateTests
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
        public void AddPnPFileToProvisioningTemplateTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPFileToProvisioningTemplate",new CommandParameter("Path", "null"),new CommandParameter("Source", "null"),new CommandParameter("SourceUrl", "null"),new CommandParameter("Folder", "null"),new CommandParameter("Container", "null"),new CommandParameter("FileLevel", "null"),new CommandParameter("FileOverwrite", "null"),new CommandParameter("TemplateProviderExtensions", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            