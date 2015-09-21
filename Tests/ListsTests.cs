using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OfficeDevPnP.PowerShell.Tests
{
    [TestClass]
    public class ListsTests
    {
        [TestMethod]
        public void GetListTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Get-SPOList", null);

                Assert.IsTrue(results.Count > 0);
                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.List));

            }
        }
    }
}
