using System.Collections.Generic;

namespace AsynchdownloadPrj.ViewModels
{
    public class ProgressReportModel
    {
        public int PercentageComplete { get; set; } = 0;
        public List<UrlDataModel> SitesDownloaded { get; set; } = new List<UrlDataModel>();
    }
}
