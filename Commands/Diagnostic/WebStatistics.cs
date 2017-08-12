namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    public class WebStatistics
    {
        public int WebCount { get; set; }
        public int ListCount { get; set; }
        public int ItemCount2 { get; set; }
        public int FolderCount { get; set; }
        public int FileCount { get; set; }
        public int TotalSize { get; set; }
        public int SiteUserCount { get; set; }
        public int SiteGroupCount { get; set; }
        public int UniquePermissionCount { get; set; }
        public int ItemCount { get; internal set; }

        public static WebStatistics operator +(WebStatistics s1, WebStatistics s2)
        {
            return new WebStatistics
            {
                WebCount = s1.WebCount + s2.WebCount,
                ListCount = s1.ListCount + s2.ListCount,
                ItemCount2 = s1.ItemCount2 + s2.ItemCount2,
                FolderCount = s1.FolderCount + s2.FolderCount,
                FileCount = s1.FileCount + s2.FileCount,
                TotalSize = s1.TotalSize + s2.TotalSize,
                SiteUserCount = s1.SiteUserCount,
                SiteGroupCount = s1.SiteGroupCount,
                UniquePermissionCount = s1.WebCount + s2.WebCount,
                ItemCount = s1.WebCount + s2.WebCount
            };
        }
    }
}
