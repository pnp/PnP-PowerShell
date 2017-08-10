using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.Commands.Extensions;
using System.Linq.Expressions;

namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    [Cmdlet(VerbsDiagnostic.Measure, "PnPWeb")]
    [CmdletHelp("Returns statistics on the web object",
        Category = CmdletHelpCategory.Diagnostic)]
    public class MeasurePnPWeb : PnPCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public WebPipeBind Identity;

        [Parameter(Mandatory = false)]
        public bool Recursive;

        private Expression<Func<Web, object>>[] retreivalExpressions;

        protected override void ExecuteCmdlet()
        {
            retreivalExpressions = new Expression<Func<Web, object>>[] {
                w => w.Webs.Include(sw => sw.HasUniqueRoleAssignments),
                w => w.Lists.Include(l => l.ItemCount, l => l.HasUniqueRoleAssignments),
                w => w.Folders.Include(f => f.StorageMetrics, f=> f.Files, f => f.ItemCount),
                w => w.SiteUsers.Include(u => u.Id),
                w => w.SiteGroups.Include(g => g.Id)
            };
            var web = GetWebByIdentity(retreivalExpressions);

            var statistics = GetStatistics(web);
            WriteObject(new WebStatistics()
            {
                WebCount = web.Webs.Count,
                ListCount = web.Lists.Count,
                FolderCount = web.Folders.Count,
                ItemCount = web.Lists.Sum(l => l.ItemCount),
                ItemCount2 = web.Folders.Sum(l => l.ItemCount),
                FileCount = web.Folders.Sum(f => f.Files.Count),
                TotalSize = (int)web.Folders.Sum(f => f.StorageMetrics.TotalSize),
                SiteUserCount = web.SiteUsers.Count,
                SiteGroupCount = web.SiteGroups.Count,
                UniquePermissionCount = web.Lists.Count(l => l.HasUniqueRoleAssignments) + web.Webs.Count(w => w.HasUniqueRoleAssignments)
            });
        }

        private WebStatistics GetStatistics(Web web)
        {
            var res = new WebStatistics()
            {
                WebCount = web.Webs.Count,
                ListCount = web.Lists.Count,
                FolderCount = web.Folders.Count,
                ItemCount = web.Lists.Sum(l => l.ItemCount),
                ItemCount2 = web.Folders.Sum(l => l.ItemCount),
                FileCount = web.Folders.Sum(f => f.Files.Count),
                TotalSize = (int)web.Folders.Sum(f => f.StorageMetrics.TotalSize),
                SiteUserCount = web.SiteUsers.Count,
                SiteGroupCount = web.SiteGroups.Count,
                UniquePermissionCount = web.Lists.Count(l => l.HasUniqueRoleAssignments) + web.Webs.Count(w => w.HasUniqueRoleAssignments)
            };
            if(Recursive)
            {
                foreach(var subweb in web.Webs)
                {
                    subweb.EnsureProperties(retreivalExpressions);
                    var stat = GetStatistics(subweb);
                    res = res + stat;
                }
            }
            return res;
        }

        private Web GetWebByIdentity(Expression<Func<Web, object>>[] exp)
        {
            Web res = null;
            if (Identity == null)
            {
                ClientContext.Web.EnsureProperties(exp);
                res = ClientContext.Web;
            }
            else if (Identity.Id != Guid.Empty)
            {
                res = ClientContext.Web.GetWebById(Identity.Id, exp);
            }
            else if (Identity.Web != null)
            {
                res = ClientContext.Web.GetWebById(Identity.Web.Id, exp);
            }
            else if (Identity.Url != null)
            {
                res = ClientContext.Web.GetWebByUrl(Identity.Url, exp);
            }
            return res;
        }
    }
}
