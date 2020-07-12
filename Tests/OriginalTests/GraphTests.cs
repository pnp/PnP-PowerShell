using System;
using System.Management.Automation.Runspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharePointPnP.PowerShell.Tests
{
    [TestClass]
    public class GraphTests
    {
        private string _groupId;

        [TestInitialize]
        public void Initialize()
        {
            using (var scope = new PSTestScope())
            {
                var random = new Random();

                var group = scope.ExecuteCommand("New-PnPUnifiedGroup",
                        new CommandParameter("DisplayName", "PnPDeletedUnifiedGroup test"),
                        new CommandParameter("Description", "PnPDeletedUnifiedGroup test"),
                        new CommandParameter("MailNickname", $"pnp-unit-test-{random.Next(1, 1000)}"),
                        new CommandParameter("Force"));
                _groupId = group[0].Properties["GroupId"].Value.ToString();

                scope.ExecuteCommand("Remove-PnPUnifiedGroup", new CommandParameter("Identity", _groupId));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var scope = new PSTestScope())
            {
                try
                {
                    scope.ExecuteCommand("Remove-PnPUnifiedGroup", new CommandParameter("Identity", _groupId));
                }
                catch (Exception)
                {
                    // Group has already been deleted
                }
                try
                {
                    scope.ExecuteCommand("Remove-PnPDeletedUnifiedGroup", new CommandParameter("Identity", _groupId));
                }
                catch (Exception)
                {
                    // Group has already been permanently deleted
                }
            }
        }

        [TestMethod]
        public void GetDeletedUnifiedGroups()
        {
            using (var scope = new PSTestScope())
            {
                var results = scope.ExecuteCommand("Get-PnPDeletedUnifiedGroup");
                Assert.IsTrue(results.Count > 0);
            }
        }

        [TestMethod]
        public void GetDeletedUnifiedGroup()
        {
            using (var scope = new PSTestScope())
            {
                var results = scope.ExecuteCommand("Get-PnPDeletedUnifiedGroup", new CommandParameter("Identity", _groupId));

                Assert.IsTrue(results != null && results[0].Properties["GroupId"].Value.ToString() == _groupId);
            }
        }

        [TestMethod]
        public void RestoreDeletedUnifiedGroup()
        {
            using (var scope = new PSTestScope())
            {
                scope.ExecuteCommand("Restore-PnPDeletedUnifiedGroup", new CommandParameter("Identity", _groupId));
                var results = scope.ExecuteCommand("Get-PnPUnifiedGroup", new CommandParameter("Identity", _groupId));

                Assert.IsTrue(results != null && results[0].Properties["GroupId"].Value.ToString() == _groupId);
            }
        }

        [TestMethod]
        public void RemoveDeletedUnifiedGroup()
        {
            using (var scope = new PSTestScope())
            {
                scope.ExecuteCommand("Remove-PnPDeletedUnifiedGroup", new CommandParameter("Identity", _groupId));

                // The group should no longer be found in deleted groups
                try
                {
                    var results = scope.ExecuteCommand("Get-PnPDeletedUnifiedGroup", new CommandParameter("Identity", _groupId));
                    Assert.IsFalse(results != null);
                }
                catch (Exception)
                {
                    Assert.IsTrue(true);
                }
            }
        }
    }
}
