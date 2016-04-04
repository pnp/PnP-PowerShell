using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.Client;
using System.Management.Automation.Runspaces;
using System.Collections;
using System.Linq;
using OfficeDevPnP.PowerShell.Tests;
using System.Collections.Generic;

namespace OfficeDevPnP.PowerShell.Tests
{
    [TestClass]
    public class InvokeActionTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Cleanup();

            using (var ctx = TestCommon.CreateClientContext())
            {
                AddList(ctx.Web, "PnPTestList1", 2, "Test1");
                AddList(ctx.Web, "PnPTestList2", 3, "Test2");
            }
        }
        
        private void AddList(Web web, string listName, int listItemCount, string listItemPrefix)
        {
            List list = web.CreateList(ListTemplateType.GenericList, listName, false);

            for (int i = 1; i <= listItemCount; i++)
            {
                AddListItem(list, listItemPrefix + "-" + i);
            }
        }

        public void SetupSubWebs(Web web, bool addLists)
        {
            DeleteSubWebs(web);
            web.Context.Load(web, item => item.WebTemplate, item => item.Language);
            web.Context.ExecuteQueryRetry();

            //Level 1
            //  1-1
            //      1-1-1
            //      1-1-2
            //  1-2
            //      1-2-1
            //          1-2-1-1
            //  1-3

            //Web is Level 1
            Web web1 = web;

            //Level 2
            Web Web1_1 = web1.CreateWeb("SubWeb-1-1", "SubWeb-1-1", "PnPTest", web.WebTemplate, (int)web.Language);

            //Level 3
            Web Web1_1_1 = Web1_1.CreateWeb("SubWeb-1-1-1", "SubWeb-1-1-1", "PnPTest", web.WebTemplate, (int)web.Language);
            Web Web1_1_2 = Web1_1.CreateWeb("SubWeb-1-1-2", "SubWeb-1-1-2", "PnPTest", web.WebTemplate, (int)web.Language);

            //Level2
            Web Web1_2 = web1.CreateWeb("SubWeb-1-2", "SubWeb-1-2", "PnPTest", web.WebTemplate, (int)web.Language);

            //Level 3
            Web Web1_2_1 = Web1_2.CreateWeb("SubWeb-1-2-1", "SubWeb-1-2-1", "PnPTest", web.WebTemplate, (int)web.Language);

            //Level 4
            Web Web1_2_1_1 = Web1_2_1.CreateWeb("SubWeb-1-1", "SubWeb-1-2-1-1", "PnPTest", web.WebTemplate, (int)web.Language);

            //Level2
            Web Web1_3 = web1.CreateWeb("SubWeb-1-3", "SubWeb-1-3", "PnPTest", web.WebTemplate, (int)web.Language);

            if(addLists)
            {
                AddList(Web1_1, "PnPTestList1-1", 3, "Test2-1");
                AddList(Web1_1_1, "PnPTestList1-1-1", 3, "Test2-1-1");
                AddList(Web1_1_2, "PnPTestList1-1-2", 3, "Test2-1-2");
                AddList(Web1_2, "PnPTestList1-2", 3, "Test2-2");
                AddList(Web1_2_1, "PnPTestList1-2-1", 3, "Test2-2-1");
                AddList(Web1_2_1_1, "PnPTestList1-2-1-1", 3, "Test2-2-1-1");
                AddList(Web1_3, "PnPTestList1-3", 3, "Test2-3");
            }
        }

        private void DeleteSubWebs(Web web)
        {
            //Site site = web.Context.GetSiteCollectionContext().Site;
            //IEnumerable<string> webUrls = site.GetAllWebUrls().Where(item => item != site.Url);

            web.Context.Load(web, item => item.Webs);
            web.Context.ExecuteQueryRetry();

            for (int i = web.Webs.Count -1 ; i >= 0; i--)
            {
                Web subWeb = web.Webs[i];
                DeleteSubWebs(subWeb);
            }

            if (web.IsSubSite())
            {
                web.DeleteObject();
                web.Context.ExecuteQueryRetry();
            }
        }

        private void AddListItem(List list, string title)
        {
            var item = list.AddItem(new ListItemCreationInformation());
            item["Title"] = title;
            item.Update();

            list.Context.ExecuteQueryRetry();
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var ctx = TestCommon.CreateClientContext())
            {
                var list = ctx.Web.GetListByTitle("PnPTestList1");
                if (list != null)
                {
                    list.DeleteObject();
                    ctx.ExecuteQueryRetry();
                }

                list = ctx.Web.GetListByTitle("PnPTestList2");
                if (list != null)
                {
                    list.DeleteObject();
                    ctx.ExecuteQueryRetry();
                }
            }
        }

        [TestMethod]
        public void InvokeWebActionWebAction()
        {
            using (var scope = new PSTestScope(true))
            {
                Guid id = Guid.Empty;

                Action<Web> webAction = web =>
                {
                    id = web.Id;
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("WebAction", webAction),
                    new CommandParameter("WebProperties", new[] { "Id" })
                );

                Assert.IsTrue(id != Guid.Empty);
            }
        }

        [TestMethod]
        public void InvokeWebActionWebActionWithSubWebs()
        {
            using (var scope = new PSTestScope(true))
            {
                List<Guid> ids = new List<Guid>();
                List<string> titles = new List<string>();

                using (var context = TestCommon.CreateClientContext())
                {
                    SetupSubWebs(context.Web, false);
                }

                Action<Web> webAction = web =>
                {
                    ids.Add(web.Id);
                    titles.Add(web.Title);
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("WebAction", webAction),
                    new CommandParameter("WebProperties", new[] { "Id", "Title" }),
                    new CommandParameter("SubWebs", true)
                );

                using (var context = TestCommon.CreateClientContext())
                {
                    DeleteSubWebs(context.Web);
                }

                Assert.IsTrue(ids.Count == 8);

                foreach (var item in ids)
                {
                    Assert.IsTrue(item != Guid.Empty);
                }
            }
        }

        [TestMethod]
        public void InvokeWebActionWebActionWithMultipleWebs()
        {
            using (var scope = new PSTestScope(true))
            {
                List<ClientContext> clientContexts = new List<ClientContext>()
                {
                    TestCommon.CreateClientContext(),
                    TestCommon.CreateClientContext(),
                    TestCommon.CreateClientContext()
                };

                Web[] webs = clientContexts.Select(item => item.Web).ToArray();

                List<Guid> ids = new List<Guid>();
                List<string> titles = new List<string>();

                Action<Web> webAction = web =>
                {
                    ids.Add(web.Id);
                    titles.Add(web.Title);
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("Webs", webs),
                    new CommandParameter("WebAction", webAction),
                    new CommandParameter("WebProperties", new[] { "Id", "Title" })
                );

                foreach (var clientContext in clientContexts)
                {
                    clientContext.Dispose();
                }

                Assert.IsTrue(ids.Count == webs.Length);

                for (int i = 0; i < webs.Length; i++)
                {
                    Assert.IsTrue(ids[i] != Guid.Empty, "Guid is Empty");
                    Assert.IsTrue(ids[i] == webs[i].Id, "Guid are not in correct order");
                }
            }
        }

        [TestMethod]
        public void InvokeWebActionListAction()
        {
            using (var scope = new PSTestScope(true))
            {
                List<string> listNames = new List<string>();

                Action<List> listAction = list =>
                {
                    listNames.Add(list.Title);
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("ListAction", listAction),
                    new CommandParameter("ListProperties", new[] { "Title" })
                );

                Assert.IsTrue(listNames.Count > 2);

                Assert.IsTrue(listNames.Contains("PnPTestList1"));
                Assert.IsTrue(listNames.Contains("PnPTestList2"));
            }
        }

        [TestMethod]
        public void InvokeWebActionListActionWithShouldProcess()
        {
            using (var scope = new PSTestScope(true))
            {
                List<string> listNames = new List<string>();

                Action<List> listAction = list =>
                {
                    listNames.Add(list.Title);
                };

                Func<List, bool> shouldProcessListAction = list =>
                {
                    return list.Title.Contains("PnPTestList");
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("ListAction", listAction),
                    new CommandParameter("ShouldProcessListAction", shouldProcessListAction),
                    new CommandParameter("ListProperties", new[] { "Title" })
                );

                Assert.IsTrue(listNames.Count == 2);

                Assert.IsTrue(listNames.Contains("PnPTestList1"));
                Assert.IsTrue(listNames.Contains("PnPTestList2"));
            }
        }

        [TestMethod]
        public void InvokeWebActionListItemAction()
        {
            using (var scope = new PSTestScope(true))
            {
                List<string> listItemTitles = new List<string>();

                Action<ListItem> listItemAction = listItem =>
                {
                    listItemTitles.Add(listItem["Title"]?.ToString());
                };

                Func<List, bool> shouldProcessListAction = list =>
                {
                    return list.Title.Contains("PnPTestList");
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("ListItemAction", listItemAction),
                    new CommandParameter("ShouldProcessListAction", shouldProcessListAction)
                    //new CommandParameter("ListItemProperties", new[] { "Title" })
                );

                Assert.IsTrue(listItemTitles.Count == 5);

                Assert.IsTrue(listItemTitles.Contains("Test1-1"));
                Assert.IsTrue(listItemTitles.Contains("Test1-2"));

                Assert.IsTrue(listItemTitles.Contains("Test2-1"));
                Assert.IsTrue(listItemTitles.Contains("Test2-2"));
                Assert.IsTrue(listItemTitles.Contains("Test2-3"));
            }
        }

        [TestMethod]
        public void InvokeWebActionListItemActionWithShouldProcess()
        {
            using (var scope = new PSTestScope(true))
            {
                List<string> listItemTitles = new List<string>();

                Action<ListItem> listItemAction = listItem =>
                {
                    listItemTitles.Add(listItem["Title"]?.ToString());
                };

                Func<List, bool> shouldProcessListAction = list =>
                {
                    return list.Title.Contains("PnPTestList");
                };

                Func<ListItem, bool> shouldProcessListItemAction = listItem =>
                {
                    string title = listItem["Title"]?.ToString();
                    if (title == null)
                        title = string.Empty;

                    int number = Convert.ToInt32(title[title.Length -1]);

                    return number % 2 == 0;
                };

                var results = scope.ExecuteCommand("Invoke-SPOWebAction",
                    new CommandParameter("ListItemAction", listItemAction),
                    new CommandParameter("ShouldProcessListAction", shouldProcessListAction),
                    new CommandParameter("ShouldProcessListItemAction", shouldProcessListItemAction)
                );

                Assert.IsTrue(listItemTitles.Count == 2);

                Assert.IsFalse(listItemTitles.Contains("Test1-1"));
                Assert.IsTrue(listItemTitles.Contains("Test1-2"));

                Assert.IsFalse(listItemTitles.Contains("Test2-1"));
                Assert.IsTrue(listItemTitles.Contains("Test2-2"));
                Assert.IsFalse(listItemTitles.Contains("Test2-3"));
            }
        }
    }
}
