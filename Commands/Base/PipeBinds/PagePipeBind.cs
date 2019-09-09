#if !SP2013 && !SP2016 && !SP2019
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.Modernization.Framework.Transform;
using SharePointPnP.PowerShell.Commands.ClientSidePages;
using System;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class PagePipeBind
    {
        private const string CAMLQueryByExtensionAndName = @"
                <View Scope='Recursive'>
                  <Query>
                    <Where>
                      <Eq>
                        <FieldRef Name='FileLeafRef'/>
                        <Value Type='text'>{0}</Value>
                      </Eq>
                    </Where>
                  </Query>
                </View>";

        private readonly ListItem pageListItem;
        private readonly string name;

        public PagePipeBind(ListItem pageListItem)
        {
            this.pageListItem = pageListItem;
            if (this.pageListItem != null)
            {
                this.name = this.pageListItem.FieldValues["FileLeafRef"].ToString();
            }
        }

        public PagePipeBind(string name)
        {
            this.name = ClientSidePageUtilities.EnsureCorrectPageName(name);
            this.pageListItem = null;
        }

        public ListItem PageListItem => this.pageListItem;

        public string Name => this.name;

        public string Library { get; set; }

        public string Folder { get; set; }

        internal ListItem GetPage(Web web, string listToLoad)
        {
            if (!string.IsNullOrEmpty(this.Library))
            {
                listToLoad = this.Library;
            }

            web.EnsureProperty(w => w.ServerRelativeUrl);
            var listServerRelativeUrl = UrlUtility.Combine(web.ServerRelativeUrl, listToLoad);

            List libraryContainingPage = null;
            if (BaseTransform.GetVersion(web.Context) == SPVersion.SP2010)
            {
                libraryContainingPage = web.GetListByName(listToLoad);
            }
            else
            {
                libraryContainingPage = web.GetList(listServerRelativeUrl);
            }

            if (libraryContainingPage != null)
            {
                CamlQuery query = null;
                if (!string.IsNullOrEmpty(this.name))
                {
                    query = new CamlQuery
                    {
                        ViewXml = string.Format(CAMLQueryByExtensionAndName, this.name)
                    };

                    if (!string.IsNullOrEmpty(this.Folder))
                    {
                        libraryContainingPage.EnsureProperty(p => p.RootFolder);
                        query.FolderServerRelativeUrl = $"{libraryContainingPage.RootFolder.ServerRelativeUrl}/{Folder}";
                    }

                    var page = libraryContainingPage.GetItems(query);
                    web.Context.Load(page);
                    web.Context.ExecuteQueryRetry();

                    if (page.Count >= 1)
                    {
                        // Return the first match
                        return page[0];
                    }
                }
            }

            return null;
        }
    }
}
#endif