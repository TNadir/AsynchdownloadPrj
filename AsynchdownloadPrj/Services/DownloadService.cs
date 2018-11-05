using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsynchdownloadPrj.Interface;
using AsynchdownloadPrj.ViewModels;

namespace AsynchdownloadPrj.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly UrlDataModel _urlModel ;
        private readonly WebClient _client ;
        public DownloadService()
        {
            _urlModel = new UrlDataModel();
            _client = new WebClient();
        }

        public async Task<List<UrlDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken, List<string> websites)
        {
            List<UrlDataModel> output = new List<UrlDataModel>();
            ProgressReportModel report = new ProgressReportModel();

            foreach (string site in websites)
            {
                UrlDataModel results = await DownloadWebsiteAsync(site);
                output.Add(results);

                cancellationToken.ThrowIfCancellationRequested();

                report.SitesDownloaded = output;
                report.PercentageComplete = (output.Count * 100) / websites.Count;
                progress.Report(report);
            }
            return output;
        }

        public List<string> GetPreparedList(ListBox listBox)
        {
            var list = new List<string>();
            foreach (var item in listBox.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        public async Task<UrlDataModel> DownloadWebsiteAsync(string url)
        {
            _urlModel.UrlName = url;
            _urlModel.UrlData = await _client.DownloadStringTaskAsync(url);
            return _urlModel;
        }
    }
}
