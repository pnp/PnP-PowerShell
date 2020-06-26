using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Branding
{

    [TestClass]
    public class SetThemeTests
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
        public void SetPnPThemeTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPTheme",new CommandParameter("ColorPaletteUrl", "null"),new CommandParameter("FontSchemeUrl", "null"),new CommandParameter("BackgroundImageUrl", "null"),new CommandParameter("ShareGenerated", "null"),new CommandParameter("ResetSubwebsToInherit", "null"),new CommandParameter("UpdateRootWebOnly", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            