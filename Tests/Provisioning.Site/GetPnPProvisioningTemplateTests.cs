using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Provisioning.Site
{

    [TestClass]
    public class GetProvisioningTemplateTests
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
        public void GetPnPProvisioningTemplateTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Get-PnPProvisioningTemplate",new CommandParameter("Out", "null"),new CommandParameter("Schema", "null"),new CommandParameter("IncludeAllTermGroups", "null"),new CommandParameter("IncludeSiteCollectionTermGroup", "null"),new CommandParameter("IncludeSiteGroups", "null"),new CommandParameter("IncludeTermGroupsSecurity", "null"),new CommandParameter("IncludeSearchConfiguration", "null"),new CommandParameter("PersistBrandingFiles", "null"),new CommandParameter("PersistComposedLookFiles", "null"),new CommandParameter("PersistPublishingFiles", "null"),new CommandParameter("IncludeNativePublishingFiles", "null"),new CommandParameter("IncludeHiddenLists", "null"),new CommandParameter("IncludeAllClientSidePages", "null"),new CommandParameter("SkipVersionCheck", "null"),new CommandParameter("PersistMultiLanguageResources", "null"),new CommandParameter("ResourceFilePrefix", "null"),new CommandParameter("Handlers", "null"),new CommandParameter("ExcludeHandlers", "null"),new CommandParameter("ExtensibilityHandlers", "null"),new CommandParameter("TemplateProviderExtensions", "null"),new CommandParameter("ContentTypeGroups", "null"),new CommandParameter("Force", "null"),new CommandParameter("NoBaseTemplate", "null"),new CommandParameter("Encoding", "null"),new CommandParameter("TemplateDisplayName", "null"),new CommandParameter("TemplateImagePreviewUrl", "null"),new CommandParameter("TemplateProperties", "null"),new CommandParameter("OutputInstance", "null"),new CommandParameter("ExcludeContentTypesFromSyndication", "null"),new CommandParameter("ListsToExtract", "null"),new CommandParameter("Configuration", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            