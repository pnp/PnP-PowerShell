using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;
using Microsoft.SharePoint.Client;
using System.Linq;
using OfficeDevPnP.Core.Enums;

namespace OfficeDevPnP.PowerShell.Tests
{
    [TestClass]
    public class BrandingTests
    {
        [TestMethod]
        public void AddCustomActionTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPOCustomAction",
                    new CommandParameter("Name", "TestCustomAction"),
                    new CommandParameter("Title", "TestCustomAction"),
                    new CommandParameter("Description", "Test Custom Action Description"),
                    new CommandParameter("Group", "ActionsMenu"),
                    new CommandParameter("Location", "Microsoft.SharePoint.StandardMenu")
                    );


                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.LoadQuery(context.Web.UserCustomActions.Where(ca => ca.Name == "TestCustomAction"));
                    context.ExecuteQueryRetry();

                    Assert.IsTrue(actions.Any());

                    actions.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void AddJavascriptBlockTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPOJavascriptBlock",
                    new CommandParameter("Name", "TestJavascriptBlock"),
                    new CommandParameter("Script", "<script type='text/javascript'>alert('1')</script>"));


                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptBlock");
                    Assert.IsTrue(actions.Any());

                    actions.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void AddJavascriptLinkTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPOJavascriptLink",
                    new CommandParameter("Key", "TestJavascriptLink"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));


                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptLink");
                    Assert.IsTrue(actions.Any());

                    actions.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void AddNavigationNodeTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPONavigationNode",
                    new CommandParameter("Location", NavigationType.QuickLaunch),
                    new CommandParameter("Title", "Test Navigation Item"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));


                using (var context = TestCommon.CreateClientContext())
                {
                    var nodes = context.LoadQuery(context.Web.Navigation.QuickLaunch.Where(n => n.Title == "Test Navigation Item"));
                    context.ExecuteQueryRetry();

                    Assert.IsTrue(nodes.Any());

                    nodes.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void GetCustomActionTest()
        {
            using (var scope = new PSTestScope(true))
            {
                scope.ExecuteCommand("Add-SPOJavascriptLink",
                    new CommandParameter("Key", "TestJavascriptLink"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));

                var results = scope.ExecuteCommand("Get-SPOCustomAction");

                Assert.IsTrue(results.Any());

                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptLink");

                    actions.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void GetJavaScriptLinkTest()
        {
            using (var scope = new PSTestScope(true))
            {
                scope.ExecuteCommand("Add-SPOJavascriptLink",
                    new CommandParameter("Key", "TestJavascriptLink"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));

                var results = scope.ExecuteCommand("Get-SPOJavaScriptLink");

                Assert.IsTrue(results.Any());

                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptLink");

                    actions.FirstOrDefault().DeleteObject();
                    context.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        [Ignore]
        public void GetProvisioningTemplateTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Get-SPOProvisioningTemplate");

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results.FirstOrDefault().BaseObject.GetType() == typeof(string));
            }
        }

        [TestMethod]
        public void RemoveCustomActionTest()
        {
            using (var scope = new PSTestScope(true))
            {
                scope.ExecuteCommand("Add-SPOCustomAction",
                    new CommandParameter("Name", "TestCustomAction"),
                    new CommandParameter("Title", "TestCustomAction"),
                    new CommandParameter("Description", "Test Custom Action Description"),
                    new CommandParameter("Group", "ActionsMenu"),
                    new CommandParameter("Location", "Microsoft.SharePoint.StandardMenu")
                    );


                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.LoadQuery(context.Web.UserCustomActions.Where(ca => ca.Name == "TestCustomAction"));
                    context.ExecuteQueryRetry();

                    Assert.IsTrue(actions.Any());

                    var id = actions.FirstOrDefault().Id;

                    scope.ExecuteCommand("Remove-SPOCustomAction",
                        new CommandParameter("Identity", id),
                        new CommandParameter("Force", true));

                    actions = context.LoadQuery(context.Web.UserCustomActions.Where(ca => ca.Name == "TestCustomAction"));
                    context.ExecuteQueryRetry();

                    Assert.IsFalse(actions.Any());
                }
            }
        }

        [TestMethod]
        public void RemoveJavascriptLinkTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPOJavascriptLink",
                    new CommandParameter("Key", "TestJavascriptLink"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));


                using (var context = TestCommon.CreateClientContext())
                {
                    var actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptLink");
                    Assert.IsTrue(actions.Any());

                    var name = actions.FirstOrDefault().Name;

                    scope.ExecuteCommand("Remove-SPOJavaScriptLink",
                        new CommandParameter("Name", name),
                        new CommandParameter("Force", true));

                    actions = context.Web.GetCustomActions().Where(c => c.Location == "ScriptLink" && c.Name == "TestJavascriptLink");
                    Assert.IsFalse(actions.Any());

                }
            }
        }

        [TestMethod]
        public void RemoveNavigationNodeTest()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Add-SPONavigationNode",
                    new CommandParameter("Location", NavigationType.QuickLaunch),
                    new CommandParameter("Title", "Test Navigation Item"),
                    new CommandParameter("Url", "https://testserver.com/testtojavascriptlink.js"));


                using (var context = TestCommon.CreateClientContext())
                {
                    var nodes = context.LoadQuery(context.Web.Navigation.QuickLaunch.Where(n => n.Title == "Test Navigation Item"));
                    context.ExecuteQueryRetry();

                    Assert.IsTrue(nodes.Any());

                    scope.ExecuteCommand("Remove-SPONavigationNode",
                        new CommandParameter("Location", NavigationType.QuickLaunch),
                        new CommandParameter("Title", "Test Navigation Item"),
                        new CommandParameter("Force", true)
                     );

                    nodes = context.LoadQuery(context.Web.Navigation.QuickLaunch.Where(n => n.Title == "Test Navigation Item"));
                    context.ExecuteQueryRetry();

                    Assert.IsFalse(nodes.Any());
                }
            }
        }
    }
}

