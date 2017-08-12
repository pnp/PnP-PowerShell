using System;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.Commands.Extensions;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

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
        public SwitchParameter Recursive;

        private Expression<Func<Web, object>>[] _retreivalExpressions;

        public MeasurePnPWeb()
        {
            _retreivalExpressions = new Expression<Func<Web, object>>[] {
                w => w.Webs.Include(sw => sw.HasUniqueRoleAssignments),
                w => w.Lists.Include(l => l.ItemCount, l => l.HasUniqueRoleAssignments),
                w => w.Folders.Include(f => f.StorageMetrics, f => f.Files, f => f.ItemCount),
                w => w.SiteUsers.Include(u => u.Id),
                w => w.SiteGroups.Include(g => g.Id)
            };
        }

        protected override void ExecuteCmdlet()
        {
            var web = GetWebByIdentity(_retreivalExpressions);
            var statistics = GetStatistics(web);
            WriteObject(statistics);
        }

        private WebStatistics GetStatistics(Web web)
        {
            var stat = new WebStatistics
            {
                WebCount = web.Webs.Count,
                ListCount = web.Lists.Count,
                FolderCount = web.Folders.Count,
                ItemCount = web.Lists.Sum(l => l.ItemCount),
                ItemCount2 = web.Folders.Sum(f => f.ItemCount),
                FileCount = web.Folders.Sum(f => f.Files.Count),
                TotalSize = (int)web.Folders.Sum(f => f.StorageMetrics.TotalSize),
                SiteUserCount = web.SiteUsers.Count,
                SiteGroupCount = web.SiteGroups.Count,
                UniquePermissionCount = web.Lists.Count(l => l.HasUniqueRoleAssignments) + web.Webs.Count(w => w.HasUniqueRoleAssignments)
            };
            if (Recursive)
            {
                foreach (var subweb in web.Webs)
                {
                    subweb.EnsureProperties(_retreivalExpressions);
                    stat += GetStatistics(subweb);
                }
            }
            return stat;
        }

        private Web GetWebByIdentity(Expression<Func<Web, object>>[] expressions)
        {
            Web web = null;
            if (Identity == null)
            {
                ClientContext.Web.EnsureProperties(expressions);
                web = ClientContext.Web;
            }
            else if (Identity.Id != Guid.Empty)
            {
                web = ClientContext.Web.GetWebById(Identity.Id, expressions);
            }
            else if (Identity.Web != null)
            {
                web = ClientContext.Web.GetWebById(Identity.Web.Id, expressions);
            }
            else if (Identity.Url != null)
            {
                web = ClientContext.Web.GetWebByUrl(Identity.Url, expressions);
            }
            return web;
        }
    }
}
