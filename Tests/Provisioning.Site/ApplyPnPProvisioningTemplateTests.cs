using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Provisioning.Site
{

    [TestClass]
    public class ApplyProvisioningTemplateTests
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
        public void ApplyPnPProvisioningTemplateTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Apply-PnPProvisioningTemplate",new CommandParameter("Path", "null"),new CommandParameter("TemplateId", "null"),new CommandParameter("ResourceFolder", "null"),new CommandParameter("OverwriteSystemPropertyBagValues", "null"),new CommandParameter("IgnoreDuplicateDataRowErrors", "null"),new CommandParameter("ProvisionContentTypesToSubWebs", "null"),new CommandParameter("ProvisionFieldsToSubWebs", "null"),new CommandParameter("ClearNavigation", "null"),new CommandParameter("Parameters", "null"),new CommandParameter("Handlers", "null"),new CommandParameter("ExcludeHandlers", "null"),new CommandParameter("ExtensibilityHandlers", "null"),new CommandParameter("TemplateProviderExtensions", "null"),new CommandParameter("InputInstance", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            